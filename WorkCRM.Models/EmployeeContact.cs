using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class EmployeeContact
    {
        public int EmployeeId { get; set; }
        public int TypeContactId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual TypeContact TypeContact { get; set; }
        public string Value { get; set; }
    }
}
