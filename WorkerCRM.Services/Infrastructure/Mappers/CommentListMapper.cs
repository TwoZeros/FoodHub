using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers.Interfaces;

namespace WorkerCRM.Services.Infrastructure.Mappers
{
    public interface ICommentListMapper : IModelMapper<CommentListDto, Employee>
    {
    }

    public class CommentListMapper : AbstractModelMapper<CommentListDto, Employee>, ICommentListMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentListDto, Comment>();

                cfg.CreateMap<Comment, CommentListDto>()
                .ForMember(x => x.CreateDate, s => s.MapFrom(x => x.CreateDate.ToString("d")))
                .ForMember(x => x.UserLogin, s => s.MapFrom(x => x.User.Login));

            });

            return config.CreateMapper();
        }
    }
}
