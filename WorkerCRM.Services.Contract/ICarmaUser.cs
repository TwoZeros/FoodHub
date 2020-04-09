using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract
{
    public interface ICarmaUser
    {
        public Task CreateCarmaUser(CarmaUser carmaUser);
        public Task<string> GetByNumber(int number);
        public void PutCarmaUser(int number, CarmaUser carmaUser);
        public Task<string> Delete(int number);
    }
}