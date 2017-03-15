using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkComplain.Models;
namespace NetworkComplain.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/
        NetworkComplaindbEntities db = new NetworkComplaindbEntities();
        public ActionResult Index(int p = 0, int pageSize = 10, string keyword = "", string sortBy = "")
        {
            List<Location> Locations = null;
            var _Total = 0;


            if (string.IsNullOrEmpty(keyword))
            {
                switch (sortBy)
                {
                    case "Name":
                        Locations = db.Locations.OrderBy(a => a.Name).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        Locations = db.Locations.OrderBy(a => a.Id).Skip(p * pageSize).Take(pageSize).Take(pageSize).ToList();
                        break;
                }
                _Total = db.Locations.Count();
            }
            else
            {
                keyword = keyword.ToLower();

                switch (sortBy)
                {
                    case "Name":
                        Locations = db.Locations.Where(s => s.Name.ToLower().Contains(keyword)).OrderBy
                            (z => z.Name).Skip(p * pageSize).Take(pageSize).ToList();
                        break;

                    default:
                        Locations = db.Locations.Where(a => a.Name.ToLower().Contains(keyword)).OrderBy
                            (a => a.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }

                _Total = db.Locations.Count(a => a.Name.ToLower().Contains(keyword));

            }

            LocationResult result = new LocationResult();
            result.Location = Locations;
            result.CurrentPage = p;
            result.PageSize = pageSize;
            result.TotalLocations = _Total;

            return View(result);
        }
        public ActionResult create()
        {
            return View();
        }

    }
}