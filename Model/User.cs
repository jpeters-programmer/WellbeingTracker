using System;

namespace Model
{
    public class User : InitGuid
    {
        internal User() : base() {
            Name = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            TrackingSetup = new TrackingSetup(this);
        }

        public User(string name, string password, string email, TrackingSetup trackingSetup) : base()
        {
            Name = name;
            Password = password;            
            Email = email;
            TrackingSetup = trackingSetup;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email {get;set;}
        public TrackingSetup TrackingSetup {get;set;}
    }
}