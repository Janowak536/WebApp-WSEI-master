﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.DAL.Models
{
    public class Zajecia
    {
        
        public Zajecia(string nazwaZajec,DateTime terminZajec) 
        {
            NazwaZajec = nazwaZajec;
            TerminZajec = terminZajec;
        }
        public int Id { get; set; }
        public string NazwaZajec {get;set;}
        public DateTime TerminZajec { get; set; }
    }
    
}
