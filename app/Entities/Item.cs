using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyAdventure.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public HotSpot HotSpot { get; set; }
    }
}