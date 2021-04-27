// Main.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <math.h>
#include <chrono>
#include <map>

using namespace std;
using namespace std::chrono;

int UPPER_BOUND = 100000000;

bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }

    if (number % 2 == 0)
    {
        return number == 2;
    }

    int root = (int)sqrt(number) + 1;

    for (int i = 3; i < root; i += 2)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

void pretty_print_map(map<int, int> dict)
{
    cout << "{";
    for (map<int, int>::const_iterator it = dict.begin(); it != dict.end(); ++it)
    {
        cout << it->first << ": " << it->second << ", ";
    }
    cout << "}";
}

int main()
{
    auto start = high_resolution_clock::now();

    map<int, int> primeGaps = {};

    int prevPrime = 2;
    int numPrimes = 1;

    for (int i = 1; i < UPPER_BOUND; i += 2)
    {
        if (IsPrime(i))
        {
            numPrimes++;
            int primeGap = i - prevPrime;
            prevPrime = i;
            if (primeGaps.count(primeGap))
            {
                primeGaps[primeGap] = primeGaps[primeGap] + 1;
            }
            else
            {
                primeGaps.insert(pair<int, int>(primeGap, 1));// Add(primeGap, 1);
            }
        }
    }
    
    auto end = high_resolution_clock::now();
    auto duration = duration_cast<milliseconds>(end - start);

    cout << "***** C++ Complete *****" << endl;
    cout << "- Run time: " << duration.count() << " ms" << endl;
    cout << "- Estimated prime numbers: " << (int)(UPPER_BOUND / log(UPPER_BOUND)) << endl;
    cout << "- Found " << numPrimes << " prime numbers between 1 and " << UPPER_BOUND << endl;
    cout << "- Count of gaps between prime numbers" << endl;
    pretty_print_map(primeGaps);
}


