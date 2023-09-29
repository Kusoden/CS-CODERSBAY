using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

int[] a = { 1, 3, 5 };
int[] b = { 3, 5, 7 };
int[] c = { 5, 7, 9 }  ;

HashSet<int> setA = new(a);
HashSet<int> setB = new(b);
HashSet<int> setC = new(c);

HashSet<int> unionSet = GetUnion(setA, setB, setC);
HashSet<int> intersectionSet = GetIntersection(setA, setB, setC);
HashSet<int> differenceSet = GetDifference(setA, setB, setC);

Console.WriteLine("UnionSet:");
foreach (int element in unionSet)
    Console.Write(element + " ");

Console.WriteLine("\nIntersectionSet:");
foreach (int element in intersectionSet)
    Console.Write(element + " ");

Console.WriteLine("\nDifferenceSet:");
foreach (int element in differenceSet)
    Console.Write(element + " ");


HashSet<int> GetUnion(HashSet<int> a, HashSet<int> b, HashSet<int> c)
{
    HashSet<int> result = new(a);
    result.UnionWith(b);
    result.UnionWith(c);
    return result;
}


HashSet<int> GetIntersection(HashSet<int> a, HashSet<int> b, HashSet<int> c)
{
    HashSet<int> result = new(a);
    result.IntersectWith(b);
    result.IntersectWith(c);
    return result;
}

/* es wird geprüft, dass die Element von b und c nicht in a sind.*/
HashSet<int> GetDifference(HashSet<int> a, HashSet<int> b, HashSet<int> c) 
{
    HashSet<int> result = new(a);
    result.ExceptWith(b);
    result.ExceptWith(c);
    return result;
}



/*using System.Collections;
using System.Collections.Generic;

int[] a = { 1, 3, 5 };
int[] b = { 3, 5, 7 };
int[] c = { 5, 7, 9 };

HashSet<int> set = new();

for (int add = 0; add < a.Length; add++) { set.Add(a[add]); set.Add(b[add]); set.Add(c[add]); }
Console.WriteLine("UnionSet:");
foreach (int element in set) { Console.Write(element); }
*/