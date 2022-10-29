using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backend_app.Models;

namespace backend_app.Controllers
{  

    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;


        [HttpPost]
        [Route("Registration")]

        public string Registration(user user)
        {

            string msg = string.Empty;

            try
            {
                cmd = new SqlCommand("usp_Registration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Dob", user.Dob);
                cmd.Parameters.AddWithValue("@Contact", user.Contact);
                cmd.Parameters.AddWithValue("@EmailID", user.EmailID);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@State", user.State);
                cmd.Parameters.AddWithValue("@District", user.District);
                cmd.Parameters.AddWithValue("@Ward", user.Ward);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ISActive", user.ISActive);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    msg = "Data Inserted";
                }
                else
                {
                    msg = "insertion error";
                }


            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;

        }

        [HttpPost]
        [Route("Login")]

        public string Login(user user)
        {

            string msg = string.Empty;

            try
            {
                da = new SqlDataAdapter("usp_Login", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@EmailID", user.EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Password", user.Password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    msg = "User is valid";
                }
                else
                {
                    msg = "user not registered";
                }


            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;

        }
    }
}
