using Bakkar_Lake_Web_Application.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;

    public ContactController(IConfiguration configuration)
    {
        _configuration = configuration;
        
    }

    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMessage(ContactForm form)
    {

        if (!ModelState.IsValid)
        {
            return View(form); 
        }
        try
        {
            var smtpEmail = _configuration["SMTP:Email"];
            var smtpPassword = _configuration["SMTP:Password"];
            var recipientEmail = _configuration["SMTP:Recipient"];


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, 
                Credentials = new NetworkCredential(smtpEmail, smtpPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpEmail), 
                Subject = "Bakar Lake Resort",
                Body = $"Name: {form.Name}\nEmail: {form.Email}\nMessage: {form.Message}",
                IsBodyHtml = false,
            };
            mailMessage.To.Add(recipientEmail); 

            smtpClient.Send(mailMessage);

            ViewBag.Message = "Your message has been sent successfully!";
        }
        catch (Exception ex)
        {
            ViewBag.Message = "Error sending your message. Please try again later.";
            Console.WriteLine($"Error: {ex.Message}"); 
        }

        return View("SendMessage");
    }
}
