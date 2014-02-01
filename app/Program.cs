using System;
using System.IO;
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

            Console.ReadLine();
        }

        private static Node GetNodeInfo(int nodeId)
        {
            var serializer = new XmlSerializer(typeof(Node));
            var stream = new StreamReader("batu.xml");
            var node = (Node)serializer.Deserialize(stream);
            stream.Close();

            return node;
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
