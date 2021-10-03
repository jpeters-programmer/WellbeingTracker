using DTO;
using Model;

namespace DTO
{
    public static partial class TrackedItemMapper
    {
        public static TrackedItemDto AdaptToDto(this TrackedItem p1)
        {
            return p1 == null ? null : new TrackedItemDto()
            {
                Trackable = p1.Trackable == null ? null : new TrackableDto()
                {
                    Name = p1.Trackable.Name,
                    FieldType = p1.Trackable.FieldType,
                    Inactive = p1.Trackable.Inactive,
                    Id = p1.Trackable.Id
                },
                FieldValueJson = p1.FieldValueJson,
                Id = p1.Id
            };
        }
        public static TrackedItemDto AdaptTo(this TrackedItem p2, TrackedItemDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            TrackedItemDto result = p3 ?? new TrackedItemDto();
            
            result.Trackable = funcMain1(p2.Trackable, result.Trackable);
            result.FieldValueJson = p2.FieldValueJson;
            result.Id = p2.Id;
            return result;
            
        }
        
        private static TrackableDto funcMain1(Trackable p4, TrackableDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            TrackableDto result = p5 ?? new TrackableDto();
            
            result.Name = p4.Name;
            result.FieldType = p4.FieldType;
            result.Inactive = p4.Inactive;
            result.Id = p4.Id;
            return result;
            
        }
    }
}