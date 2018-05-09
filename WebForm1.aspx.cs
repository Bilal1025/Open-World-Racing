using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string constr = @"Server=tcp:secureit.database.windows.net,1433;Initial Catalog=Secureit;Persist Security Info=False;User ID=Bilal;Password=QW[]14zx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetIp()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("getip", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@ip", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                return cmd.Parameters["@ip"].Value.ToString();
            }
            catch
            {
                return "-1";
            }
            finally
            {
                con.Close();
            }
        }
    }
}