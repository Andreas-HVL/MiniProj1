﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProj.Functionality
{
    public static class InputReader
    {
        public static char SingleKey(int maxValidNumber)
        {
            ConsoleKeyInfo cki;
            char keyChar;

            do
            {
                cki = Console.ReadKey(true);
                keyChar = cki.KeyChar;
            }
            while (!IsValidKey(keyChar, maxValidNumber));

            return keyChar;
        }

        private static bool IsValidKey(char keyChar, int maxValidNumber)
        {
            // Allow digits '0' through '9' based on the maxValidNumber
            return keyChar >= '0' && keyChar <= (char)('0' + maxValidNumber - 1);
        }

        public static int? GetValidIntegerInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric ID or 'Q' to quit.");
                }
            }
        }

        public static decimal GetValidDecimalInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
