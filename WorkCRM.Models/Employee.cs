using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BirthDay { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<EmployeeContact> EmployeeContact {get;set;}


    }
}
