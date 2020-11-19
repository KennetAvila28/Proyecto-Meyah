using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meyah.API.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; private set; }

    }
}
