using System.Collections.Generic;
using DTO;
using Mapster;
using Model;

namespace DTO
{
    public static partial class UserMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static UserDto AdaptToDto(this User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Name = p1.Name,
                Password = p1.Password,
                Email = p1.Email,
                TrackingSetup = funcMain1(p1.TrackingSetup),
                Id = p1.Id
            };
        }
        public static UserDto AdaptTo(this User p4, UserDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            UserDto result = p5 ?? new UserDto();
            
            result.Name = p4.Name;
            result.Password = p4.Password;
            result.Email = p4.Email;
            result.TrackingSetup = funcMain3(p4.TrackingSetup, result.TrackingSetup);
            result.Id = p4.Id;
            return result;
            
        }
        
        private static TrackingSetupDto funcMain1(TrackingSetup p2)
        {
            return p2 == null ? null : new TrackingSetupDto()
            {
                Trackables = funcMain2(p2.Trackables),
                User = TypeAdapterConfig1.GetMapFunction<User, UserDto>().Invoke(p2.User),
                Id = p2.Id
            };
        }
        
        private static TrackingSetupDto funcMain3(TrackingSetup p6, TrackingSetupDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            TrackingSetupDto result = p7 ?? new TrackingSetupDto();
            
            result.Trackables = funcMain4(p6.Trackables, result.Trackables);
            result.User = TypeAdapterConfig1.GetMapToTargetFunction<User, UserDto>().Invoke(p6.User, result.User);
            result.Id = p6.Id;
            return result;
            
        }
        
        private static List<TrackableDto> funcMain2(List<Trackable> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<TrackableDto> result = new List<TrackableDto>(p3.Count);
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                Trackable item = p3[i];
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
        
        private static List<TrackableDto> funcMain4(List<Trackable> p8, List<TrackableDto> p9)
        {
            if (p8 == null)
            {
                return null;
            }
            List<TrackableDto> result = new List<TrackableDto>(p8.Count);
            
            int i = 0;
            int len = p8.Count;
            
            while (i < len)
            {
                Trackable item = p8[i];
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
    }
}