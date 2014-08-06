using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace robovoice
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("Usage robovoice <infile> <outdir>");
                Console.WriteLine("Input file should be a csv that maps file names to text to translate, one file per line.");
                //return;
            }

            SpeechSynthesizer reader = new SpeechSynthesizer();

            string outDir = args[1];
            if(!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            StreamReader lineFile = new StreamReader(args[0]);
            while (!lineFile.EndOfStream)
            {
                string line = lineFile.ReadLine();
                string[] values = line.Split(new char[] { ',' }, 2);
                reader.SetOutputToWaveFile(outDir + "/" + values[0] + ".wav");
                reader.Speak(values[1]);
            }
        }
    }
}
