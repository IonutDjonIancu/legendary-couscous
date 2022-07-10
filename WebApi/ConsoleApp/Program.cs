using ClassLib;
using ConsoleApp;

DataProcessor dataProc = new();

Console.WriteLine("give camera name:");
var input = Console.ReadLine();

var listOfCameras = dataProc.GetCamerasByName(input);

MessageFormat.PrintCameras(listOfCameras);










Console.ReadLine();