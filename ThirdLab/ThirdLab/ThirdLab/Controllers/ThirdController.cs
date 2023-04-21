using System.Web.Mvc;
using ThirdLab.Models;

namespace ThirdLab.Controllers
{
    public class DictController : Controller
    {
        Phonebook phonebook = new Phonebook();
        public ActionResult Index()
        {
            ViewBag.Contacts = phonebook.Load();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(Contact contact)
        {
            phonebook.addContact(contact);
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
            phonebook.updateContact(contact);
            return RedirectPermanent("~/Dict");
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            ViewBag.ContactID = ID;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(Contact contact)
        {
            phonebook.deleteContact(contact);
            return RedirectPermanent("~/Dict");
        }   

        public ActionResult UnhandledRoutes()
        {
            int buffer = 0;
            for(int i = 0; i < Request.RawUrl.Length; i++)
            {
                if (Request.RawUrl[i] == '=')
                    buffer = i+1;
            }
            string uriBuffer = Request.RawUrl.Substring(buffer);
            return Content(Request.HttpMethod + ": " + uriBuffer + " не поддерживается"); 
        }
    }
}