using System;
using System.Collections;

namespace Sequences
{
    public class Sequence
    {
        public IEnumerable Fibonacci()
        {
            yield return 1;
            yield return 1;

            ulong a, b, c;
            c = b = 1;

            while (true)
            {
                a = b;
                b = c;
                c = a + b;
                yield return c;
            }
        }
    }
}
