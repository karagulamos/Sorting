using System;

public abstract class Sortable<T> where T : IComparable<T>
{
  public abstract void Sort(T[] list, Func<T, T, bool> predicate);
  public void Sort(T[] list) => Sort(list, (a, b) => a.CompareTo(b) < 0);
}