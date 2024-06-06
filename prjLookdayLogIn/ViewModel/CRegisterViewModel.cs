using prjLookdayLogIn.Models;

namespace prjLookdayLogIn.ViewModel
{
    public class CRegisterViewModel
    {
        public string txtUsername { get; set; }
        public string txtEmail { get; set; }

        public string txtPwd { get; set; }
        public string checkPwd { get; set; }

        public int roleID { get; set; }

        //// 导航属性
        //public Role Role { get; set; }

        //public class Role
        //{
        //    public int RoleID { get; set; }
        //    public string RoleName { get; set; }

        //    // 导航属性
        //    public ICollection<User> Users { get; set; }
        //}

    }
}
