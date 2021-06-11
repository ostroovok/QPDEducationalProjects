﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinthThemeSolution.Models
{
    public class HelloPhraseRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public List<HelloPhrase> Responses { get; set; }
    }
}
