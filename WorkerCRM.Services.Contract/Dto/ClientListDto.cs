﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Services.Contract.Dto
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDay { get; set; }
        public string Created { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

   
}
