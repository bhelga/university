def prime_gen(n):

    primes = [2]

    # починаємо з трійки, бо двійка вже в масиві
    nextPrime = 3

    while nextPrime < n:

        isPrime = True

        i = 0

        # the optimization here is that you're checking from
        # the number in the prime list to the square root of
        # the number you're testing for primality
        squareRoot = int(nextPrime ** .5)

        while primes[i] <= squareRoot:

            if nextPrime % primes[i] == 0:

                isPrime = False

            i += 1

        if isPrime:

            primes.append(nextPrime)

        # only checking for odd numbers so add 2
        nextPrime += 2

    print(primes)

prime_gen(1000)