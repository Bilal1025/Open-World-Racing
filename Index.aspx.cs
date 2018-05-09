using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace WebApplication3
{
    public partial class Player : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void setWinner(string name)
        {
            HttpContext.Current.Session["state"] = name;
        }
        [WebMethod]
        public static string getState()
        {
            try
            {
                return HttpContext.Current.Session["state"].ToString();
            }
            catch
            {
                return "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
                return;
            Response.Redirect("WebForm1.aspx?name=" + TextBox1.Text);
        }
    }
}