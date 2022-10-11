using System.Data;
using System.Data.SqlClient;

namespace rough.Models
{
    public class DB1
    {
        public static int LoginCheck(UserDataModel ad)
        {
            //SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlConnection con = new SqlConnection(GetConString.ConString());
            SqlCommand com = new SqlCommand("cust_login1", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", ad.Email);
            com.Parameters.AddWithValue("@Password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);  // count(1)  -- count - non-null value
            con.Close();
            return res;
        }
    }
}
