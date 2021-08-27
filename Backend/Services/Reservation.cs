using HotelsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsManager.Services
{
    public class Reservation
    {
        NewReservation _reservation;
        HotelDbContext _context;
        public Reservation(NewReservation reservation, HotelDbContext context)
        {
            _reservation = reservation;
            _context = context;
        }
        public double GetReservationTotal()
        {
            var reservationPeriod = Math.Max(1, (int)(_reservation.CheckOut - _reservation.CheckIn).TotalDays);

            var ratePerPersonMeal = _context.MealRates.Where(e => e.MealId == _reservation.MealPlan).ToList();
            var priceRateMeals = GetMeals(ratePerPersonMeal);

            var ratePerRoom = _context.RoomRates.Where(e => e.RoomTypeId == _reservation.RoomType).ToList();
            var priceRateRoom = GetRoomsPrice(ratePerRoom);

            return priceRateRoom + priceRateMeals;
        }
        private int GetRoomsPrice(List<RoomRate> roomRates)
        {
            var checkInDate = _reservation.CheckIn;
            var checkOutDate = _reservation.CheckOut;

            var sum = 0;
            foreach (var dateItem in roomRates)
            {
                bool overlap = checkInDate < dateItem.EndDate && dateItem.StartDate < checkOutDate;
                if (overlap)
                {
                    if (checkOutDate > dateItem.EndDate)// More than one period enters here.
                    {
                        sum += (int)((Math.Abs((dateItem.EndDate - checkInDate).Value.TotalDays) + 1) * dateItem.RatePerRoom);

                        // UPDATE THE CHECK IN DATE TO PREVENT RE-CALCULATING THE DAYS AGAIN.
                        checkInDate = dateItem.EndDate.Value.AddDays(1);
                    }
                    else // NORMAL
                    {
                        sum += (int)((checkOutDate - checkInDate).TotalDays * dateItem.RatePerRoom);
                        break;
                    }
                }
            }
            return sum;

        }
        private int GetMeals(List<MealRate> mealRates)
        {
            var checkInDate = _reservation.CheckIn;
            var checkOutDate = _reservation.CheckOut;

            var sum = 0;
            var members = _reservation.Adults + _reservation.Children;
            foreach (var dateItem in mealRates)
            {
                bool overlap = checkInDate < dateItem.EndDate && dateItem.StartDate < checkOutDate;
                if (overlap)
                {
                    if (checkOutDate > dateItem.EndDate)// More than one period enters here.
                    {
                        sum += (int)((Math.Abs((dateItem.EndDate - checkInDate).Value.TotalDays) + 1) * dateItem.RatePerPerson * members);

                        // UPDATE THE CHECK IN DATE TO PREVENT RE-CALCULATING THE DAYS AGAIN.
                        checkInDate = dateItem.EndDate.Value.AddDays(1);
                    }
                    else
                    {
                        // Full period is covered. 
                        // So we break after we calculate the sum.

                        sum += (int)((checkOutDate - checkInDate).TotalDays * dateItem.RatePerPerson * members);
                        break;
                    }
                }
            }
            return sum;

        }
    }
}
