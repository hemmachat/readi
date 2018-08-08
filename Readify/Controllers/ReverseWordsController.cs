using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Readify.Controllers
{
    [Produces("application/json")]
    [Route("api/ReverseWords")]
    public class ReverseWordsController : Controller
    {
        public string Get(string sentence)
        {
            var words = sentence.ToArray();
            var reverse = new StringBuilder();

            for(int index = words.Count() - 1; index >= 0; index--)
            {
                reverse.Append(words[index]);
            }

            return reverse.ToString();
        }
    }
}