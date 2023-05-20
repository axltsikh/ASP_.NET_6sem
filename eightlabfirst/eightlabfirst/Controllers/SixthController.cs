using eightlabfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eightlabfirst.Controllers
{
    public class SixthController : Controller
    {
        IPhoneDictionary repository;
        public SixthController(IPhoneDictionary rep)
        {
            repository = rep;
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
