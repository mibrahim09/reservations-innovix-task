using System;
using System.Collections.Generic;

#nullable disable

namespace HotelsManager.Models
{
    public partial class MealRate
    {
        public int MealId { get; set; }
        public int RatePerPerson { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Meal Meal { get; set; }
    }
}
