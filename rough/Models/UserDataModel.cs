using System.Data.SqlClient;
using System.Data;

namespace rough.Models
{
    public class UserDataModel
    {
        

        public string Name { get; set; }
        public string Admin_Id { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Mobile_No { get; set; }
        public string Security_question { get; set; }
        public string Answer { get; set; }
        public int Ewallet { get; set; }

        public int TicketId { get; set; }

        public int SaveDetails()
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            con.Open();

            string query = "INSERT INTO cust_login(Name,Admin_Id,Password,Age,City,Gender,Mobile_No,Email,Security_question,Answer,Ewallet) values('" + Name + "','" + Admin_Id + "','" + Password + "','" + Age + "','" + City + "','" + Gender + "','" + Mobile_No + "','" + Email + "','" + Security_question + "','" + Answer + "','" + Ewallet + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
