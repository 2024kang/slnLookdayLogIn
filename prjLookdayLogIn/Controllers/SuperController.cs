  using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using prjLookdayLogIn.Models;

namespace prjLookdayLogIn.Controllers
{
    public class SuperController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_MEMBER))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "LogIn",
                    action = "LogIn"
                }));
            }

        }

        


        public IActionResult Index()
        {
            return View();
        }
    }
}
