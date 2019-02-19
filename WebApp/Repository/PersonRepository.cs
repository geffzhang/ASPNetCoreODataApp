using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ODataModel;

namespace WebApp
{
    public class PersonRepository
    {
        private readonly string _webRootPath = string.Empty;
        private readonly string _csvFilePath = @"data\data.csv";

        public PersonRepository(string webRootPath)
        {
            this._webRootPath = webRootPath;
        }

        public IQueryable<Person> GetAll()
        {
            var _fullPath = this.GetFullPath();
            var _persons = this.GetPersonFromCsv(_fullPath);

            return _persons.AsQueryable();
        }

        private IEnumerable<Person> GetPersonFromCsv(string path)
        {
            var _content = File.ReadAllText(path);

            List<Person> _persons;
            Person _person;

            _persons = new List<Person>();

            using (StringReader _stringReader = new StringReader(_content))
            {
                using (CsvReader _reader = new CsvReader(_stringReader))
                {
                    while (_reader.Read())
                    {
                        _person = new Person();
                        _person.BusinessEntityID = _reader.GetField(0);
                        _person.PersonType = _reader.GetField(1);
                        _person.FirstName = _reader.GetField(2);
                        _person.MiddleName = _reader.GetField(3);
                        _person.LastName = _reader.GetField(4);
                        _person.EmailAddress = _reader.GetField(5);
                        _person.Gender = _reader.GetField(6);
                        _person.BirthDate = _reader.GetField(7);

                        _persons.Add(_person);
                    }
                }
            }

            return _persons;
        }

        private string GetFullPath()
        {
            return Path.Combine(this._webRootPath, this._csvFilePath);
        }
    }
}
