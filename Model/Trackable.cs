using System;

namespace Model
{
    public class Trackable : InitGuid
    {
        public Trackable(string name, FieldType fieldType, bool inactive) : base()
        {         
            this.Name = name;
            this.FieldType = fieldType;
            this.Inactive = inactive;

        }        
        public string Name { get; set; }
        public FieldType FieldType { get; set; } //if this changes it messes up the deserialization.  If you ever wanted to change this, you would simply replace the whole Trackable and set Inactive true
        public bool Inactive { get; set; }

    }
}