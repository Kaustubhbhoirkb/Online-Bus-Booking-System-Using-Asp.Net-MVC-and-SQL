using System.Data;
using System.Data.SqlClient;

namespace rough.Models
{
    public class Employeedb
    {
        public static int LoginCheck(Employee ad1)
        {
            //
            //SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlConnection con = new SqlConnection(GetConString.ConString());

            SqlCommand com = new SqlCommand("employeelogin", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Employee_id", ad1.EmployeeId);
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
