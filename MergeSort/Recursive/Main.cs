using System;

public class Program
{
	public static void Main()
	{
		var list = new[] { "dance", "very", "alex", "well", "can"};

    Sortable<string> sorter = MergeSort<string>.Create();

		sorter.Sort(list);

		foreach (var item in list)
		  Console.Write(item + " ");

    Console.WriteLine();
	}
}