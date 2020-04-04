using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract.Dto
{
    public class ClientDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string BirthDay { get; set; }
        public string Created { get; set; }
        public string Photo { get; set; }
    }
}
