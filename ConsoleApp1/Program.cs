using System;
using System.IO;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            // creating the stacks
            Stack<char>[] stacks = new Stack<char>[9];
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<char>();
            }

            for (int i = 7; i >= 0; i--)
            {
                int stack = 0;
                for (int j = 1; j < input[i].Length; j += 4)
                {
                    if (input[i][j] != ' ')
                    {
                        stacks[stack].Push(input[i][j]);
                    }
                    stack++;
                }
            }

            // moving crates

            // Part 1
            //for (int i = 10; i < input.Length; i++)
            //{
            //    int nmoves = int.Parse(input[i].Split(' ')[1]);
            //    int from = int.Parse(input[i].Split(' ')[3]);
            //    int to = int.Parse(input[i].Split(' ')[5]);

            //    for (int j = 0; j < nmoves; j++)
            //    {
            //        stacks[to-1].Push(stacks[from - 1].Pop());
            //    }
            //}

            // Part 2
            for (int i = 10; i < input.Length; i++)
            {
                int nmoves = int.Parse(input[i].Split(' ')[1]);
                int from = int.Parse(input[i].Split(' ')[3]);
                int to = int.Parse(input[i].Split(' ')[5]);

                List<char> list = new List<char>();

                for (int j = 0; j < nmoves; j++)
                {
                    list.Insert(0,stacks[from - 1].Pop());
                }
                for (int j = 0; j < nmoves; j++)
                {
                    stacks[to - 1].Push(list[0]);
                    list.RemoveAt(0);
                }

            }

            // getting the tops of the stacks
            string answer = String.Empty;
            for (int i = 0; i < stacks.Length; i++)
            {
                answer += stacks[i].Peek();
            }
            Console.WriteLine(answer);
        }
    }
}

