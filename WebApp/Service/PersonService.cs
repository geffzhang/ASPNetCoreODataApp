using Microsoft.EntityFrameworkCore;
using ODataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class PersonService
    {
        private readonly PersonRepository _person;

        public PersonService(string webRootPath)
        {
            this._person = new PersonRepository(webRootPath);
        }

        public IQueryable<Person> GetAll()
        {
            return this._person.GetAll();
        }
    }
}
