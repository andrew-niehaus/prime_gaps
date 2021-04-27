import math
import sys
import time

def is_prime(number):
    if (number < 2):
        return False
    if (number % 2 == 0):
        return (number == 2)
    root = math.floor(math.sqrt(number)) + 1
    for i in range(3, root, 2):
        if (number % i == 0):
            return False
    return True

if __name__ == '__main__':
    start_time = time.time()
    prime_gaps = {}

    # range doesn't include 2 which is prime
    prev_prime = 2
    upper_limit = int(sys.argv[1])
    num_primes = 1
    for i in range(1, upper_limit, 2):
        if is_prime(i):
            num_primes += 1
            prime_gap = i - prev_prime
            prev_prime = i
            if prime_gap in prime_gaps:
                prime_gaps[prime_gap] = prime_gaps[prime_gap] + 1
            else:
                prime_gaps[prime_gap] = 1
    
    end_time = time.time()
    print("***** PYTHON COMPLETE *****")
    print('- Run time:', ' %s s' % (end_time - start_time))
    print('- Estimated prime numbers:', math.floor(upper_limit / math.log(upper_limit)))
    print("- Found",num_primes,"prime numbers between 1 and",upper_limit)
    print("- Count of gaps between prime numbers:")
    print(prime_gaps)