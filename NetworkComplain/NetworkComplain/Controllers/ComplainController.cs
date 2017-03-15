using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetworkComplain.Models;
namespace NetworkComplain.Controllers
{
    public class ComplainController : Controller
    {
        NetworkComplaindbEntities db = new NetworkComplaindbEntities();
        public ActionResult Index(int p = 0, int pageSize = 10, string keyword = "", string sortBy = "")
        {
            List<Complain> Complains = null;
            var _Total = 0;


            if (string.IsNullOrEmpty(keyword))
            {
                switch (sortBy)
                {
                    case "ResolvedDate":
                        Complains = db.Complains.OrderBy(a => a.ResolvedDate).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        Complains = db.Complains.OrderBy(a => a.Title).Skip(p * pageSize).Take(pageSize).Take(pageSize).ToList();
                        break;
                }
                _Total = db.Complains.Count();
            }
            else
            {
                keyword = keyword.ToLower();

                switch (sortBy)
                {
                    case "ResolvedDate":
                        Complains = db.Complains.Where(s => s.Title.ToLower().Contains(keyword)).OrderBy
                            (z => z.ResolvedDate).Skip(p * pageSize).Take(pageSize).ToList();
                        break;

                    case "Title":
                        Complains = db.Complains.Where(s => s.Title.ToLower().Contains(keyword)).OrderBy
                            (z => z.ResolvedDate).Skip(p * pageSize).Take(pageSize).ToList();
                        break;

                    case "ComplainStatusId":
                        Complains = db.Complains.Where(s => s.Title.ToLower().Contains(keyword)).OrderBy
                            (z => z.ComplainStatusId).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                    default:
                        Complains = db.Complains.Where(a => a.Title.ToLower().Contains(keyword)).OrderBy
                            (a => a.Id).Skip(p * pageSize).Take(pageSize).ToList();
                        break;
                }

                _Total = db.Complains.Count(a => a.Title.ToLower().Contains(keyword));

            }

            ComplainResult result = new ComplainResult();
            result.complains = Complains;
            result.CurrentPage = p;
            result.PageSize = pageSize;
            result.TotalComplain = _Total;

            return View(result);
        }
        public ActionResult create()
        {
            return View();
        }

    }
}