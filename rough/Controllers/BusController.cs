using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuickMailer;
using rough.Models;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace rough.Controllers
{
    public class BusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bus ob)
        {
            if (ModelState.IsValid)
            {
                var context = new BusContext();
                context.addbus.Add(ob);
                context.SaveChanges();
                ViewBag.a = "Inserted";
            }
            return View();
        }
        public IActionResult Display()
        {
            var context = new BusContext();
            IEnumerable<Bus> stu = context.addbus.ToList();
            return View(stu);
        }
        public IActionResult admindisplay()
        {
            var context = new BusContext();
            IEnumerable<Bus> stu = context.addbus.ToList();
            return View(stu);
        }
        public IActionResult DisplayOne(Bus obj)
        {
            var context = new BusContext();
            obj = context.addbus.Find(obj.Id); // To Find By Id 
            if (obj == null)
                ViewBag.Work = "Record Not Found";
            else
                ViewBag.Work = obj.Id + " " + obj.BusNumber + " " + obj.BusName + " " + obj.Source + " " + obj.Destination + " " + obj.Date + " " + obj.Arrival + " " + obj.Departure + " " + obj.TypeOfBus + " " + obj.ModelNumber + " " + obj.NumberOfSeats + " " + obj.Fare;
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Bus obj)
        {
            //if (ModelState.IsValid)
            //{
                var context = new BusContext();
                obj = context.addbus.Find(obj.Id);
            if (obj == null)
            {
                ViewBag.Work = "Record Not Found";
                return View();
            }
            else
            {
                context.addbus.Remove(obj);
                context.SaveChanges();
                ViewBag.Work = "Deleted";
              
                return View();
            }
            
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Bus obj)
        {
            var context = new BusContext();
            Bus emp = context.addbus.Find(obj.Id);

            if (emp == null)
                ViewBag.Work = "Record Not Found";
            else
            {
                emp.BusNumber = obj.BusNumber;
                emp.BusName = obj.BusName;
                emp.Source = obj.Source;
                emp.Destination = obj.Destination;
                emp.Date = obj.Date;
                emp.Arrival = obj.Arrival;
                emp.Departure = obj.Departure;
                emp.TypeOfBus = obj.TypeOfBus;
                emp.ModelNumber = obj.ModelNumber;
                emp.NumberOfSeats = obj.NumberOfSeats;
                emp.Fare = obj.Fare;
                context.SaveChanges();

                ViewBag.Work = "Updated";
            }
            return View();
        }
        public IActionResult adminprofile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult adminprofile([Bind] Admin ad)
        {
            int res = Admindb.LoginCheck(ad);
            if (res == 1)
            {
                return View("Employeeindex");
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
                return View();
            }
        }
        public IActionResult Employeeindex()
        {
            return View();
        }
        public IActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create1(Employee ob)
        {
            var context = new rough1Context();
            context.Employees.Add(ob);
            context.SaveChanges();
            ViewBag.a = "Inserted";
            return View();
        }
        public IActionResult Display1()
        {
            var context = new rough1Context();
            IEnumerable<Employee> stu = context.Employees.ToList();
            return View(stu);
        }
        public IActionResult DisplayOne1(Employee obj)
        {
            var context = new rough1Context();
            obj = context.Employees.Find(obj.Id);  // integer la find karnar fkat
            if (obj == null)
                ViewBag.Work = "Record Not Found";
            else
                ViewBag.Work = obj.Id + " " + obj.EmployeeId + " " + obj.Password + " " + obj.EmpName + " " + obj.Age + " " + obj.Salary + " " + obj.Gender;
            return View();
        }
        public IActionResult Delete1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete1(Employee obj)
        {
            var context = new rough1Context();
            obj = context.Employees.Find(obj.Id);
            if (obj == null)
            {
                ViewBag.Work = "Record not found";
                return View();
            }
            else
            {
                context.Employees.Remove(obj);
                context.SaveChanges();
                ViewBag.Work = "Deleted";
                return View();
            }
        }
        public IActionResult Update1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update1(Employee obj)
        {
            var context = new rough1Context();
            Employee emp = context.Employees.Find(obj.Id);
            if (emp == null)
                ViewBag.Work = "Record Not Found";
            else
            {
                emp.EmployeeId = obj.EmployeeId;
                emp.Password = obj.Password;
                emp.EmpName = obj.EmpName;
                emp.Age = obj.Age;
                emp.Salary = obj.Salary;
                emp.Gender = obj.Gender;
                context.SaveChanges();
                ViewBag.Work = "Record updated";
            }
            return View();
        }
        public IActionResult Employeeprofile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Employeeprofile([Bind] Employee ad)
        {
            int res = Employeedb.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "Welcome Employee..!";

                return RedirectToAction("Employeeindex1");
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
                return View();
            }
        }
        public IActionResult Employeeindex1()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDetails()
        {
            UserDataModel umodel = new UserDataModel();
            umodel.Name = HttpContext.Request.Form["txtName"].ToString();
            umodel.Admin_Id = HttpContext.Request.Form["txtAdmin_Id"].ToString();
            umodel.Password = HttpContext.Request.Form["txtPassword"].ToString();
            umodel.Age = Convert.ToInt32(HttpContext.Request.Form["txtAge"]);
            umodel.City = HttpContext.Request.Form["txtCity"].ToString();
            umodel.Gender = HttpContext.Request.Form["txtGender"].ToString();
            umodel.Email = HttpContext.Request.Form["Email"].ToString();
            umodel.Mobile_No = HttpContext.Request.Form["txtMobile_No"].ToString();
            umodel.Security_question = HttpContext.Request.Form["security"].ToString();
            umodel.Answer = HttpContext.Request.Form["Answer"].ToString();
            umodel.Ewallet = 0;
            int result = umodel.SaveDetails();
            if (result > 0)

            {
                ViewBag.Result = "data saved ";
            }
            else
            {
                ViewBag.Result = "something wrong";
            }
            return View("Profile");
        }
        public IActionResult login2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login2([Bind] UserDataModel ad)  //Model binding 
        {
            int res = DB1.LoginCheck(ad);
            if (res == 1)  // count(1)   -- count - non-null value
            {
                TempData["msg"] = "Welcome Customer";
                //return View("Userbus");
                return RedirectToAction("fromto");
                // object reference not set to an instance of an object
                //return RedirectToAction("Index");
            }
            else   // count(0)
            {
                TempData["msg"] = "Emailid or Password is wrong.!";
                return View();

            }
        }
        public IActionResult Userbus()
        {
            var context = new BusContext();
            IEnumerable<Bus> stu = context.addbus.ToList();
            return View(stu);
        }
        //public IActionResult fromto()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult fromto([Bind] fromto ad)
        //{

        //    return View();
        //}
        private readonly BusContext _context;
        

        public BusController(BusContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> fromto(string SearchString, string SearchString1,string SearchString2)
        {
            ViewData["key"] = SearchString;
            ViewData["key1"] = SearchString1;
            ViewData["key2"] = SearchString2;
            var books = from b in _context.addbus
                        select b;
            //var books1 = from b1 in _context.addbus
            //             select b1;
            if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchString1) && !String.IsNullOrEmpty(SearchString2))
            {
                books = books.Where(b => b.Source.Contains(SearchString) && (b.Destination.Contains(SearchString1)) && (b.Date.Contains(SearchString2)));
            }
            return View(await books.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> fromtonavbar(string SearchString, string SearchString1, string SearchString2)
        {
            ViewData["key"] = SearchString;
            ViewData["key1"] = SearchString1;
            ViewData["key2"] = SearchString2;
            var books = from b in _context.addbus
                        select b;
            //var books1 = from b1 in _context.addbus
            //             select b1;
            if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchString1) && !String.IsNullOrEmpty(SearchString2))
            {
                books = books.Where(b => b.Source.Contains(SearchString) && (b.Destination.Contains(SearchString1)) && (b.Date.Contains(SearchString2)));
            }
            return View(await books.AsNoTracking().ToListAsync());
        }

        public IActionResult Customerdata()
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            con.Open();
            SqlCommand com = new SqlCommand("select * from cust_login", con);
            SqlDataReader reader = com.ExecuteReader();
            var model = new List<CustomerData>();
            while (reader.Read())
            {
                var c = new CustomerData();
                c.Name = reader["Name"].ToString();
                c.Admin_Id = reader["Admin_Id"].ToString();
                c.Password = reader["Password"].ToString();
                c.Age = Convert.ToInt32(reader["Age"]);
                c.City = reader["City"].ToString();
                c.Gender = reader["Gender"].ToString();
                c.Mobile_No = reader["Mobile_No"].ToString();

                model.Add(c);
            }
            return View(model);
        }
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        ////        EmailClient.Controllers.EmailController.Send(EmailClient)
        ////EmailClient.Controllers.EmailController.Send(EmailClient)
        ////Microsoft.AspNetCore.Routing.Matching.DefaultEndpointSelector.ReportAmbiguity(CandidateState[] candidateState)
        public IActionResult Send(MailMessage mailMessage)
        {
            try
            {
                string mgs = "Email send failed.";
                Email email = new Email();
                bool isSend = email.SendEmail(mailMessage.To, Credential.Email, Credential.Password, mailMessage.Subject, mailMessage.Body);
                if (isSend)
                {
                    mgs = "Email has been send.";
                }
                ViewBag.Mgs = mgs;
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;   // to subject body empty & press send button
            }
            

        }

        public IActionResult forgetpass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult forgetpass(UserDataModel um)
        {
            SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlCommand com = new SqlCommand("fpass", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@password", um.Password);
            com.Parameters.AddWithValue("@Email", um.Email);
            com.Parameters.AddWithValue("@Mno", um.Mobile_No);
            com.Parameters.AddWithValue("@sque", HttpContext.Request.Form["security"].ToString());
            com.Parameters.AddWithValue("@ans", um.Answer);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            ViewBag.Password = "Password Changed Successfully";
            return View();
        }
        public IActionResult Seats()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Seats([Bind] Seats1 ad)
        {
            int res = Seatsdb.LoginCheck(ad);
            if (res == 1)
            {
                SqlConnection conn = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
                conn.Open();
                string query = "update seats set status='Booked' WHERE busid=@busid and seats=@seats";
                SqlCommand cmd = new SqlCommand(query, conn);
                string x = ad.Busid;
                string y = ad.Seats;
                cmd.Parameters.AddWithValue("@busid", x);
                cmd.Parameters.AddWithValue("@seats", y);
                //Payment Part
                SqlConnection con = new SqlConnection(GetConString.ConString());
                SqlCommand com = new SqlCommand("Finalpay", con);
                com.CommandType = CommandType.StoredProcedure;                        
                com.Parameters.AddWithValue("@mno", ad.Mobile_No);
                com.Parameters.AddWithValue("@amount", ad.amount);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                // if statement checks for successful payment and reserves the seat and sends to next page
                if (i == 1)
                {
                    // Updates Available seats
                    SqlConnection connn = new SqlConnection(GetConString.ConString());
                    SqlCommand comm = new SqlCommand("Updateseat", connn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@A", 1);
                    comm.Parameters.AddWithValue("@id", ad.Busid);
                    connn.Open();
                    comm.ExecuteNonQuery();
                    connn.Close();
                    //Marks seat as booked
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    TempData["msg"] = "Booked.!";
                    return View("Resdetails");
                }
                else
                {
                    TempData["msg"] = "Payment Failed,Insufficient Funds...!";
                }
                return View();
                //return RedirectToAction("booked");
            }
            else
            {
                TempData["msg"] = "Not available.!";
                return View();

            }
        }


        public IActionResult Canceltickets()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Canceltickets([Bind] Seats1 ad)
        {
            //string x = ad.Busid;
            //string y = ad.Seats;
            int res = Canceldb.LoginCheck(ad);
            if (res == 1)
            {
                SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
                con.Open();
                string query = "update seats set status='Available' WHERE busid=@busid and seats=@seats";
                SqlCommand cmd = new SqlCommand(query, con);

                string x = ad.Busid;
                string y = ad.Seats;
                cmd.Parameters.AddWithValue("@busid", x);
                cmd.Parameters.AddWithValue("@seats", y);

                cmd.ExecuteNonQuery();
                TempData["msg"] = "Ticket is Cancelled...!";
                return View();

            }
            else
            {
                TempData["msg"] = "No Such Booking Found...!";
                return View();

            }
        }


        public IActionResult Resdetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reservation()
        {
            Resmodel umodel = new Resmodel();
            umodel.BusID = Convert.ToInt32(HttpContext.Request.Form["txtbusid"]);
            umodel.Name = HttpContext.Request.Form["txtName"].ToString();
            umodel.Email = HttpContext.Request.Form["txtEmail"].ToString();
            umodel.MailSub = HttpContext.Request.Form["txtPassword"].ToString();
            umodel.Age = Convert.ToInt32(HttpContext.Request.Form["txtAge"]);
            umodel.City = HttpContext.Request.Form["txtCity"].ToString();
            umodel.Mailbody = HttpContext.Request.Form["txtGender"].ToString();
            umodel.Mobile_No = HttpContext.Request.Form["txtMobile_No"].ToString();
            umodel.ModeOP = HttpContext.Request.Form["txtmop"].ToString();
            umodel.Amount = Convert.ToInt32(HttpContext.Request.Form["txtamount"]);

            int result = umodel.SaveDetails();
            //if (result > 0)
            if (result > 0)
            {
                //mailMessage.To = umodel.Email;
                string mgs = "Email send failed.";
                Email email = new Email();
                bool isSend = email.SendEmail(umodel.Email, Credential.Email, Credential.Password, umodel.MailSub, umodel.Mailbody);
                if (isSend)
                {
                    mgs = "Email has been send.";
                }
                ViewBag.Result = "data saved ";
                TempData["msg"] = mgs;
            }
            else
            {
                TempData["msg"] = "something wrong";
            }

            return View("Resdetails");
        }
        public IActionResult Reservationdetails()
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            con.Open();
            SqlCommand com = new SqlCommand("select * from reservation", con);
            SqlDataReader reader = com.ExecuteReader();
            var model = new List<Resmodel>();

            while (reader.Read())
            {
                var c = new Resmodel();
                c.TicketId = Convert.ToInt32(reader["TicketId"]);
                c.BusID = Convert.ToInt32(reader["busid"]);
                c.Name = reader["Name"].ToString();
                c.Email = reader["Email"].ToString();
                //c.Password = reader["MailSub"].ToString();
                c.Age = Convert.ToInt32(reader["Age"]);   //already string madhe asato converting into int
                c.City = reader["City"].ToString();
                //c.Gender = reader["Mailbody"].ToString();
                c.Mobile_No = reader["Mobile_No"].ToString();
                c.ModeOP= reader["ModeOfPayment"].ToString();
                c.Amount = Convert.ToInt32(reader["Amount_Received"]);
                model.Add(c);
            }
            return View(model);

        }

        public IActionResult Ewallet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ewallet(UserDataModel ew)
        {
            SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlCommand com = new SqlCommand("Ewallet", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Mno", ew.Mobile_No);
            com.Parameters.AddWithValue("@Pass", ew.Password);
            com.Parameters.AddWithValue("@amount", ew.Ewallet);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            TempData["msg"] = "Amount Added To The Wallet";
            return View();
        }
        public IActionResult chkbal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult chkbal(UserDataModel um)
        {
            SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            String query = "Select * from cust_login where Mobile_No=@Mno and Password=@pass";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@Mno", um.Mobile_No);
            com.Parameters.AddWithValue("@Pass", um.Password);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();

            while (rdr.Read())
            {
                ViewBag.a = "Your Current Ewallet Balance Is : " + rdr[10].ToString();
            }
            return View();
           

        }

        public IActionResult Refund()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Refund(UserDataModel um)
        {
            SqlConnection con = new SqlConnection("Data Source=NSL-LTRG030\\SQLEXPRESS19;Initial Catalog=rough1;Integrated Security=True");
            SqlCommand com = new SqlCommand("Refund", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Mno", um.Mobile_No);
            com.Parameters.AddWithValue("@email", um.Email);
            com.Parameters.AddWithValue("@amount", um.Ewallet);
            com.Parameters.AddWithValue("@tno", um.TicketId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            TempData["msg"] = "Refund Successful";
            return View();
        }
        public IActionResult Canceldetails()
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            con.Open();
            SqlCommand com = new SqlCommand("select * from cancelreq", con);
            SqlDataReader reader = com.ExecuteReader();
            var model = new List<Cancelticket>();

            while (reader.Read())
            {
                var c = new Cancelticket();
                c.Busid = Convert.ToInt32(reader["busid"]);
                c.Name = reader["Name"].ToString();
                c.Email = reader["Email"].ToString();               
                c.Mobile_No = reader["Mobile_No"].ToString();
               
                model.Add(c);
            }
            return View(model);

        }      
    }
}

