using System;
using System.Collections.Generic;

namespace Model
{
    public class TrackingEntry : InitGuid
    {
        private TrackingEntry() : base() {
            TrackedItems = new List<TrackedItem>();            
        }
        public TrackingEntry(List<TrackedItem> trackedItems) : base()
        {         
            TrackedItems = trackedItems;
        }      
        public List<TrackedItem> TrackedItems { get; set; }
    }
}