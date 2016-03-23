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
            // Validation
            if(args.Length != 2)
            {
                Console.WriteLine("Usage robovoice <infile> <outdir>");
                Console.WriteLine("Input file should be a csv that maps file names to text to translate, one file per line.");
                return;
            }

            // Use the microosft speech synthesizer
            // TODO: Add configuration options for users to set an alternate voice if available, this would
            // allow for a bit better play back when used for placeholder dialogue
            SpeechSynthesizer reader = new SpeechSynthesizer();

            // Make sure the directory exists
            string outDir = args[1];
            if(!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            //Look at each line of dialogue in the provided csv and run it through the synthesizer to produce a new wav file
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
