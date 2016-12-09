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
    public class ViewModelParaDominioProfile : Profile
    {

        protected override void Configure()
        {
            Mapper.CreateMap<JogoEdicaoViewModel, Jogo>();
            Mapper.CreateMap<JogadorEdicaoViewModel, Jogador>()
                .ForMember(dest => dest.Nome, opt =>
                {
                    opt.MapFrom(source => source.Nome.Split(' ')[0].Trim());
                })
                .ForMember(dest => dest.Sobrenome, opt =>
                {
                    opt.MapFrom(source => source.Nome.Split(' ')[1].Trim());
                });
        }
    }
}