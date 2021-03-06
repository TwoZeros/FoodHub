﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers;

namespace WorkerCRM.Services
{

    public class ClientService : IClientService
    {
        public IClientRepository _repo;

        private readonly IClientDetailMapper _detailMapper;
        private readonly IClientListMapper _listMapper;
        public ClientService(IClientRepository repo, IClientDetailMapper detailMapper, IClientListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;

        }

        public async Task<ClientDetailDto> GetById(int id)
        {
            var client = await _repo.GetClientInfo(id);
            var clientDto = _detailMapper.Map<Client, ClientDetailDto>(client);

            return clientDto;
        }

        public List<ClientListDto> GetAll()
        {
            var client = _repo.GetListClient();
            return _listMapper.Map<List<Client>, List<ClientListDto>>(client);
        }

        public async Task<string> Delete(int id)
        {
            var employee = await _repo.GetClientInfo(id);
            if (employee != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";

        }
        public async Task AddClient(Client client)
        {
            client.CreatedDate = DateTime.Now;
            _repo.Add(client);
            await _repo.SaveAsync();
        }

        public void PutClient(int id, Client client)
        {
            _repo.PutClient(client);
        }
        public void PutClientPhoto(int id, Client client)
        {
            _repo.PutClientPhoto(client);
        }
    }
}
