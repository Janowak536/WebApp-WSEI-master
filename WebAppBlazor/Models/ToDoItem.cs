using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBlazor
{
    public class ToDoItem 
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nazwa { get; set; } = "";
        public bool Stan { get; set; } = false;
    }
}
