using Bakkar_Lake_Web_Application.Data;
using Bakkar_Lake_Web_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bakkar_Lake_Web_Application.Controllers
{
    public class AdminController: Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult AdminFunctions()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AllBookings()
        {
            var bookings = _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Package)
                .Include(b => b.BookingRooms)
                .ThenInclude(br => br.Room)
                .ToList();

            return View(bookings);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CancelBooking(int bookingId)
        {
            var booking = _context.Bookings
                .Include(b => b.BookingRooms)
                .FirstOrDefault(b => b.B_Id == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

           
            _context.BookingRooms.RemoveRange(booking.BookingRooms);

          
            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction("AllBookings");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AllCustomers()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult PackageList()
        {
            var packages = _context.Packages.ToList();
            return View(packages);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPackages()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPackages(AdminVM adminVM)
        {
                    var package = new Package
                    {
                        PakkageDetail = adminVM.PakkageDetail,
                        PricePerDay = adminVM.PricePerDay,
                        PackageTotalPrice = adminVM.PackageTotalPrice,
                        Status = true
                    };
                    _context.Packages.Add(package);
                    _context.SaveChanges();

                 
                    return RedirectToAction("PackageList");
            
            return View(adminVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RoomList()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRoom(AdminVM adminVM)
        {
            var room = new Room
            {
                RoomName = adminVM.RoomName
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();


            return RedirectToAction("RoomList");

            return View(adminVM);
        }

    }
}