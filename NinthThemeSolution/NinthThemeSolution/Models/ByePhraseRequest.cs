using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinthThemeSolution.Models
{
    public class ByePhraseRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public List<ByePhrase> Responses { get; set; }
    }
}
