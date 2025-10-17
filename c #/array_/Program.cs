namespace array_
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
              
             int[] arr2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };


            int[] sumWithOther = GetSumOfArray(arr1, arr2);
            Console.WriteLine("Sum of array elements with other array elements:");

            for (int i = 0; i < sumWithOther.Length; i++)
            {
                Console.WriteLine($"sum of arrays {sumWithOther[i]}");
            }

            int evenSum1 = GetSumOfEvenElements(arr1);
            int evenSum2 = GetSumOfEvenElements(arr2);
            Console.WriteLine($"Sum of even elements in array 1: {evenSum1}");
            Console.WriteLine($"Sum of even elements in array 2: {evenSum2}");

            int digitSum1 = GetSumOfDigits(arr1);
            int digitSum2 = GetSumOfDigits(arr2);
            Console.WriteLine($"Sum of digits in array 1: {digitSum1}");
            Console.WriteLine($"Sum of digits in array 2: {digitSum2}");
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
    }
}