using System;
using System.Collections.Generic;
using DTO;

namespace DTO
{
    public partial class TrackingSetupDto
    {
        public List<TrackableDto> Trackables { get; set; }
        public UserDto User { get; set; }
        public Guid Id { get; set; }
    }
}