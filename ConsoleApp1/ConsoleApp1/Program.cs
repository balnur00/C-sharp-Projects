using System;
public class ConsoleApp1
{
    public static void Main()
    {
        int[] arr1 = new int[100];
        int[] arr2 = new int[100];
        int i, n;


        n = Convert.ToInt32(Console.ReadLine());

        for (i = 0; i < n; i++)
        {
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }
        /* Copy elements of first array into second array.*/
        for (i = 0; i < n; i++)
        {
            arr2[i] = arr1[i];
        }

        for (i = 0; i < n; i++)
        {
            Console.Write("{0}  ", arr1[i]);
        }

        for (i = 0; i < n; i++)
        {
            Console.Write("{0}  ", arr2[i]);
        }
        Console.Write("\n\n");
        Console.ReadKey();
    }
}
