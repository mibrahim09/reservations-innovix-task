using System;
using System.Collections.Generic;

#nullable disable

namespace HotelsManager.Models
{
    public partial class RoomRate
    {
        public int RoomTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int RatePerRoom { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
