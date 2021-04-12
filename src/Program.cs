using System;

namespace Test1
{
    public class Program
    {
        private static bool Contains(int[] array, int number)
        {
            int length;
            if (array == null || (length = array.Length) == 0)
            {
                return false;
            }

            if (array[0] > number || array[^1] < number)
            {
                return false;
            }

            var left = 0;
            var right = length - 1;

            do
            {
                var index = (int)Math.Floor((decimal)(left + right) / 2);
                var current = array[index];
                if (current < number)
                {
                    left = index + 1;
                }
                else if (current > number)
                {
                    right = index - 1;
                }
                else
                {
                    return true;
                }
            }
            while (left <= right);
            return false;
        }

        public static bool Contains(int[][] array, int number)
        {
            if (array == null || array.Length == 0)
            {
                return false;
            }

            foreach (var array2 in array)
            {
                if (Contains(array2, number))
                {
                    return true;
                }
            }

            return false;
        }
    }
}