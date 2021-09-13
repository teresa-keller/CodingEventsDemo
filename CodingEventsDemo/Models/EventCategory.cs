using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    {
        public int Id;
        public string Name;

        public EventCategory() { }
        public EventCategory(string name)
        {
            Name = name;
        }
    }
}
