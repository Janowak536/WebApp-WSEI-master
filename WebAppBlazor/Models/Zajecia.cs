using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBlazor
{
    public class Zajecia
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nazwa { get; set; } = "";
        public DateTime Data { get; set; } 
        public int Uczestnicy { get; set; } = 0;
        public int UczestnicyMax { get; set; } = 10;
    }
}
