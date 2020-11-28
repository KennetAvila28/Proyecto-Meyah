using FluentValidation;
using System;
using Meyah.Domain.DTOs;

namespace Meyah.Infraestructure.Validators
{
    public class EmpleadoValidator : AbstractValidator<EmpleadoRequestDto>
    {
        public EmpleadoValidator()
        {
            //crea un regla para el empleado, que no acepte datos nulos
            RuleFor(empleado => empleado.Nombreemp).NotNull().Length(3, 25);
            RuleFor(empleado => empleado.Apellidoem).NotNull().Length(3, 25);
            RuleFor(empleado => empleado.Telefono).NotNull().Length(10);
            //lessthan, que sea menor al dia de hoy
            RuleFor(empleado => empleado.Fechanacimiento).NotNull().LessThan(DateTime.Now);
        }
    }
}
