﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract.Dto
{
    public class CommentDetailDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string CreateDate { get; set; }
        public string Text { get; set; }
        public int Karma { get; set; }
    }
}