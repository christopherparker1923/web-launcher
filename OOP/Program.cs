using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string confirm = "n";
            int index = -1;
            Entry[] entries = GenerateEntries();

            while (confirm != "y")
            {
                var result = GetWebsite(entries);
                index = result.Item1;
                confirm = result.Item2;
            }

            Console.WriteLine("Exiting with final values: {0}, {1}, {2}", confirm, index, entries[index].name);
            Console.WriteLine("url: {0}", entries[index].url);
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", entries[index].url);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    Console.WriteLine(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                Console.WriteLine(other.Message);
            }
        }

        static Tuple<int, string> GetWebsite(Entry[] entries)
        {
            List<string> options = new List<string>();
            string user_input = "";
            bool first_iteration = true;
            int index = 0;

            foreach (Entry entry in entries)
            {
                options.Add(entry.key);
                index++;
            }


            while (!options.Contains(user_input))
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
                foreach (Entry entry in entries)
                {
                    Console.WriteLine("\t{0}-{1}", entry.key, entry.name);
                }
                user_input = Console.ReadLine();
                first_iteration = false;
                
            }

            Console.WriteLine("Input: {0}", user_input);
            Console.WriteLine("y to confirm, n to cancel");
            string confirm = Console.ReadLine();
            index = Array.IndexOf(options.ToArray(), user_input);

            return Tuple.Create(index, confirm);
        }

        static Entry[] GenerateEntries()
        {
            Entry[] entries = new Entry[3];
            entries[0] = new Entry("https://www.google.com/", "google", "g");
            entries[1] = new Entry("https://www.youtube.com/", "youtube", "y");
            entries[2] = new Entry("https://www.facebook.com/", "facebook", "f");

            return entries;
        }
    }
}

