using Microsoft.AspNetCore.Mvc;
using RepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eightlabfirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebController : Controller
    {
        IPhoneDictionary phoneDictionary;
        public WebController(IPhoneDictionary dictionary)
        {
            this.phoneDictionary = dictionary;
        }
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return phoneDictionary.GetBookList();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return phoneDictionary.GetByID(id);
        }

        [HttpPost]
        public Contact Post([FromBody] Contact value)
        {
            phoneDictionary.Add(value);
            return value;
        }

        [HttpPut]
        public void Put([FromBody] Contact value)
        {
            phoneDictionary.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            phoneDictionary.DeleteByID(id);
        }
    }
}
