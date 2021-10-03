using System;
using DTO;

namespace DTO
{
    public partial class UserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public TrackingSetupDto TrackingSetup { get; set; }
        public Guid Id { get; set; }
    }
}