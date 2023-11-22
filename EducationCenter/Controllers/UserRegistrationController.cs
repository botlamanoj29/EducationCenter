using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistrationController
        public ActionResult Index()
        {
            return View();
        }


        // POST: UserRegistrationController/Create
        [HttpPost]

        public ActionResult Index(IFormCollection collection)
        {
            try
            {

                var model = new RegistrationDetails { Password = collection["Password"] };
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);

                if (!isValid)
                {
                    ViewBag.Message = validationResults[0].ErrorMessage;
                    return View("Index");
                    // Handle validation errors
                }
                else
                {
                    // Your logic for valid data
                    return View("Success");
                }
            }
            catch
            {
                return View();
            }
        }


    }
}
