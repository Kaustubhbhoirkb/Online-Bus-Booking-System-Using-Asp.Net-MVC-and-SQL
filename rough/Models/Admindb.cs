using System.Data;
using System.Data.SqlClient;

namespace rough.Models
{
    public class Admindb
    {
        public static int LoginCheck(Admin ad1)
        {
            //SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlConnection con = new SqlConnection(GetConString.ConString());

            SqlCommand com = new SqlCommand("adminprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Admin_id", ad1.Admin_id);
            com.Parameters.AddWithValue("@Password", ad1.Password);
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
