namespace array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arr2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            // Sum of corresponding elements
            int[] sumWithOther = GetSumOfArray(arr1, arr2);
            Console.WriteLine("Sum of array elements with other array elements:");

            for (int i = 0; i < sumWithOther.Length; i++)
            {
                Console.WriteLine($"{arr1[i]} + {arr2[i]} = {sumWithOther[i]}");
            }

            // Sum of even elements
            int evenSum1 = GetSumOfEvenElements(arr1);
            int evenSum2 = GetSumOfEvenElements(arr2);
            Console.WriteLine($"\nSum of even elements in array 1: {evenSum1}");
            Console.WriteLine($"Sum of even elements in array 2: {evenSum2}");

            // Sum of digits
            int digitSum1 = GetSumOfDigits(arr1);
            int digitSum2 = GetSumOfDigits(arr2);
            Console.WriteLine($"\nSum of digits in array 1: {digitSum1}");
            Console.WriteLine($"Sum of digits in array 2: {digitSum2}");

            // Get even and odd arrays
            int[] even_array1 = GetEvenArray(arr1);
            int[] odd_array1 = GetOddArray(arr1);
            int[] even_array2 = GetEvenArray(arr2);
            int[] odd_array2 = GetOddArray(arr2);

            // Display arrays properly
            Console.WriteLine($"\nevenarray1: [{string.Join(", ", even_array1)}]");
            Console.WriteLine($"oddarray1: [{string.Join(", ", odd_array1)}]");
            Console.WriteLine($"evenarray2: [{string.Join(", ", even_array2)}]");
            Console.WriteLine($"oddarray2: [{string.Join(", ", odd_array2)}]");
        }

        public static int[] GetSumOfArray(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }
            return result;
        }

        public static int GetSumOfEvenElements(int[] arr)
        {
            int even_sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    even_sum += arr[i];
                }
            }
            return even_sum;
        }

        public static int GetSumOfDigits(int[] arr)
        {
            int digit_sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                while (num > 0)
                {
                    digit_sum += num % 10;
                    num /= 10;
                }
            }
            return digit_sum;
        }

        public static int[] GetEvenArray(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    count++;
                }
            }

            int[] evenArray = new int[count];
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenArray[index] = arr[i];
                    index++;
                }
            }
            return evenArray;
        }

        public static int[] GetOddArray(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count++;
                }
            }

            int[] oddArray = new int[count];
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    oddArray[index] = arr[i];
                    index++;
                }
            }
            return oddArray;
        }
    }
}