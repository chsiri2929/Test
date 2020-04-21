using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = ReverseWords("The sky is blue");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static void LengthOfLongestSubstring(string str)
        {
            int maxLength = 0;
            string collectedS = "";
            string collectedSFinal = "";
            foreach (char c in str)
            {
                int repeatedIndex = collectedS.IndexOf(c);
                if (repeatedIndex < 0)
                {
                    collectedS += c;
                }
                else
                {
                    if (collectedS.Length > maxLength)
                    {
                        maxLength = collectedS.Length;
                        collectedSFinal = collectedS;
                    }
                        
                    collectedS = collectedS.Substring(repeatedIndex + 1) + c;
                }
            }
            if (collectedS.Length > maxLength)
            {
                maxLength = collectedS.Length;
                collectedSFinal = collectedS;
            }
               
            Console.WriteLine(maxLength);
            Console.WriteLine(collectedSFinal);
            
        }

        public static bool isValidParenthesis(String s)
        {
            Dictionary<char, char> openingClosing = new Dictionary<char, char>();
            openingClosing.Add('(', ')');
            openingClosing.Add('{', '}');
            openingClosing.Add('[', ']');

            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            if (s.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                
                if (stack.Count == 0)
                {
                    if (openingClosing.ContainsKey(s[i]))
                        stack.Push(s[i]);
                    else
                        return false;
                }
                else if(openingClosing.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else if(stack.Count == 0)
                {
                    return false;
                }
                else if (openingClosing[stack.Peek()] == s[i])
                {
                    Console.WriteLine("Character is :" + s[i]);
                    stack.Pop();
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int ClimbStairs(int n)
        {

            if (n == 1 || n == 0)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            

            return dp[n];
        }

        public static int maxNum(int[] nums)
        {
            int max = 1;
            int sum = 0;
            for(int i =0; i<nums.Length; i++)
            {
                sum += nums[i];

                if (sum < 0)
                {
                    max = Math.Max(max, Math.Abs(sum)+1);
                }
            }

            return max;
        }

        public static int[] MoveZeros(int[] nums)
        {
            if (nums.Length != 0)
            {
                for(int i = 0; i<nums.Length-1; i++)
                {
                    for(int j = i + 1;j < nums.Length; j++){
                        if(nums[i]==0 && nums[j] != 0)
                        {
                            int temp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = temp;
                            break;
                        }
                    
                    }

                }
            }

            return nums;
        }

        public static int SingleNumber(int[] nums)
        {
            int a = 0;
            foreach (int num in nums)
            {
                a ^= num;
            }
            return a;
        }

        public static bool HappyNumber(int n)
        {
            while(n != 1)
            {
                n = sumofSquares(n);
            }

            if (n == 1)
                return true;
            else return false;
        }

        public static int sumofSquares(int n)
        {
            string s = n.ToString();
            char[] sArray = s.ToArray();
            int sum = 0;
            foreach(var c in sArray)
            {
                int temp = Convert.ToInt32(c.ToString());
                sum += (temp* temp);
            }

            return sum;
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if(A.Length != 0)
            {
                Array.Sort(A);

                int min = A[0];
                int max = A[A.Length - 1];
                if (min <= 0 && max <= 0)
                    return 1;
                if (min == max && min >1)
                    return 1;
                if (min > 1)
                    return 1;
                bool found = false;

                min = (min < 0) ? 1 : min;
                for (int i = min; i <= max; i++)
                {
                    if (!A.Contains(i))
                    {
                        found = true;
                        min = i;
                        break;
                    }
                }

                if (found)
                    return min;
                else return max + 1;
            }
            else
            {
                return 1;
            }
            
        }

        public static string ReverseWords(string s)
        {
            string[] strArray = s.Split(" ");

            s = string.Empty;

            for(int i = strArray.Length-1; i>=0; i--)
            {
               
                s +=" "+ strArray[i];
            }

            return s.TrimStart();
        }
    }
}
