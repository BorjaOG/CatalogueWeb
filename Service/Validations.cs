using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Service
{
    public static class Validations
    {
        public static bool emptyText(object control)
        {
            if(control is TextBox )
            {
                if (string.IsNullOrEmpty(((TextBox)control).Text))
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}

