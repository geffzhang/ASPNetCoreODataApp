using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PersonController : ODataController
    {
        private readonly IHostingEnvironment _environment;
        private readonly PersonService _person;

        public PersonController(IHostingEnvironment environment)
        {
            this._environment = environment;
            this._person = new PersonService(this._environment.WebRootPath);
        }
        
        // url:odata/Person
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(this._person.GetAll());
        }

        //[EnableQuery]
        //public IActionResult Get(string key)
        //{
        //    return Ok(this._person
        //                    .GetAll()
        //                    .FirstOrDefault(x=>x.BusinessEntityID == key));
        //}
    }

}
