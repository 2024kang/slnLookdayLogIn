using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjLookdayLogIn.Models;
using prjLookdayLogIn.ViewModel;
using Register_and_login_test;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
            return View();
        }

        public IActionResult pwdcheck(string email, string password)
        {
            //是 LINQ 中的一個方法，用於查詢序列中符合指定條件的唯一一個元素
            //如果沒有符合條件的使用者，則 users 變數將為 null
            var users = _context.Users.SingleOrDefault(x => x.Email == email);

            if (users != null)
            {
                //使用CCryptography.VerifyPassword方法驗證密碼
                bool isPasswordValid = CCryptography.VerifyPassword(password, users.Password, "gugubird");

                if (isPasswordValid) 
                {
                    return Json("True");
                }

                
            }
             
            return Json("False");

        }



        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(User new_user)
        {
        
            if (string.IsNullOrEmpty(new_user.Username) || string.IsNullOrEmpty(new_user.Email) || string.IsNullOrEmpty(new_user.Password))
            {
                return BadRequest("姓名、電子信箱、密碼不能為空");
            }

            string hashedPassword = CCryptography.HashPasswordWithSalt(new_user.Password);
            new_user.Password = hashedPassword;

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
            ////var users = _context.Users.Any(x => x.Email == email);

            ////return Content(users.ToString(), "text/plain", System.Text.Encoding.UTF8);

            // 检查数据库中是否存在具有特定邮箱的用户
            bool userExists = _context.Users.Any(x => x.Email == email);
            return Content(userExists.ToString(), "text/plain", System.Text.Encoding.UTF8);
        }

    }
}
