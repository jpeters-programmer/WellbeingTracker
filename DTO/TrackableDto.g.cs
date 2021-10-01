using System;
using Model;

namespace DTO
{
    public partial class TrackableDto
    {
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
        public bool Inactive { get; set; }
        public Guid Guid { get; set; }
    }
}