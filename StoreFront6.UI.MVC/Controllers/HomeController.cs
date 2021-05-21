using StoreFront6.UI.MVC.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace StoreFront6.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            string message = $"You have received an email from {cvm.Name} with a subject of {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br/>{cvm.Message}";

            //MailMessage - this is what sends the email.
            //Added using statement System.Net.Mail
            MailMessage mm = new MailMessage(
                //Added Using Statment for System.Configuration
                //This is the FROM
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                //TO
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                //subject
                cvm.Subject,
                //message
                message
                );

            //MailMessage properties
            //Allow HTML Formatting
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            
            //respond to the sender and not the address the message was sent from.
            mm.ReplyToList.Add(cvm.Email);

            //Simple Mail Transfer Protocol
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            //client creds
            //Network Credential needs using statement.
            //Added using statement for System.Net
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailPass"].ToString());

            //try to send the email. This COULD Fail so we need a Try/Catch.
            try
            {
                client.Send(mm);
            }
            //Added using statment using.System for exception
            catch (Exception Ex)
            {
                ViewBag.CustomerMessage = $"We're sorry friend! You request could not be completed at this time. Please try again later. Error Mesage: <br/>{Ex.StackTrace}";
                return View(cvm);
                
            }
            //Everything Worked and sent, return to the user a confirmation view.
            return View("EmailConfirmation", cvm);
        }
    }
}
