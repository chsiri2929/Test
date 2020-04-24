using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeCoding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);

            root.right.left = new Node(4);
            root.right.left.left = new Node(6);
            root.right.left.right = new Node(5);

            root.right.left.left.left = new Node(8);

            IList<IList<int>> result = LevelOrder(root);
            Console.WriteLine("[");
            foreach(var res in result)
            {
                PrintListInt(res);
                if(result[result.Count-1]!=res)
                    Console.Write(",");
                Console.WriteLine();
            }
            Console.WriteLine("]");
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
                else if (openingClosing.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else if (stack.Count == 0)
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
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum < 0)
                {
                    max = Math.Max(max, Math.Abs(sum) + 1);
                }
            }

            return max;
        }

        public static int[] MoveZeros(int[] nums)
        {
            if (nums.Length != 0)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] == 0 && nums[j] != 0)
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
            while (n != 1)
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
            foreach (var c in sArray)
            {
                int temp = Convert.ToInt32(c.ToString());
                sum += (temp * temp);
            }

            return sum;
        }

        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A.Length != 0)
            {
                Array.Sort(A);

                int min = A[0];
                int max = A[A.Length - 1];
                if (min <= 0 && max <= 0)
                    return 1;
                if (min == max && min > 1)
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
            return string.Join(" ", strArray.Reverse());
        }

        public static void EggDroppingProblem(int stairs, int eggs)
        {
            int total = 0;

        }


        //******************Binary Tree Printing Paths Starts****************/////
        public class Node
        {
            public int data;
            public Node right;
            public Node left;

            public Node(int value)
            {
                this.data = value;
                this.right = null;
                this.left = null;
            }

        }

        public static void printPathsOfTree(Node root, int[] paths, int pathLength)
        {
            if (root == null)
                return;

            paths[pathLength]=root.data;
            pathLength++;
            if (root.left == null && root.right == null)
            {
                printArray(paths, pathLength);
            }
            else
            {
                printPathsOfTree(root.left, paths, pathLength);
                printPathsOfTree(root.right, paths, pathLength);

            }
        }

        public static void printPathsOfTreeUsingStack(Node root, Stack<int> paths)
        {
            if (root == null)
                return;

            paths.Push(root.data);

            if (root.left == null && root.right == null)
            {
                string strInput = string.Empty;
                printStack(paths, strInput);
                Console.WriteLine();
            }
            else
            {
                printPathsOfTreeUsingStack(root.left, paths);
                printPathsOfTreeUsingStack(root.right, paths);

            }
            
            paths.Pop();
        }

        //*******************Solved on 04/24/2020 Starts **********************////

        public static int MaxDepthofTreeUsingStack(Node root, Stack<int> paths, ArrayList depths, int depthRight, int depthLeft)
        {
            int depth = Math.Max(depthRight,depthLeft);
            if (root == null)
                return depth;

            paths.Push(root.data);
            int stackcount = paths.Count;
            depths.Add(stackcount);
            
            depthLeft = MaxDepthofTreeUsingStack(root.left, paths, depths, depthRight, depthLeft);
            depthRight = MaxDepthofTreeUsingStack(root.right, paths, depths, depthRight, depthLeft);

            paths.Pop();

            depths.Sort();
            depth = Math.Max(depth,Convert.ToInt32(depths[depths.Count - 1]));

            return depth;
        }

        public class Pair
        {
            public Node n;
            public int level;
            public Pair(Node n, int level)
            {
                this.n = n;
                this.level = level;
            }

        }

        public static void printNodesByLevelOfTree(Node root, Pair pair, Dictionary<int, List<Pair>> elements)
        {
            if (root == null)
                return;

            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(pair);

            while(queue.Count > 0)
            {
                Pair p = queue.Dequeue();
                if (!elements.ContainsKey(p.level))
                {
                    List<Pair> pairs = new List<Pair>();
                    pairs.Add(p);
                    elements.Add(p.level, pairs);
                }
                else
                {
                        elements[p.level].Add(p);
                }

                if (p.n.left != null)
                {
                    Pair tempLeft = new Pair(p.n.left, p.level + 1);
                    queue.Enqueue(tempLeft);
                }

                if (p.n.right != null)
                {
                    Pair tempRight = new Pair(p.n.right, p.level + 1);
                    queue.Enqueue(tempRight);
                }
            }

            Console.WriteLine("[");
            foreach(var ele in elements)
            {
                PrintList(ele.Value);
                Console.WriteLine();
            }
            Console.WriteLine("]");

        }

        public static void PrintList(List<Pair> ListElements)
        {
            string str = string.Empty;
            foreach(var item in ListElements)
            {
                str += (item.n.data + ",");
            }
            Console.Write("[" + str.TrimEnd(',') + "],");
        }

        public static void PrintListInt(IList<int> ListElements)
        {
            string str = string.Empty;
            foreach (var item in ListElements)
            {
                str += (item + ",");
                
            }

            Console.Write("[" + str.TrimEnd(',') + "]");
            
        }

        public static IList<IList<int>> LevelOrder(Node root)
        {
            Pair p = new Pair(root, 1);
            List<List<Pair>> elements = new List<List<Pair>>();

            List<List<Pair>> resultPairs = printNodesByLevelOfTree(root, p, elements);
            IList<IList<int>> result = new List<IList<int>>();
            foreach (var res in resultPairs)
            {
                result.Add(res.Select(e => e.n.data).ToList());
            }

            return result;
        }

        public static List<List<Pair>> printNodesByLevelOfTree(Node root, Pair pair, List<List<Pair>> elements)
        {
            if (root == null)
                return elements;

            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(pair);

            while (queue.Count > 0)
            {
                Pair p = queue.Dequeue();

                List<Pair> res = elements.SelectMany(x => x.Where(z => z.level == p.level)).ToList();


                if (elements.Count == 0 || res.Count == 0)
                {
                    List<Pair> pairs = new List<Pair>();
                    pairs.Add(p);
                    elements.Add(pairs);
                }
                else
                {
                    int index = elements.FindIndex(a => a[0].level == res[0].level);
                    res.Add(p);
                    elements[index] = res;

                }

                if (p.n.left != null)
                {
                    Pair tempLeft = new Pair(p.n.left, p.level + 1);
                    queue.Enqueue(tempLeft);
                }

                if (p.n.right != null)
                {
                    Pair tempRight = new Pair(p.n.right, p.level + 1);
                    queue.Enqueue(tempRight);
                }
            }

            return elements;
        }


        //*******************Solved on 04/24/2020 Ends **********************////

        public static  void printStack(Stack<int> inputStack, string strInput)
        {

            if (inputStack.Count!=0)
            {
                int x = inputStack.Peek();

                inputStack.Pop();

                printStack(inputStack, strInput);

                strInput += Convert.ToString(x) +"->";

                Console.Write(strInput);

                inputStack.Push(x);
            }

        }


        public static void printArray(int[] paths, int pathLength)
        {
            for(int i = 0; i< pathLength; i++)
            {
                Console.Write(paths[i]+"->");
            }
            Console.WriteLine();
        }

        //******************Binary Tree Printing Paths Ends****************/////

        //*******************Solved on 04/24/2020 Starts **********************////

        public static int MaxProfitWithKTransactions(int[] prices, int k)
        {
            if (prices.Length == 0)
                return 0;

            int[,] profits = new int[k + 1, prices.Length];

            for(int t = 1; t < k + 1; t++)
            {
                int maxSoFar = Int32.MinValue;

                for(int d = 1; d < prices.Length; d++)
                {
                    maxSoFar = Math.Max(maxSoFar, (profits[t - 1,d - 1]) - prices[d-1]);

                    profits[t, d] = Math.Max(profits[t, d-1], maxSoFar+prices[d]);
                    Console.Write(profits[t, d] + " ,");
                }
                Console.WriteLine();
            }
            
            return profits[k,prices.Length-1];
        }

        //*******************Solved on 04/24/2020 Ends **********************////
    }


}
