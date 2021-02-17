using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;

namespace WebDynamic
{
    class Mymethods
    {
        string[] segments = new string[5];
        string param1;
        string param2;
        public string method1(string param1, string param2)
        {
            return $"<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }
        public string display(Uri request)
        {

            int i = 0;
            foreach (string str in request.Segments)
            {

                if (!str.Equals("/"))
                {
                    segments[i] = str.Replace("/", "");
                    i++;
                }
            }
            param1 = HttpUtility.ParseQueryString(request.Query).Get("param1");
            param2 = HttpUtility.ParseQueryString(request.Query).Get("param2");

            string result = "UNDEFINED ACTION";
            Console.WriteLine("segements 1 :"+segments[0]);
            Console.WriteLine("segements 2 :" + segments[1]);
            Console.WriteLine("segements 3 :" +segments[2]);
            if (segments.Length > 1)
            {
                if (segments[2] == "question4" && param1 != null && param2 != null)
                {
                    result = displayParams();
                }
                else if (segments[2] == "question5" && param1 != null && param2 != null)
                {
                    result = exec();
                }

            }
            return result;
        }
        private string displayParams()
        {
            return "Param 1 : " + param1 + "\nParam 2 : " + param2 + " ";
        }
        private String exec()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\Tbenoist\Documents\Polytech\SI4\WebServices\ForkGitHub\TD2\EXERCICE5-EXE\bin\Debug\netcoreapp3.1\EXERCICE5-EXE.exe"; // Specify exe name.
            start.Arguments = param1 + " " + param2;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
