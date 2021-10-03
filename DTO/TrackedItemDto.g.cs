using System;
using DTO;

namespace DTO
{
    public partial class TrackedItemDto
    {
        public TrackableDto? Trackable { get; set; }
        public string FieldValueJson { get; set; }
        public Guid Id { get; set; }
    }
}