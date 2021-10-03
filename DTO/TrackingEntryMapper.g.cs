using System.Collections.Generic;
using DTO;
using Model;

namespace DTO
{
    public static partial class TrackingEntryMapper
    {
        public static TrackingEntryDto AdaptToDto(this TrackingEntry p1)
        {
            return p1 == null ? null : new TrackingEntryDto()
            {
                TrackedItems = funcMain1(p1.TrackedItems),
                Id = p1.Id
            };
        }
        public static TrackingEntryDto AdaptTo(this TrackingEntry p3, TrackingEntryDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            TrackingEntryDto result = p4 ?? new TrackingEntryDto();
            
            result.TrackedItems = funcMain2(p3.TrackedItems, result.TrackedItems);
            result.Id = p3.Id;
            return result;
            
        }
        
        private static List<TrackedItemDto> funcMain1(List<TrackedItem> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<TrackedItemDto> result = new List<TrackedItemDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                TrackedItem item = p2[i];
                result.Add(item == null ? null : new TrackedItemDto()
                {
                    Trackable = item.Trackable == null ? null : new TrackableDto()
                    {
                        Name = item.Trackable.Name,
                        FieldType = item.Trackable.FieldType,
                        Inactive = item.Trackable.Inactive,
                        Id = item.Trackable.Id
                    },
                    FieldValueJson = item.FieldValueJson,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static List<TrackedItemDto> funcMain2(List<TrackedItem> p5, List<TrackedItemDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<TrackedItemDto> result = new List<TrackedItemDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                TrackedItem item = p5[i];
                result.Add(item == null ? null : new TrackedItemDto()
                {
                    Trackable = item.Trackable == null ? null : new TrackableDto()
                    {
                        Name = item.Trackable.Name,
                        FieldType = item.Trackable.FieldType,
                        Inactive = item.Trackable.Inactive,
                        Id = item.Trackable.Id
                    },
                    FieldValueJson = item.FieldValueJson,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
    }
}