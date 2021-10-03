using System.Collections.Generic;
using DTO;
using Mapster;
using Model;

namespace DTO
{
    public static partial class TrackingSetupMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static TrackingSetupDto AdaptToDto(this TrackingSetup p1)
        {
            return p1 == null ? null : new TrackingSetupDto()
            {
                Trackables = funcMain1(p1.Trackables),
                User = p1.User == null ? null : new UserDto()
                {
                    Name = p1.User.Name,
                    Password = p1.User.Password,
                    Email = p1.User.Email,
                    TrackingSetup = TypeAdapterConfig1.GetMapFunction<TrackingSetup, TrackingSetupDto>().Invoke(p1.User.TrackingSetup),
                    Id = p1.User.Id
                },
                Id = p1.Id
            };
        }
        public static TrackingSetupDto AdaptTo(this TrackingSetup p3, TrackingSetupDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            TrackingSetupDto result = p4 ?? new TrackingSetupDto();
            
            result.Trackables = funcMain2(p3.Trackables, result.Trackables);
            result.User = funcMain3(p3.User, result.User);
            result.Id = p3.Id;
            return result;
            
        }
        
        private static List<TrackableDto> funcMain1(List<Trackable> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<TrackableDto> result = new List<TrackableDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                Trackable item = p2[i];
                result.Add(item == null ? null : new TrackableDto()
                {
                    Name = item.Name,
                    FieldType = item.FieldType,
                    Inactive = item.Inactive,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static List<TrackableDto> funcMain2(List<Trackable> p5, List<TrackableDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<TrackableDto> result = new List<TrackableDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                Trackable item = p5[i];
                result.Add(item == null ? null : new TrackableDto()
                {
                    Name = item.Name,
                    FieldType = item.FieldType,
                    Inactive = item.Inactive,
                    Id = item.Id
                });
                i++;
            }
            return result;
            
        }
        
        private static UserDto funcMain3(User p7, UserDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            UserDto result = p8 ?? new UserDto();
            
            result.Name = p7.Name;
            result.Password = p7.Password;
            result.Email = p7.Email;
            result.TrackingSetup = TypeAdapterConfig1.GetMapToTargetFunction<TrackingSetup, TrackingSetupDto>().Invoke(p7.TrackingSetup, result.TrackingSetup);
            result.Id = p7.Id;
            return result;
            
        }
    }
}