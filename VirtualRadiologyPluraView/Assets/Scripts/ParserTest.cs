using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandLine;
using System;
using System.IO;

public class ParserTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var args = Environment.GetCommandLineArgs();
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                Console.WriteLine("Input file: " + options.InputFile);
                Debug.Log("Verbose: " + options.Verbose);
                File.WriteAllText("output.txt", "Hello, World!");
            })
            .WithNotParsed(errors =>
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class Options
{
    [Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
    public string InputFile { get; set; }

    [Option('v', "verbose", Default = false, HelpText = "Prints all messages to standard output.")]
    public string Verbose { get; set; }
}