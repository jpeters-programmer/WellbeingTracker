using System;

namespace Model
{
    public class User : InitGuid
    {
        internal User() : base() {
            Name = string.Empty;
            Password = string.Empty;
            this.TrackingSetup = new TrackingSetup(this);
        }

        public User(string name, string password, TrackingSetup trackingSetup) : base()
        {
            this.Name = name;
            this.Password = password;
            TrackingSetup = trackingSetup;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public TrackingSetup TrackingSetup {get;set;}
    }
}