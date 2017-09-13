using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PrimeFinder
{
    public List<int> PrimeList = new List<int> { 2, 3, 5 };
    //What nr was the last prime found

    //Checks if the specified number is a prime
    private void CheckPrime(double currentNr)
    {
        //Starts checkking from the rounded root + 1, because that's the most efficient
        int root = (int)Math.Sqrt(currentNr) / 2 * 2 + 1;
        bool isPrime = true;
        //Actual check to see if a number is prime or not
        int lim = GetIndexOfPrime(root);
        for (int count = 0; count <= lim; count++)
        {
            if (currentNr % PrimeList[count] == 0)
            {
                isPrime = false;
                break;
            }
        }
        //Adds the number if it is a prime
        if (isPrime)
        {
            PrimeList.Add((int)currentNr);
        }
    }//CheckPrime

    //Generates primes until the asked index
    public void GeneratePrimesUntilIndex(int nr)
    {
        //Where to start looking for primes
        double currentNr = PrimeList.Last() + 2;
        while (PrimeList.Count < nr)
        {
            CheckPrime(currentNr);
            currentNr += 2;
        }
    }//GeneratePrimesUntilIndex

    //Generates prime until the asked nr
    public void GeneratePrimesUntilNumber(int nr)
    {
        double currentNr = PrimeList.Last() + 2;
        while (PrimeList.Last() < nr)
        {
            CheckPrime(currentNr);
            currentNr += 2;
        }
    }//GeneratePrimesUntilNumber

    //Get a certain prime. If the prime is not in the list, it will generate until there
    public int GetPrimeAtIndex(int nr)
    {
        if (nr > PrimeList.Count)
            GeneratePrimesUntilIndex(nr);
        return PrimeList[nr - 1];
    }//GetPrimeAtIndex

    //Gets the index of the given prime. returns -1 if not found
    public int GetIndexOfPrime(int nr)
    {
        return PrimeList.FindIndex(x => x >= nr);
    }//GetIndexOfPrime

    //Finds the next closest prime of the given number
    public int ClosestNextPrime(int nr)
    {
        return PrimeList.Find(x => x >= nr);
    }//ClosestNextPrime

    //Shows a messagebox with all the current primes
    /*public void ShowPrimes()
    {
        string result = "[1] " + PrimeList[0];
        for (int i = 1; i < PrimeList.Count; i++)
            result += ", [" + (i + 1) + "] " + PrimeList[i];
        MessageBox.Show(result);
    }//ShowPrimes*/
}
