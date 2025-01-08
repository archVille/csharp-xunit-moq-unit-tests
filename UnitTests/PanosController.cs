using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace UnitTests
{
    public class PanosController : Controller
    {
        public IActionResult Entry()
        {
            return (IActionResult)View();
        }

        [HttpPost]
        public IActionResult Entry(string name, string membership)
        {
            if (string.IsNullOrEmpty(name))
                ModelState.AddModelError("name", "Please enter your name");

            if (string.IsNullOrEmpty(membership))
                ModelState.AddModelError("membership", "Please enter your membership");

            if (ModelState.IsValid)
            {
                string nm = name + "," + membership;
                return (IActionResult)View((object)nm);
            }
            else
                return BadRequest(ModelState);
        }

        private IActionResult BadRequest(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}
