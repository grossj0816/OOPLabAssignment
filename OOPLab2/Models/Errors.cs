using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace OOPLab2.Models
{
    public class Errors
    {
        public void ReadErrors(string errors)
        {
            string path = @"C:\Users\Juwan\Desktop\errors.txt";
            // This test is added only once to the file
            if (!File.Exists(path))
            {
                //create a file to write to.
                string createText = errors + Environment.NewLine;
                File.WriteAllText(path, createText, Encoding.UTF8);
            }
            else
            {
                //This is always added, making the file longer over time
                //if it is not deleted.
                string appendText = errors + Environment.NewLine;
                File.AppendAllText(path, appendText, Encoding.UTF8);
                //Open the file to read from.
                string readText = File.ReadAllText(path);

            }
        }
    }
}