using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using LoginModule.Models;

namespace LoginModule.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5NOVF6P ;Initial Catalog=Login;Integrated Security=True");
        public int LoginCheck(Login ad)
        {
            SqlCommand com = new SqlCommand("Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", ad.UserName);
            com.Parameters.AddWithValue("@Password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
    }

