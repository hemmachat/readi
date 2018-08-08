using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Readify.Controllers
{
    [Produces("application/json")]
    [Route("api/Fibonacci")]
    public class FibonacciController : Controller
    {
        public UInt64 Get(int n)
        {
            UInt64 accumulate = 0;
            UInt64 prevFib = 1;
            UInt64 fib = accumulate + prevFib;

            if (n <= 2)
            {
                return (UInt64)n;
            }

            for (int position = 3; position <= n; position++)
            {
                accumulate = prevFib;
                prevFib = fib;
                fib = accumulate + prevFib;
            }

            return fib;
        }
    }
}