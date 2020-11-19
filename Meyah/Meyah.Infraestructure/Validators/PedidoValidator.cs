using FluentValidation;
using Meyah.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Infraestructure.Validators
{
    public  class PedidoValidator : AbstractValidator <PedidoRequestDto>
    {
        public PedidoValidator()
        {           
            //RuleFor(pedido => pedido.Fechapedido).LessThanOrEqualTo(DateTime.Today);
            //RuleFor(pedido => pedido.Fechaentrega).GreaterThan(pedido => pedido.Fechapedido);
            //RuleFor(pedido => pedido.Cantidad).NotNull().GreaterThan(0);
            //RuleFor(pedido => pedido.Precio).NotNull().GreaterThan(0);
        }
    }
}
