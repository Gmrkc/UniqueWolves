using System;
using System.Linq;
using System.Collections.Generic;

public class Wolves
{
    public static void Main(string[] args)
    {
        int n;
        do {
            Console.WriteLine("Array size (at least 5):");
            n = Convert.ToInt32(Console.ReadLine());
        } while(n < 5);
        
        int[] intWolvesArray = prepareArray(n);
        int mostRepeatedLeastID = uniqueWolves(intWolvesArray);
        Console.WriteLine("Most repeated and least ID wolf:");
        Console.WriteLine(mostRepeatedLeastID);
        Console.ReadLine();

    }
    
    // Dictionary ile id leri ve tekrar sayılarını depolar. En çok tekrar edip en küçük id ye sahip sayıyı döndürür.
    public static int uniqueWolves(int[] intWolvesArray) {
        var wolvesDict = new Dictionary <int, int>();
        foreach(var value in intWolvesArray) {  
            wolvesDict.TryGetValue(value, out int count);
            wolvesDict[value] = count + 1; 
        }
        int mostRepeatedLeastID = wolvesDict.OrderByDescending(x => x.Value).First().Key;
        return mostRepeatedLeastID;
    }
    
    // Kullanıcıdan dizisini girmesini ister, yanlış girilirse tekrar ister. Verilen boyutlarda array açar ve boşlukları parseler. Son olarak diziyi sıraya sokup döndürür.
    public static int[] prepareArray(int n) {
        string wolves;
        do {
            Console.WriteLine($"Wolves array (size: {n}, please put a space between each number):");
            wolves = Console.ReadLine();
        } while(wolves.Length != (n * 2) - 1);
        string[] wolvesArray = new string[n];
        wolvesArray = wolves.Split(' ');
        int[] intWolvesArray = wolvesArray.Select(int.Parse).ToArray();
        Array.Sort(intWolvesArray);
        return intWolvesArray;
    }
}
