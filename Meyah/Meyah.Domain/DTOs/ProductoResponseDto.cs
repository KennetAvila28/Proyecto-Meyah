using System;
using System.Collections.Generic;
using System.Text;

namespace Meyah.Domain.DTOs
{
    public class ProductoResponseDto
    {
        public int ProductoId { get; set; }
        public string Nombreprod { get; set; }
        public decimal Precio { get; set; }
    }
}
