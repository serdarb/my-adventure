using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MyAdventure.Entities;

namespace MyAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var prmNodeId = AskForNode();

            int nodeId;
            if (!int.TryParse(prmNodeId, out nodeId))
            {
                Console.WriteLine("Please enter number");
            }

            var node = GetNodeInfo(nodeId);
            Console.WriteLine("you are on " + node.Name);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("room is in these conditions");
            foreach (var condition in node.Cases[0].Conditions)
            {
                Console.WriteLine(condition.FlagName + " : " + condition.IsOn);
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("room has these items");
            foreach (var item in node.Cases[0].Items)
            {
                Console.WriteLine(item.Name + " @ " + item.HotSpot.TopLeft + "x" + item.HotSpot.BottomRight);
            }
            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("room has these effects");
            foreach (var item in node.Cases[0].Effects)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(Environment.NewLine);

            //Serialize(node);

            Console.ReadLine();
        }

        private static Node GetNodeInfo(int nodeId)
        {

            var serializer = new XmlSerializer(typeof(Node));
            var stream = new StreamReader("batu.xml");
            var node = (Node)serializer.Deserialize(stream);
            stream.Close();

            return node;

            //return new Node
            //{
            //    Id = nodeId,
            //    Name = "tower",
            //    IsPanoramic = true,

            //    Cases = new List<Case>
            //    {
            //        new Case
            //        {
            //            Conditions = new List<Condition>
            //            {
            //                new Condition {FlagName = "TowerLight", IsOn = true},
            //                new Condition {FlagName = "Day5", IsOn = true},
            //                new Condition {FlagName = "DogLiving", IsOn = false}
            //            },

            //            PanoramaPhotos = new List<PanoramaPhoto>
            //            {
            //                new PanoramaPhoto{ Order = 1, Path = "/photo/panorama/node/1.png"},
            //                new PanoramaPhoto{ Order = 2, Path = "/photo/panorama/node/2.png"},
            //                new PanoramaPhoto{ Order = 3, Path = "/photo/panorama/node/3.png"},
            //                new PanoramaPhoto{ Order = 4, Path = "/photo/panorama/node/4.png"}
            //            },

            //            Transitions = new List<Transition>
            //            {
            //                new Transition
            //                {
            //                    From = 1,
            //                    To = 3,
            //                    Type = "Photo",
            //                    Path = "/photo/transition/1.png",
            //                    SoundPath = "/sound/transition/1.ogg",
            //                    TriggerHotSpot = new HotSpot {TopLeft = "100,85", BottomRight = "232,134"}
            //                },
            //                new Transition
            //                {
            //                    From = 1,
            //                    To = 5,
            //                    Type = "Video",
            //                    Path = "/video/transition/4.mov",
            //                    SoundPath = "/sound/transition/2.ogg",
            //                    TriggerHotSpot = new HotSpot {TopLeft = "400,85", BottomRight = "532,234"}
            //                }
            //            },

            //            Effects = new List<Effect>
            //            {
            //                new Effect
            //                {
            //                    Name = "Plane",
            //                    Type = "3D Effect",
            //                    SoundPath = "/sound/effect/5.ogg",
            //                    Detail ="???"
            //                },
            //                new Effect
            //                {
            //                    Name = "BirdSinging",
            //                    Type = "Sound",
            //                    SoundPath = "/sound/effect/15.ogg",
            //                    Detail ="???"
            //                },
            //                new Effect
            //                {
            //                    Name = "PhoneRinging",
            //                    Type = "Sound",
            //                    SoundPath = "/sound/effect/15.ogg",
            //                    Detail ="???"
            //                }
            //            },

            //            Items = new List<Item>
            //            {
            //                new Item
            //                {
            //                    Name = "Phone",
            //                    HotSpot = new HotSpot {TopLeft = "100,85", BottomRight = "232,134"}
            //                }
            //            }
            //        },
            //        new Case
            //        {
            //            Conditions = new List<Condition>
            //            {
            //                new Condition {FlagName = "TowerLight", IsOn = false},
            //                new Condition {FlagName = "Day2", IsOn = true},
            //                new Condition {FlagName = "CatLiving", IsOn = true},
            //                new Condition {FlagName = "Pen56InventoryStatus", IsOn = true},
            //                new Condition {FlagName = "Pen56IsAviable", IsOn = true},
            //            },

            //            PanoramaPhotos = new List<PanoramaPhoto>
            //            {
            //                new PanoramaPhoto{ Order = 1, Path = "/photo/panorama/node/5.png"},
            //                new PanoramaPhoto{ Order = 2, Path = "/photo/panorama/node/6.png"},
            //                new PanoramaPhoto{ Order = 3, Path = "/photo/panorama/node/7.png"},
            //                new PanoramaPhoto{ Order = 4, Path = "/photo/panorama/node/8.png"}
            //            },

            //            Transitions = new List<Transition>
            //            {
            //                new Transition
            //                {
            //                    From = 1,
            //                    To = 3,
            //                    Type = "Photo",
            //                    Path = "/photo/transition/1.png",
            //                    SoundPath = "/sound/transition/1.ogg",
            //                    TriggerHotSpot = new HotSpot {TopLeft = "100,85", BottomRight = "232,134"}
            //                },
            //                new Transition
            //                {
            //                    From = 1,
            //                    To = 5,
            //                    Type = "Video",
            //                    Path = "/video/transition/4.mov",
            //                    SoundPath = "/sound/transition/2.ogg",
            //                    TriggerHotSpot = new HotSpot {TopLeft = "400,85", BottomRight = "532,234"}
            //                }
            //            }
            //        }
            //    }
            //};
        }

        private static string AskForNode()
        {
            Console.WriteLine("Please enter number");
            return Console.ReadLine();
        }

        public static void Serialize(Node item)
        {
            var serializer = new XmlSerializer(typeof(Node));
            var tw = new StreamWriter("batu.xml");
            serializer.Serialize(tw, item);
            tw.Close(); 
        }
    }
}
