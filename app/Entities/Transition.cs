using System.Collections.Generic;


namespace MyAdventure.Entities
{
    public class Transition
    {
        public int From { get; set; }
        public int To { get; set; }

        public string Type { get; set; }
        public string Path { get; set; }

        public string SoundPath { get; set; }

        public HotSpot TriggerHotSpot { get; set; }
    }
}