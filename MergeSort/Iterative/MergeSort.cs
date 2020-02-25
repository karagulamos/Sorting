using System;

public class MergeSort<T> : Sortable<T> where T : IComparable<T>
{
  private readonly IMerger<T> _merger;
  
  private MergeSort(IMerger<T> merger) => _merger = merger;

  public static Sortable<T> Create() => new MergeSort<T>(Merger<T>.Create());

	public override void Sort(T[] list, Func<T, T, bool> predicate)
	{
		if(list.Length == 1)
		  return;

		var temp = new T[list.Length];

		for(var (size, end) = (1, list.Length-1); size <= end; size <<= 1)
		{
			for(var left = 0; left <= end; left += size << 1)
			{
				var mid = Math.Min(left + size - 1, end);
				var right = Math.Min(left + (size << 1) - 1, end);

				_merger.Merge(list, temp, left, mid, right, predicate);
			}
		}
	}
}
