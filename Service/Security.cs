using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public static class Security
    {
        public static bool ActiveSession(object usuario)
        {
            User user = usuario != null ? (User)usuario : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }

        public static bool IsAdmin(object usuario)
        {
            User user = usuario != null ? (User)usuario : null;
            return user != null ? user.Admin : false;
        }
    }
}
