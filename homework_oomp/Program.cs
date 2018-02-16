using System;

namespace homework_oomp
{
    class Program
    {
        private const string Wet = @"#Wet";
        private const string Time = @"#Time";
        private const string Node = @"#Node";
        private const string fakeHeader = "somerandomstring";
        private const string payload = "{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}";
        static void Main(string[] args)
        {
            MsgProcessor processor = new MsgProcessor();
            do
            {
                Console.WriteLine("Please enter #Wet, #Time, or #Node to create test message");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "#Wet":
                        WetMsg Wmsg = new WetMsg(fakeHeader, payload);
                        processor.Add(Wmsg);
                        break;
                    case"#Time":
                        TimeMsg Tmsg = new TimeMsg(fakeHeader, payload);
                        processor.Add(Tmsg);
                        break;
                    case "#Node":
                        NodeMsg Nmsg = new NodeMsg(fakeHeader, payload);
                        processor.Add(Nmsg);
                        break;
                    default:
                        Console.WriteLine("Please enter #Wet, #Time, or #Node. Please try again");
                        input = Console.ReadLine();
                        break;
                }
            } while (processor.Digest.Count < 5);
            Console.WriteLine($"Queue count:\t{processor.Digest.Count}\n Clear queue? y/n");
            string clearSwitch = Console.ReadLine();
            if(clearSwitch == "y")
            {
                processor.Clear();
                Console.WriteLine($"Queue cleared.\nQueue count:\t{ processor.Digest.Count}\nPress Any Key To Close.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Queue count:\t{ processor.Digest.Count}\nPress any key to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }


        }
    }
}
