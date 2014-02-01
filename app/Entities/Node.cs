using System.Collections.Generic;

namespace MyAdventure.Entities
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsPanoramic { get; set; }

        public List<Case> Cases { get; set; }
    }
}