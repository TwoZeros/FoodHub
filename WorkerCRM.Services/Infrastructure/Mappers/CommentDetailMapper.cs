using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers.Interfaces;

namespace WorkerCRM.Services.Infrastructure.Mappers
{

    public interface ICommentDetailMapper : IModelMapper<CommentDetailDto, Comment>
    {
    }

    class CommentDetailMapper : AbstractModelMapper<CommentDetailDto, Comment>, ICommentDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDetailDto, Comment>();

                cfg.CreateMap<Comment, CommentDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
