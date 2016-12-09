using AutoMapper;
using Dex.TrocaGames.Dominio;
using Dex.TrocaGames.Web.ViewModels.Jogador;
using Dex.TrocaGames.Web.ViewModels.Jogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Jogo, JogoViewModel>();
            Mapper.CreateMap<Jogo, JogoEdicaoViewModel>();
            Mapper.CreateMap<Jogador, JogadorViewModel>()
                .ForMember(dest => dest.Nome, opt =>
                {
                    opt.MapFrom(source => source.Nome + " " + source.Sobrenome);
                })
                .ForMember(dest => dest.Jogo, opt =>
                {
                    opt.MapFrom(source => source.Jogo.Nome);
                });

            Mapper.CreateMap<Jogador, JogadorEdicaoViewModel>()
                .ForMember(dest => dest.Nome, opt =>
                {
                    opt.MapFrom(source => source.Nome + " " + source.Sobrenome);
                })
                .ForMember(dest => dest.JogoId, opt =>
                {
                    opt.MapFrom(source => source.Jogo.Id);
                });
        }
    }
}