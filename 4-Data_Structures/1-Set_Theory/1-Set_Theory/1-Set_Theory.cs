using System.Collections;
using System.Collections.Generic;

int[] a = { 1, 3, 5 };
int[] b = { 3, 5, 7 };
int[] c = { 5, 7, 9 };

HashSet<int> set = new();

for (int add = 0; add < a.Length; add++) { set.Add(a[add]); set.Add(b[add]); set.Add(c[add]); }
foreach (int element in set) { Console.Write(element); }

/*ALTERNATIVE  its not viable for the Exercise*/
/*int[] result = a.Union(b).Union(c).ToArray();
foreach (int element in result) Console.Write(element);*/