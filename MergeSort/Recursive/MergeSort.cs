using System;

public class MergeSort<T> : Sortable<T> where T : IComparable<T>
{
  private readonly IMerger<T> _merger;
  
  private MergeSort(IMerger<T> merger) => _merger = merger;

  public static Sortable<T> Create() => new MergeSort<T>(Merger<T>.Create());

	public override void Sort(T[] list, Func<T, T, bool> predicate)
	{
		SortImpl(list, new T[list.Length], 0, list.Length-1, predicate);
	}

  private void SortImpl(T[] list, T[] temp, int left, int right, Func<T, T, bool> predicate)
  {
    if(left >= right)
      return;

    var mid = left + (right - left >> 1);

    SortImpl(list, temp, left, mid, predicate);
    SortImpl(list, temp, mid+1, right, predicate);

    _merger.Merge(list, temp, left, mid, right, predicate);
  }
}
