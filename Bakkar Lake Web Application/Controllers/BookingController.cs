using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakkar_Lake_Web_Application.Models;


using Bakkar_Lake_Web_Application.Data;

namespace Bakkar_Lake_Web_Application.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult GetPackageTotalPrice(int id)
        {
            var package = _context.Packages.FirstOrDefault(p => p.P_Id == id);
            if (package != null)
            {
                return Json(new { success = true, totalPrice = package.TotalPrice });
            }
            return Json(new { success = false });
        }
        // GET: Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            var packages = _context.Packages.ToList();
            var rooms = _context.Rooms.ToList();

            // Create a ViewModel and pass the list of packages and rooms
            var model = new BookingViewModel
            {
                
                Packages = packages,
                Rooms = rooms,
                CheckInDate = DateTime.Now,// Set default to today's date
                CheckOutDate = DateTime.Now
            };

            return View(model);
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookingViewModel model)
        {
            {
                
                    // Calculate the total days and total amount
                    model.CalculateTotalDays();
                    model.CalculateTotalAmount();

                    // Find the selected package to calculate the total
                    var selectedPackage = _context.Packages.FirstOrDefault(p => p.P_Id == model.PackageId);

                    // Create and save the customer
                    var customer = new Customer
                    {
                        CustomerName = model.CustomerName,
                        CustomerPhoneNumber = model.CustomerPhoneNumber,
                        CustomerEmail = model.CustomerEmail,
                        CustomerCNIC = model.CustomerCNIC,
                        Address = model.Address,
        Status = true // Assuming the customer is active by default
                    };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();

                    // Create and save the booking
                    var booking = new Booking
                    {
                        C_Id = customer.C_Id,
                        P_Id = model.PackageId,
                        CheckInDate = model.CheckInDate,
                        CheckOutDate = model.CheckOutDate,
                        Discount = model.Discount,
                        Total = model.Total,
                        Status = model.Status
                    };
                    _context.Bookings.Add(booking);
                    _context.SaveChanges();

                    // Create and save the BookingRoom entry
                    var bookingRoom = new BookingRoom
                    {
                        B_Id = booking.B_Id,
                        RoomId = model.RoomId
                    };
                    _context.BookingRooms.Add(bookingRoom);
                    _context.SaveChanges();

                    //return RedirectToAction("Index", "Booking");
                

                // Reload dropdowns if the form is invalid
                model.Packages = _context.Packages.ToList();
                model.Rooms = _context.Rooms.ToList();

                return View(model);
            }
        }
    }
}
