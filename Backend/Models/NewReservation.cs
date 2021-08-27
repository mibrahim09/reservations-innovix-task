using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsManager.Models
{
    public class NewReservation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Range(0, 2)]
        public int Adults { get; set; }
        [Required]
        [Range(0, 2)]
        public int Children { get; set; }
        [Required]
        public int RoomType { get; set; }
        [Required]
        public int MealPlan { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
    }
}
