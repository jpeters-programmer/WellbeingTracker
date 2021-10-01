using System;
using System.Collections.Generic;
using Model;


namespace API
{
    public class TrackableController
    {
        public IEnumerable<string> GetFieldTypes() {
            return Enum.GetNames<FieldType>();
        }
        
    }
}