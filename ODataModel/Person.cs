using System;
using System.ComponentModel.DataAnnotations;

namespace ODataModel
{
    public sealed class Person
    {
        [Key]
        public string BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
    }
}
