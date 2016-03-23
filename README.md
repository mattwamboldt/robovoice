## Description

The Robot Voice Batch Processor (robovoice) is a simple command line application for generating placeholder dialogue or speech for a product. It reads in a csv file where the first column represents the id and the second is the text to convert. It then uses the Microsoft Speech Synthesizer to generate wav files in the given folder.

## Instructions

Either download the source and compile with Visual Studio, or download the provided executable in the releases section. Simply put the executable wherever you like and run it like so:

```bat
robovoice infile outdir
```

Input file should be a csv that maps file names to text, one file per line.

## Plans for improvement

If it ever gets used in an actual project the following updates will happen

* Multiple language support
* XML, JSON, SQL Databases and other input formats
* Custom voices to help distinguish who's talking