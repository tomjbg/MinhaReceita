using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using minhareceita.domain.Models;
using minhareceita.api.Dtos;
using minhareceita.data.Contexto;

namespace minhareceita.api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            #region Receita
            CreateMap<Receita, ReceitaDto>().ReverseMap();
            #endregion

            #region Perfil
            CreateMap<Perfil, PerfilDto>().ReverseMap();
            CreateMap<Perfil, PerfilDto>()
                .ForMember(d => d.QtdComentarios, o => o.MapFrom(s => s.Comentarios.Count))
                .ForMember(d => d.QtdReceitas, o => o.MapFrom(s => s.Receitas.Count));
            #endregion



        }
    }
}