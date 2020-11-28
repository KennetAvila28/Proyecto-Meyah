using AutoMapper;
using Meyah.Domain.DTOs;
using Meyah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Empleado, EmpleadoRequestDto>();
            CreateMap<Empleado, EmpleadoResponseDto>();
            CreateMap<EmpleadoRequestDto, Empleado>().AfterMap(
                ((source, destination) =>
                {
                    destination.Creado = DateTime.Now;
                    destination.UsuarioId = 1;

                }));

            CreateMap<EmpleadoResponseDto, Empleado>();
        }
    }
}
