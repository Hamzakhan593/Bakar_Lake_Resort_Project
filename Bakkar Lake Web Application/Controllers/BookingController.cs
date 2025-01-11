using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakkar_Lake_Web_Application.Models;


using Bakkar_Lake_Web_Application.Data;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bakkar_Lake_Web_Application.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        private bool AreRoomsAvailable(int requestedRooms, DateTime checkIn, DateTime checkOut)
        {
            // Get all bookings that overlap with the requested date range
            var overlappingBookings = _context.Bookings
                .Include(b => b.BookingRooms) // Include booked rooms
                .Where(b =>
                    b.CheckOutDate > checkIn &&
                    b.CheckInDate < checkOut) // Overlap condition
                .SelectMany(b => b.BookingRooms.Select(br => br.RoomId))
                .Distinct()
                .Count();

            // Calculate available rooms
            int totalRooms = 4; // Total rooms in the resort
            int availableRooms = totalRooms - overlappingBookings;

            return availableRooms >= requestedRooms;
        }


        [HttpGet]
        public IActionResult Create()
        {
            var packages = _context.Packages.ToList();

            var model = new BookingViewModel
            {
                Packages = packages,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookingViewModel model)
        {

            model.Packages = _context.Packages.ToList();

            if (ModelState.IsValid)
            {
                model.CalculateTotalDays();
                model.CalculateTotalAmount();
                int requestedRooms = 0;
                if (model.PackageId == 3)
                {
                    requestedRooms = model.PackageId + 1;
                }
                else
                {
                    requestedRooms = model.PackageId; // Map package IDs to the number of rooms
                }
                if (!AreRoomsAvailable(requestedRooms, model.CheckInDate, model.CheckOutDate))
                {
                    ModelState.AddModelError("", "The Rooms are booked for the selected dates. please select small package");
                    return View(model);
                }

                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerPhoneNumber = model.CustomerPhoneNumber,
                    CustomerEmail = model.CustomerEmail,
                    CustomerCNIC = model.CustomerCNIC,
                    Address = model.Address,
                };
                _context.Customers.Add(customer);
                _context.SaveChanges();

                var booking = new Booking
                {
                    C_Id = customer.C_Id,
                    P_Id = model.PackageId,
                    CheckInDate = model.CheckInDate,
                    CheckOutDate = model.CheckOutDate,
                    Discount = model.Discount,
                    TotalPrice = model.Total,
                    TotalDays = model.TotalDays,
                    Status = true
                };
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                //// Assign rooms to the booking
                AssignRoomsToBooking(booking.B_Id, requestedRooms);

                return RedirectToAction("Confirmation", new { id = booking.B_Id });
            }

            return View(model);
        }

        private void AssignRoomsToBooking(int bookingId, int requestedRooms)
        {
            var bookedRoomIds = _context.BookingRooms
                .Select(br => br.RoomId)
                .ToHashSet();

            var availableRooms = _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.RoomId))
                .Take(requestedRooms)
                .ToList();

            foreach (var room in availableRooms)
            {
                var bookingRoom = new BookingRoom
                {
                    RoomId = room.RoomId,
                    B_Id = bookingId
                };
                _context.BookingRooms.Add(bookingRoom);
            }

            _context.SaveChanges();
        }


        public IActionResult Confirmation(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .FirstOrDefault(b => b.B_Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            var viewModel = new BookingViewModel
            {
                CustomerName = booking.Customer.CustomerName,
                CustomerPhoneNumber = booking.Customer.CustomerPhoneNumber,
                CustomerEmail = booking.Customer.CustomerEmail,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                Total = booking.TotalPrice,
                Discount = booking.Discount,
                TotalDays = (booking.CheckOutDate - booking.CheckInDate).Days
            };

            return View(viewModel);
        }

    }
}
