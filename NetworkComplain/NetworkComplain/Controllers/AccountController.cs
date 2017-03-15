using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetworkComplain.Controllers
{
    public class AccountController : Controller
    {

        NetworkComplaindbEntities db = new NetworkComplaindbEntities(); 

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            if (Request.Cookies["rememberme"] != null)
            {
                var id = Convert.ToInt32(Request.Cookies["rememberme"].Value);  

                var user = db.Users.FirstOrDefault(u => u.Id == id); 

                if (user != null) 
                {
                   
                    Session["email"] = user.Email;
                    Session["uid"] = user.Id;
                    Session["ut"] = user.Usertype.Name;
                    Session["name"] = user.Name;
                    return RedirectToAction("Index", "Home"); 
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password, bool rememberme = false)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) 
            {
                ViewBag.Error = "Invalid email/password";
                return View("Index");
            }
            else
            {
                //session banaya.
                Session["email"] = user.Email;
                Session["uid"] = user.Id;
                Session["ut"] = user.Usertype.Name;
                Session["name"] = user.Name;

                if (rememberme)
                {
                    Response.Cookies.Add(new HttpCookie("rememberme")
                    {
                        Domain = "localhost",
                        Expires = DateTime.Now.AddDays(1),
                        Name = "rememberme",
                        Value = user.Id.ToString()
                    });
                } 
                else
                {
                    Response.Cookies.Remove("rememberme");
                }
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Account");
        }

    }
}