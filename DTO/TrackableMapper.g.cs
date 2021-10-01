using DTO;
using Model;

namespace DTO
{
    public static partial class TrackableMapper
    {
        public static TrackableDto AdaptToDto(this Trackable p1)
        {
            return p1 == null ? null : new TrackableDto()
            {
                Name = p1.Name,
                FieldType = p1.FieldType,
                Inactive = p1.Inactive,
                Guid = p1.Id
            };
        }
        public static TrackableDto AdaptTo(this Trackable p2, TrackableDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            TrackableDto result = p3 ?? new TrackableDto();
            
            result.Name = p2.Name;
            result.FieldType = p2.FieldType;
            result.Inactive = p2.Inactive;
            result.Guid = p2.Id;
            return result;
            
        }
    }
}