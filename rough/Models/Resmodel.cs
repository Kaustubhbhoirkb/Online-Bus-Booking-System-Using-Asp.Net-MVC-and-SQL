using System.Data;
using System.Data.SqlClient;

namespace rough.Models
{
    public class Resmodel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string MailSub { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Mailbody { get; set; }
        public string Mobile_No { get; set; }
        public int Amount { get; set; }
        public string ModeOP { get; set; }

        public int BusID { get; set; }
        public int TicketId { get; set; }
       
        public int SaveDetails()
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            string query = "INSERT INTO reservation(Name,Email,MailSub,Age,City,Mailbody,Mobile_No,ModeofPayment,Amount_Received,BusId) values('" + Name + "','" + Email + "','" + MailSub + "','" + Age + "','" + City + "','" + Mailbody + "','" + Mobile_No + "','" + ModeOP + "','" + Amount + "','" + BusID + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}