using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPRTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string fileName = "../../" + "hw" + ".txt";
            //creating the file
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            Console.WriteLine("hw.txt created");
            fs.Close();

            StreamWriter sw = new StreamWriter(fileName);
            List<int> list = new List<int>();
            int val;
            Random r;
            int IntialCount = 1;
            int count = 50;
            int maxRandomValue = 1000;

            IPRTree<int> ipr = new IPRTree<int>();
            while (IntialCount <= count)
            {
                r = new Random();
                val = r.Next(maxRandomValue);
                if (!list.Contains(val))
                {
                    Node<int> newNode = new Node<int>(val);
                    ipr.ınsert(newNode, ipr.root);
                    list.Add(val);
                    sw.Write(val + " ");
                    IntialCount++;
                }

            }
            sw.Close();
            string[] the_array = list.Select(i => i.ToString()).ToArray();

            string[] lines2 = System.IO.File.ReadAllLines("../../hw.txt");
            // Display the file contents by using a foreach loop.
            System.Console.Write("\n\n\nIN-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                ipr.inOrderTraversal(ipr.root);
                break;
            }

            System.Console.Write("\n\n\nPRE-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                ipr.preOrderTraversal(ipr.root);
                break;
            }

            System.Console.Write("\n\n\nPOST-ORDER of hw.txt = ");


            foreach (string line2 in the_array)
            {
                // Use a tab to indent each line of the file.
                ipr.postOrderTraversal(ipr.root);
                break;
            }
            System.Console.ReadKey();
        }
    }
}
