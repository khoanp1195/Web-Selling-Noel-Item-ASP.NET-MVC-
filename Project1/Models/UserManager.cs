using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Project1.Models
{
    public class UserManager
    {
        Model1 model = new Model1();
        public Boolean checkUsername(string Username)
        {
            List<KHACHHANG> UserName = (from user in model.KHACHHANGs where user.Ten == Username select user).ToList();
            if (UserName.Count == 1)
            {
                return false;
            }
            return true;
        }

        public Boolean checkEmail(string Email)
        {
            List<KHACHHANG> email = (from user in model.KHACHHANGs where user.Email == Email select user).ToList();
            if (email.Count == 1)
            {
                return false;
            }

            return true;
        }
        public Boolean checkLogin(string Email, string pass)
        {
            Model1 model = new Model1();
            KHACHHANG email = model.KHACHHANGs.Where(user =>  user.Email==Email).FirstOrDefault();
            if (email!=null)
            {
                if (email.MK == Encrypt.MD5Hash(pass))
                    return true;
                 else return false;
            }

            return false;
        }
    }
}

