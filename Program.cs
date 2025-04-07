using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            // Edge Case: Numbers may repeat (e.g., duplicates like '2' or '3')
            // Edge Case: If the array contains all numbers from 1 to n, result should be empty
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                    nums[index] = -nums[index]; // mark seen
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    result.Add(i + 1);
            }
            return result;
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            // Edge Case: All even or all odd numbers
            // Edge Case: Array with only 1 element
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] % 2 > nums[right] % 2)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                }
                if (nums[left] % 2 == 0) left++;
                if (nums[right] % 2 == 1) right--;
            }
            return nums;
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Edge Case: No valid pair found, return empty array
            // Edge Case: Same element cannot be used twice
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                if (!map.ContainsKey(nums[i]))
                    map[nums[i]] = i;
            }
            return new int[0];
        }

        // Question 4: Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // Edge Case: Negative numbers may result in highest product (e.g., -10 * -10 * 5)
            // Edge Case: Less than 3 elements → not possible, assume input has at least 3 numbers
            Array.Sort(nums);
            int n = nums.Length;
            return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                            nums[0] * nums[1] * nums[n - 1]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            // Edge Case: Decimal number is 0, should return "0"
            if (decimalNumber == 0) return "0";
            string binary = "";
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary;
                decimalNumber /= 2;
            }
            return binary;
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            // Edge Case: Already sorted (not rotated) array
            // Edge Case: Only one element
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right = mid;
            }
            return nums[left];
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Edge Case: Negative numbers are not palindromes
            if (x < 0) return false;
            int original = x, reversed = 0;
            while (x > 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }
            return original == reversed;
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            // Edge Case: If n = 0 or n = 1, return n directly
            if (n <= 1) return n;
            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}
