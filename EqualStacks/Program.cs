using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualStacks
{
    class Program
    {
        public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            int[] numberOfCylinders = { h1.Count, h2.Count, h3.Count };
            int[][] stack = { new int[h1.Count], new int[h2.Count], new int[h3.Count] };
            int[] height = { 0, 0, 0 };

            int counter = 0;
            foreach (var item in h1)
            {
                stack[0][counter++] = item;
                height[0] += item;
            }

            counter = 0;
            foreach (var item in h2)
            {
                stack[1][counter++] = item;
                height[1] += item;
            }

            counter = 0;
            foreach (var item in h3)
            {
                stack[2][counter++] = item;
                height[2] += item;
            }

            int[] index = { 0, 0, 0 };
            int targetHeight = Math.Min(Math.Min(height[0], height[1]), height[2]);
            while (height[0] != height[1] || height[1] != height[2])
            {
                for (int i = 0; i < 3; i++)
                {
                    if (height[i] > targetHeight)
                    {
                        height[i] -= stack[i][index[i]++];
                        targetHeight = Math.Min(targetHeight, height[i]);
                    }
                }
            }
            return targetHeight;
        }
        static void Main(string[] args)
        {

            Console.WriteLine(equalStacks(new List<int>() { 3, 2, 1, 1, 1 }, new List<int>() { 4, 3, 2 }, new List<int>() { 1, 1, 4, 1 }) ); //5
            Console.ReadKey();
        }
    }
}
