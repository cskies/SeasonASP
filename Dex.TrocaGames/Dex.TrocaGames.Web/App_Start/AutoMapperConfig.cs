using AutoMapper;
using Dex.TrocaGames.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dex.TrocaGames.Web.App_Start
{
    public class AutoMapperConfig 
    {
        public static void RegisterMappers()
        {
            Mapper.AddProfile(new DominioParaViewModelProfile());
            Mapper.AddProfile(new ViewModelParaDominioProfile());
        }
    }
}