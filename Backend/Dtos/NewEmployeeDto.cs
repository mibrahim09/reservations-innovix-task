using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsManager.Dtos 
{
    public class NewEmployeeDto
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

    }
}
