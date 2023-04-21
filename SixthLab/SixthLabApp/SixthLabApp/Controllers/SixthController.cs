using RepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Ninject.Web.Common;
using System.Diagnostics;

namespace SixthLabApp.Controllers
{
    public class SixthController : Controller
    {
        IPhoneDictionary repository;
        public SixthController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IPhoneDictionary>().To<ContactRepository>().InRequestScope();
            repository = ninjectKernel.Get<IPhoneDictionary>();
        }
        public ActionResult Index()
        {
            ViewBag.Contacts = repository.GetBookList();
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
            repository.Add(contact);
            return RedirectPermanent("~/Sixth");
        }
        [HttpGet]
        public ActionResult Update(int ID, string Name, string Phone)
        {
            var contact = new Contact(Name, Phone);
            contact.ID = ID;
            ViewBag.contact = contact;
            return View();
        }
        public ActionResult UpdateSave(Contact contact)
        {
            Debug.WriteLine(contact);
            repository.Update(contact);
            return RedirectPermanent("~/Sixth");
        }
        [HttpGet]
        public ActionResult Delete(int ID, string Name, string Phone)
        {
            var contact = new Contact(Name, Phone);
            contact.ID = ID;
            ViewBag.contact = contact;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(Contact contact)
        {
            repository.Delete(contact);
            return RedirectPermanent("~/Sixth");
        }
    }
}