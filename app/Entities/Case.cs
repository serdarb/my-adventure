using System.Collections.Generic;

namespace MyAdventure.Entities
{
    public class Case
    {
        public List<Condition> Conditions { get; set; }

        public List<string> PanoramaPhotos { get; set; }
        public List<Item> Items { get; set; }
        public List<Effect> Effects { get; set; }
        public List<Transition> Transitions { get; set; }
    }
}