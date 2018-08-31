﻿namespace Weighted_Randomizer
{
    public class MersenneTwister
    {
        // Period parameters  
        const int N = 624;
        const int M = 397;
        const ulong MATRIX_A = 0x9908b0dfUL;	// constant vector a
        const ulong UPPER_MASK = 0x80000000UL;	// most significant w-r bits
        const ulong LOWER_MASK = 0x7fffffffUL;	// least significant r bits
        private readonly ulong[] mt = new ulong[N];	// the array for the state vector
        private int mti = N + 1;			// mti==N+1 means mt[N] is not initialized
        public MersenneTwister() { Init_by_array(new ulong[] { 0x123, 0x234, 0x345, 0x456 }); }	// set default seeds
        public MersenneTwister(ulong s) { Init_genrand(s); }
        public MersenneTwister(ulong[] init_key) { Init_by_array(init_key); }
        // initializes mt[N] with a seed
        public void Init_genrand(ulong s)
        {
            mt[0] = s & 0xffffffffUL;
            for (mti = 1; mti < N; mti++)
            {
                mt[mti] = (1812433253UL * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + (ulong)mti);
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                /* In the previous versions, MSBs of the seed affect   */
                /* only MSBs of the array mt[].                        */
                /* 2002/01/09 modified by Makoto Matsumoto             */
                mt[mti] &= 0xffffffffUL;
                /* for >32 bit machines */
            }
        }
        // initialize by an array with array-length
        // init_key is the array for initializing keys
        // init_key.Length is its length
        public void Init_by_array(ulong[] init_key)
        {
            Init_genrand(19650218UL);
            int i = 1;
            int j = 0;
            int k = (N > init_key.Length ? N : init_key.Length);
            for (; k != 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525UL)) + init_key[j] + (ulong)j; /* non linear */
                mt[i] &= 0xffffffffUL; /* for WORDSIZE > 32 machines */
                i++; j++;
                if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
                if (j >= init_key.Length) { j = 0; }
            }
            for (k = N - 1; k != 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941UL)) - (ulong)i; // non linear
                mt[i] &= 0xffffffffUL; // for WORDSIZE > 32 machines
                i++;
                if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
            }
            mt[0] = 0x80000000UL; // MSB is 1; assuring non-zero initial array 
        }
        // generates a random number on [0,0xffffffff]-interval
        public ulong Genrand_uint32()
        {
            ulong[] mag01 = new ulong[] { 0x0UL, MATRIX_A };
            ulong y = 0;
            // mag01[x] = x * MATRIX_A  for x=0,1
            if (mti >= N)
            {	// generate N words at one time
                int kk;
                if (mti == N + 1)
                {			// if init_genrand() has not been called,
                    Init_genrand(5489UL);	// a default initial seed is used
                }
                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }
                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                    mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1UL];
                }
                y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];
                mti = 0;
            }
            y = mt[mti++];
            // Tempering
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9d2c5680UL;
            y ^= (y << 15) & 0xefc60000UL;
            y ^= (y >> 18);
            return y;
        }
        // generates a random floating point number on [0,1]
        public double Genrand_real1()
        {
            return Genrand_uint32() * (1.0 / 4294967295.0);	// divided by 2^32-1
        }
        // generates a random floating point number on [0,1)
        public double Genrand_real2()
        {
            return Genrand_uint32() * (1.0 / 4294967296.0);	// divided by 2^32
        }
        // generates a random integer number from 0 to N-1
        public int Genrand_N(int iN)
        {
            return (int)(Genrand_uint32() * (iN / 4294967296.0));
        }
    }
}