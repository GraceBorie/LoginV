using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LoginV.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace LoginV.Models
{
    public class db
    {
        private SqlConnection con = new SqlConnection("Server = tcp:gjir - tech.database.windows.net, 1433; Initial Catalog = flamom; Persist Security Info=False;User ID = gjiradmin; Password=fla-mom123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");
        public int LoginCheck(AD_login ad) {
            int res = -1;

            using (SqlCommand com = new SqlCommand("SP_Login", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("AD_id", ad.AD_id);
                com.Parameters.AddWithValue("AD_password", ad.AD_password);
                SqlParameter oblogin = new SqlParameter();
                oblogin.ParameterName = "@IsValid";
                oblogin.SqlDbType = SqlDbType.Bit;
                oblogin.Direction = ParameterDirection.Output;
                com.Parameters.Add(oblogin);
                con.Open();
                com.ExecuteNonQuery();
                res = Convert.ToInt32(oblogin.Value);
                con.Close();
            }
            return res;
        }

    }
}
