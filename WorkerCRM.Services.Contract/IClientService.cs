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
    public interface IClientService
    {
        public Task<ClientDetailDto> GetById(int id);

        public List<ClientListDto> GetAll();
        public Task<string> Delete(int id);

        public Task AddClient(Client client);

        public void PutClient(int id, Client client);

        public void PutClientPhoto(int id, Client Client);
    }
}
