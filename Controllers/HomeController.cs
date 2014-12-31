using Microsoft.AspNet.Mvc;
using VNext.Models;

namespace VNext.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(this.User());
        }

        public User User()
        {
            User user = new User()
            {
                Name = "Rogerio R Alcantra",
                Username = "roalcantara",
                Password = "qazwsx"
            };

            return user;
        }
    }
}