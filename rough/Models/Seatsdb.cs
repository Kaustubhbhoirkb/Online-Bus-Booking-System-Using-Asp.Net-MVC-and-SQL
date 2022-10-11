using System.Data;
using System.Data.SqlClient;

namespace rough.Models
{
    public class Seatsdb
    {
        public static int LoginCheck(Seats1 ad)
        {
            //SqlConnection con = new SqlConnection(GetConString.ConString());
            SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlCommand com = new SqlCommand("seatsprocedure", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@busid", ad.Busid);
            com.Parameters.AddWithValue("@seats", ad.Seats);
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