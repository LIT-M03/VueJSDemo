using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueJS.Data;

namespace MVCVueJs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            return Json(new PersonRepo().GetPeople(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            new PersonRepo().Add(person);
            return Json(person);
        }

        [HttpPost]
        public void Delete(int id)
        {
            new PersonRepo().Delete(id);
        }

        [HttpPost]
        public void Update(Person person)
        {
            new PersonRepo().Update(person);
        }
    }
}
