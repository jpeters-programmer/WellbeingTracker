using System;
using System.Collections.Generic;
using DTO;

namespace DTO
{
    public partial class TrackingEntryDto
    {
        public List<TrackedItemDto> TrackedItems { get; set; }
        public Guid Id { get; set; }
    }
}