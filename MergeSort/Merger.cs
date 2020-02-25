using System;

public interface IMerger<T>
{
  void Merge(T[] list, T[] temp, int left, int mid, int right, Func<T, T, bool> predicate);
}

internal class Merger<T> : IMerger<T>
{
  public static IMerger<T> Create() => new Merger<T>();
  
  public void Merge(T[] list, T[] temp, int left, int mid, int right, Func<T, T, bool> predicate)
	{
		var (k, l, r) = (left, left, mid+1);
		
		while(l <= mid && r <= right)
			temp[k++] = predicate(list[l], list[r]) ? list[l++] : list[r++];
		
		while(l <= mid)
			temp[k++] = list[l++];
			
		while(r <= right)
			temp[k++] = list[r++];
			
		while(left <= right)
			list[left] = temp[left++];
	}
}