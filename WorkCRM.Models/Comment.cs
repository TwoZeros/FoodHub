using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public Client Client { get; set; }

        public DateTime CreateDate { get; set; }

        public string Text { get; set; }

        public int Karma { get; set; }

    }
}