using System;
using System.Collections.Generic;

namespace Model
{
    public class TrackingSetup : InitGuid
    {
        internal TrackingSetup() : base() {
            Trackables = new List<Trackable>();
            User = new User();
        }
        public TrackingSetup(User user) : base()
        {
            Trackables = new List<Trackable>();      
            User = user;
            UserGuid = user.Id;
        }        
        public List<Trackable> Trackables { get;set;}
        public User User {get;set;}
        internal Guid UserGuid {get;set;}
    }
}