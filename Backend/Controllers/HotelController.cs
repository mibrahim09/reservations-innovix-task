using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using HotelsManager.Dtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using HotelsManager.Models;
using HotelsManager.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelsManager.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public HotelController(HotelDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allMeals = _context.Meals
                .Select((Meal) => new { id = Meal.MealId, value = Meal.MealType });
            var allRoomTypes = _context.RoomTypes
                .Select((Room) => new { id = Room.Id, value = Room.RoomType1 });
            return Ok(new JsonResult(new
            {
                Meals = allMeals,
                Rooms = allRoomTypes
            }));
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewReservation newReservation)
        {
            var reservationService = new Reservation(newReservation, _context);
            return Ok(reservationService.GetReservationTotal());
        }


    }
}
