using System.Diagnostics;
using System.Web.Mvc;
using ThirdLab.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace ThirdLab.Controllers
{
    public class DictController : Controller
    {
        ContactContext contactContext = new ContactContext();
        public ActionResult Index()
        {
            return View(contactContext.Contacts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(Contact contact)
        {
            Debug.WriteLine(contact.ID);
            Debug.WriteLine(contact.Name);
            Debug.WriteLine(contact.Phone);
            contactContext.Contacts.Add(contact);
            contactContext.SaveChanges();
            return RedirectPermanent("~/Dict");
        }
        [HttpGet]
        public ActionResult Update(int ID,string Name,string Phone)
        {
            ViewBag.ContactID = ID;
            ViewBag.ContactName = Name;
            ViewBag.ContactPhone = Phone;
            return View();
        }
        public ActionResult UpdateSave(Contact contact)
        {
            contactContext.Entry(contact).State = EntityState.Modified;
            contactContext.SaveChanges();
            return RedirectPermanent("~/Dict");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            ViewBag.ContactID = ID;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(int ID)
        {
            contactContext.Entry(new Contact(ID)).State = EntityState.Deleted;
            contactContext.SaveChanges();
            return RedirectPermanent("~/Dict");
        }   

        public ActionResult UnhandledRoutes()
        {
            return Content(Request.HttpMethod + ": " + Request.Path  + " не поддерживается"); 
        }
    }
}