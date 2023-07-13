using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string confirm = "n";
            string user_input = "";

            while (confirm != "y")
            {
                var result = GetWebsite();
                confirm = result.Item1;
                user_input = result.Item2;
            }


            Console.WriteLine("End confirm, user_input: {0}, {1}", confirm, user_input);
        }

        static Tuple<string, string> GetWebsite()
        {
            string[] options = { "g", "y", "f" };
            string user_input = "";
            bool first_iteration = true;


            while (Array.IndexOf(options, user_input) == -1)
            {
                if (first_iteration)
                {
                    Console.WriteLine("Press a key to open a website\n");
                }
                else
                {
                    Console.WriteLine("Please choose a valid option\n");
                }
                Console.WriteLine("Options:");
                Console.WriteLine("\tg-google");
                Console.WriteLine("\tf-facebook");
                Console.WriteLine("\ty-youtube");
                user_input = Console.ReadLine();
                first_iteration = false;
                
            }

            Console.WriteLine("Input: {0}", user_input);
            Console.WriteLine("y to confirm, n to cancel");
            string confirm = Console.ReadLine();

            return Tuple.Create(confirm, user_input);
        }
    }
}
