using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.API.Controllers
{
    public class PetNameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
