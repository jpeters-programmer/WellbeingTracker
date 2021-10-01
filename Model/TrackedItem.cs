using System;
using System.Text.Json;
namespace Model
{
    public class TrackedItem : InitGuid
    {
        private TrackedItem() {
            FieldValueJson = string.Empty;
        }
        internal TrackedItem(Trackable trackable, string fieldValueJson) : base()
        {
            FieldValueJson = fieldValueJson;
            Trackable = trackable;
        }

        public Trackable? Trackable {get;set;}
        public string FieldValueJson {get;set;}

        public T GetValue<T>() {
            T? rslt = JsonSerializer.Deserialize<T>(FieldValueJson);
            if (rslt is null) throw new InvalidOperationException("Unexpected null value from Deserialize");
            return rslt;
        }

        public void SetValue<T>(T gvalue) {
            if (Trackable is null) throw new InvalidOperationException("Can not call set value when Trackable is null");
            TestValue<T>(Trackable.FieldType, gvalue);
            FieldValueJson = JsonSerializer.Serialize<T>(gvalue);
        }

        public static void TestValue<T>(FieldType fieldType, T gvalue) {
            switch (fieldType) {
                case FieldType.Range1to5: {
                    if(typeof(T) != typeof(int)) throw new ArgumentException("This trackable expects a value of type int");
                    int value = Convert.ToInt32(gvalue);
                    if (value < 1 || value > 5) throw new ArgumentOutOfRangeException(nameof(value), value, "FieldType Rating1to5 requires value between 1 and 5");                    
                }
                break;
                case FieldType.Distance: {
                    if(typeof(T) != typeof(float)) throw new ArgumentException("This trackable expects a value of type float");
                    float value = Convert.ToSingle(gvalue);
                    if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "FieldType Distance can not be negative");
                }
                break;
                case FieldType.Time: {
                    if(typeof(T) != typeof(TimeSpan)) throw new ArgumentException("This trackable expects a value of type TimeSpan");
                    TimeSpan value = TimeSpan.FromTicks(Convert.ToInt64(gvalue));
                    if (value.Ticks < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "FieldType Time can not be negative");
                }
                break;
                case FieldType.Occurrences: {
                    if(typeof(T) != typeof(int)) throw new ArgumentException("This trackable expects a value of type int");
                    int value = Convert.ToInt32(gvalue);
                    if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "FieldType Occurrences can not be negative");
                }
                break;
            }            
        }
        
        public static TrackedItem NewRating1to5(Trackable trackable, int value) {
            if (trackable.FieldType != FieldType.Range1to5) throw new InvalidOperationException("Mismatch between supplied trackable and expected FieldType");
            TestValue(trackable.FieldType, value);
            return new TrackedItem(trackable, JsonSerializer.Serialize(value, typeof(int)));
        }

        public static TrackedItem NewOccurrences(Trackable trackable, int value) {
            if (trackable.FieldType != FieldType.Occurrences) throw new InvalidOperationException("Mismatch between supplied trackable and expected FieldType");
            TestValue(trackable.FieldType, value);
            return new TrackedItem(trackable, JsonSerializer.Serialize(value, typeof(int)));
        }

        public static TrackedItem NewTime(Trackable trackable, TimeSpan value) {
            if (trackable.FieldType != FieldType.Time) throw new InvalidOperationException("Mismatch between supplied trackable and expected FieldType");
            TestValue(trackable.FieldType, value);
            return new TrackedItem(trackable, JsonSerializer.Serialize(value, typeof(TimeSpan)));
        }

        public static TrackedItem NewDistance(Trackable trackable, float value) {
            if (trackable.FieldType != FieldType.Distance) throw new InvalidOperationException("Mismatch between supplied trackable and expected FieldType");
            TestValue(trackable.FieldType, value);
            return new TrackedItem(trackable, JsonSerializer.Serialize(value, typeof(float)));
        }
    }
}