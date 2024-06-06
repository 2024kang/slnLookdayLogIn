using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjLookdayLogIn.Models;
using prjLookdayLogIn.ViewModel;
using System.Text;
using System.Text.Json;

namespace prjLookdayLogIn.Controllers
{
    public class LogInController : Controller
    {
        private readonly lookdaysContext _context;
        public LogInController(lookdaysContext context)
        {
            _context = context;
        }
        public IActionResult userlogin()
        {
            //if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_MEMBER))
            return View();
            //return View("Index");
        }

        public IActionResult pwdcheck(string email, string password)
        {
            var checkpwd = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (checkpwd != null)
            {
                return Json("True");
            }
            else
            {
                return Json("False");
            }

        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(User new_user)
        {
        
            if (string.IsNullOrEmpty(new_user.Username))
            {
                return BadRequest("Registration failed: Username cannot be empty");
                //new_user.Username =
                //"註冊失敗 使用者姓名不能為空，請重新輸入";
                //if (string.IsNullOrEmpty(new_user.Password))
                //{
                //    new_user.Password = "註冊失敗 密碼不能為空";
                //    return View();
                //}
                //return Ok("LogIn");
            }

            if (new_user.RoleId == 0)
            {
                new_user.RoleId = 1;
            }

          // 新資料傳入資料庫中
                _context.Users.Add(new_user);
                _context.SaveChanges();
                return Ok("註冊成功");

        }


        public IActionResult checkaccount(string email)
        {

            // 檢查 _context.Members 中是否存在一個成員的名稱等於傳入的 name 參數。 如果存在，member 將被設置為 true，否則為 false。
            var users = _context.Users.Any(x => x.Email == email);

            return Content(users.ToString(), "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult Index()
        {
            //防宵小
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_MEMBER))
                return View();
            return View("LogIn");
        }
    }
}
