using System;
using System.ComponentModel;	// used @TryParse

/// <summary>
/// Implementation of caluclation of river flow.
/// </summary>
class RiverFlow {
	private int section;
	private double[] width;
	private double[] depth;
	private double[] velocity;

	public RiverFlow(int section, double[] width, double[] depth, double[] velocity) {
		this.section = section;
		this.width = width;
		this.depth = depth;
		this.velocity = velocity;
	}

	/// <summary>
	/// Return river flow.
	/// </summary>
	public double CalculateRiverFlow() {
		double riverFlow = 0;
		for(int i = 0; i < section; i++) {
			riverFlow += width[i] * depth[i] * velocity[i];
		}
		return riverFlow;
	}
}

/// <summary>
/// Main class. User can choose to run test or run calculate river flow.
/// </summary>
class MainClass {
	public static void Main (string[] args) {
		
		Console.Write("Input 'test' to test. Otherwise, enter to start calculating.: ");
		if(Console.ReadLine() != "test") {
			Console.WriteLine("Please input numbers of Section, Width, Depth, and Velocity according to the messages below:");
			getRiverFlow();
		}
		else
			TestMainClass.TestMain();		
	}

	/// <summary>
	/// Read input and print out river flow.
	/// </summary>
	static void getRiverFlow() {		
		int section = getSection();		
		double[] width = getItemArray("What is the width of each section?", section);
		double[] depth = getItemArray("What is the depth of each section?", section);
		double[] velocity = getItemArray("What is the velocity of each section?", section);
		
		RiverFlow rf = new RiverFlow(section, width, depth, velocity);
		double riverFlow = rf.CalculateRiverFlow();
		Console.WriteLine("River Flow is : {0}", riverFlow);
	}

	/// <summary>
	/// Get the number of sections from console.
	/// </summary>
	static int getSection() {		
		string stringSection = getInput("How many sections are in a specific point in a stream?: ");
		int section = 0;
		bool boolParse = TryParse(stringSection, ref section);
		if(boolParse == false) 
			throw new Exception("Input Convert Error: Section. Error Value: " + stringSection);
		return section;
	}

	/// <summary>
	/// Get the array from console.
	/// <param name="itemName">The name what to read</param>
	/// <param name="section">The number of sections</param>
	/// </summary>
	static double[] getItemArray(string itemName, int section) {
		string[] arrInput = getInputArray(itemName + ": ", section);
		double[] arrItem = new double[section];		
		for(int i = 0; i < section; i++) {
			bool boolParse = TryParse(arrInput[i], ref arrItem[i]);
			if(boolParse == false) 
				throw new Exception("Input Convert Error: " + itemName + ". Error Value: " + arrInput[i]);		
		}

		return arrItem;
	}

	/// <summary>
	/// Read a line from console. Continue until input is obtained.
	/// <param name="message">Messate to show on console for input</param>
	/// </summary>
	static string getInput(string message) {
		string input;
		while(true) {
			try {
				Console.Write(message);
				input = Console.ReadLine();
			} catch(Exception e) {
				Console.WriteLine(e);
				Console.WriteLine("Please input again.");
				continue;
			}
			break;
		}
		return input;
	}

	/// <summary>
	/// Read a line from console as array of string. Continue until input is obtained.
	/// Expected array lentgh must be same as <param name="element">
	/// <param name="message">Messate to show on console for input</param>
	/// <param name="element">The number of array's elements</param>
	/// </summary>
	static string[] getInputArray(string message, int element) {
		string[] input = new string[element];
		while(true) {
			try {
				Console.Write(message);
				string[] inputOriginal = Console.ReadLine().Split();
				if(inputOriginal.Length < element)
					throw new Exception("The length of array is lesser than Section.");
				else if(inputOriginal.Length > element)
					throw new Exception("The length of array is bigger than Section.");
				else
					input = inputOriginal;
				
			} catch(Exception e) {
				Console.WriteLine(e);
				Console.WriteLine("Please input again.");
				continue;
			}
			break;
		}
		return input;
	}

	/// <summary>
	/// Convert string to desired data type.
	/// <param name="input">Input data string</param>
	/// <param name="result">Converted data</param>
	/// </summary>
	static bool TryParse<T> (string input, ref T result) {
		try {
			var converter = TypeDescriptor.GetConverter(typeof(T));
			if(converter != null) {
				result = (T)converter.ConvertFromString(input);
				return true;
			}
			return false;
		} catch {
			return false;
		}
	}	
}

