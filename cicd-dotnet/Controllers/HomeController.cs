using Microsoft.AspNetCore.Mvc;
using cicd_dotnet.Services;
using cicd_dotnet.ViewModels;

namespace cicd_dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly MathService _mathService;

        public HomeController(MathService mathService)
        {
            _mathService = mathService;
        }

        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result = 0;
                switch (model.Operation)
                {
                    case "Add":
                        result = _mathService.Add(model.Number1, model.Number2);
                        break;
                    case "Subtract":
                        result = _mathService.Subtract(model.Number1, model.Number2);
                        break;
                    // case "Multiply":
                    //     result = _mathService.Multiply(model.Number1, model.Number2);
                    //     break;
                    // case "Divide":
                    //     if (model.Number2 != 0)
                    //     {
                    //         result = _mathService.Divide(model.Number1, model.Number2);
                    //     }
                    //     else
                    //     {
                    //         return Content("Cannot divide by zero.");
                    //     }
                    //     break;
                }
                return Content($"Result: {result}");
            }
            return BadRequest(ModelState);
        }
    }
}
