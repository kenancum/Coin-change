
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\tTask 1!");
            task1();

            Console.WriteLine("\n\tTask2");
            task2();
            Console.ReadLine();
        }

        public static void task1()
        {
            Console.Write("Please enter the value of money as cent: ");
            int value = int.Parse(Console.ReadLine());


            int[] C = { 1, 2, 5, 10, 20, 50, 100 };


            greedyAlgorithm(C, value);

        }

        public static void task2()
        {
            bool checkNegativeMoney = false, checkSameUnit = false , checkUnitMust1 = false;
            int value = 0;

            while (!checkNegativeMoney)
            {
                Console.Write("Please enter the value of money as cent: ");

                value = int.Parse(Console.ReadLine());
                if (value <= 0)
                    Console.WriteLine("Input should be a positive integer");
                else
                    checkNegativeMoney = true;
            }

            Console.Write("Enter the lenght of unit array: ");
            int size = int.Parse(Console.ReadLine());
            int [] C  = new int[size];
            int[] delC = C;


            fillArray(C);
            bubbleSort(C);

            int counter=1;

            while(counter!=0)
            {
                counter = 0;
                checkUnitMust1 = ImprovedLineerSearch(C, 1);
                checkSameUnit = !checkSameNumberinArray(C);

                while (!checkUnitMust1)
                {
                    Console.WriteLine("\tOne coin must have value of 1");
                    C = delC;
                    fillArray(C);
                    checkUnitMust1 = ImprovedLineerSearch(C, 1);
                    counter++;
                }

                while (!checkSameUnit)
                {
                    Console.WriteLine("\tCoins should have unique values");
                    C = delC;
                    fillArray(C);
                    checkSameUnit = !checkSameNumberinArray(C);
                    counter++;
                }
            }            
            greedyAlgorithm(C, value);
        }

        

        public static bool checkSameNumberinArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        return true;
                }
            }
            return false;
        }
        
        public static bool ImprovedLineerSearch(int[] array, int searchedValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (searchedValue == array[i])
                    return true;
            }
            return false;

        }

        public static void greedyAlgorithm(int[]C, int value)
        {
            for (int i = C.Length-1; i >= 0; i--)
            {

                int counter = 0;
                
                while (value >= C[i])
                {
                    counter++;
                    value = value - C[i];
                }
                
                if (counter > 0)
                {
                    Console.WriteLine(counter + " x " + C[i]);
                }
            }
        }

        public static void fillArray(int[]C)
        {
            for (int i = 0; i < C.Length; i++)
            {
                bool checkNegativeUnit = false;

                while (!checkNegativeUnit)
                {
                    Console.Write($"Please enter the value of {i+1}. coin as cent: ");

                    C[i] = int.Parse(Console.ReadLine());

                    if (C[i] <= 0)
                    {
                        Console.WriteLine("\tCoin should be positive integer");
                    }
                    else
                        checkNegativeUnit = true;
                }
            }
        }

        public static int [] bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            return arr;
        }

    }
}
