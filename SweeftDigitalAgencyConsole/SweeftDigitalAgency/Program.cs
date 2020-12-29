using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SweeftDigitalAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Choose Task : ");
                int numberForTask = Convert.ToInt32(Console.ReadLine());

                switch (numberForTask)
                {
                    case 1:
                        Console.WriteLine("Enter Text");
                        bool resultPalindrome = IsPalindrome(Console.ReadLine());
                        Console.WriteLine($"The text is Palindrome : {resultPalindrome}");
                        break;

                    case 2:
                        Console.WriteLine("Enter Amount");
                        int resultSplit = MinSplit(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Minimum Coins acount is : {resultSplit}");
                        break;

                    case 3:
                        int[] arrayInt = new int[7];
                        Console.WriteLine("Enter Array Elements");
                        for (int i = 0; i < arrayInt.Length; i++)
                        {
                            arrayInt[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        int resultNotInArray = NotContains(arrayInt);
                        Console.WriteLine($"Minumum Element Without Array is :{resultNotInArray}");
                        break;

                    case 4:
                        Console.WriteLine("Enter String");
                        bool resultProperly = IsProperly(Console.ReadLine());
                        if (resultProperly)
                        {
                            Console.WriteLine("Is Properly");
                        }
                        else
                        {
                            Console.WriteLine("Isn't Properly");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Stears");
                        int result = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Counted Variant Is : {CountVariants(result)}");
                        break;

                    case 6:
                        DeleteElementOoneTime();
                        break;

                    case 7:
                        Console.WriteLine("Enter currency");
                        string currencyFrom = Console.ReadLine();
                        string currencyTo = Console.ReadLine();
                        double exchangeResult = ExchangeRate(currencyFrom, currencyTo);
                        Console.WriteLine($"Exchange Result Is : {exchangeResult}");
                        break;

                    default:
                        Console.WriteLine("Invalid Number");
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        public static Boolean IsPalindrome(String text)
        {
            string reversedString = new string(text.Reverse().ToArray());
            return string.Compare(text, reversedString) == 0 ? true : false;
        }

        public static int MinSplit(int amount)
        {
            //1,5,10,20 და 50
            int result;
            if (amount % 50 == 0)
            {
                result = amount / 50;
            }
            else
            {
                int coinOne = amount / 50;
                amount -= coinOne * 50;

                int cointTwo = amount / 20;
                amount -= cointTwo * 20;

                int coinThree = amount / 10;
                amount -= coinThree * 10;

                int coinFour = amount / 5;
                amount -= coinFour * 5;

                result = coinOne + cointTwo + coinThree + coinFour + amount;
            }

            return result;
        }

        public static int NotContains(int[] array)
        {
            int notConteinNumber = 0;
            Array.Sort(array);
            if (Array.BinarySearch(array, 1) == -1)
            {
                notConteinNumber = 1;
            }
            else
            {
                for (int i = 0; i <= array.Length; i++)
                {
                    if (array[i] > 0 && (array[i] + 1 != array[i + 1]))
                    {
                        notConteinNumber = array[i] + 1;
                        break;
                    }

                }
            }

            return notConteinNumber;
        }

        public static Boolean IsProperly(String sequence)
        {
            int leftItem = 0;
            int rightItem = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                    leftItem++;
                if (sequence[i] == ')')
                    rightItem++;
            }

            bool isSuccess = leftItem == rightItem ? true : false;

            return isSuccess;
        }

        public static int CountVariants(int stearsCount)
        {
            if (stearsCount <= 1)
                return stearsCount;
            return CountVariants(stearsCount - 1) + CountVariants(stearsCount - 2);

        }

        public static void DeleteElementOoneTime()
        {
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("List Elements");
            foreach (var item in numberList)
            {
                Console.Write($"{item}");
            }
            Console.WriteLine();
            numberList.Remove(5);
            Console.WriteLine("After Delete 5");
            foreach (var item in numberList)
            {
                Console.Write($"{item}");
            }
            Console.WriteLine();
        }

        public static Double ExchangeRate(string fromCurrency, string toCurrency)
        {
            string fromCurrencyAppend = fromCurrency.ToUpper();
            string toCurrencyAppend = toCurrency.ToUpper();
            double curValueFrom = 0;
            double curValueTo = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("Currensies.xml");

            //Display all the td Tag
            XmlNodeList elemList = doc.GetElementsByTagName("td");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].InnerText == fromCurrencyAppend)
                {
                    curValueFrom = Convert.ToDouble(elemList[i + 2].InnerText);
                }

                if (elemList[i].InnerText == toCurrencyAppend)
                {
                    curValueTo = Convert.ToDouble(elemList[i + 2].InnerText);
                }

            }
            double result = Math.Round(curValueFrom / curValueTo,5);
            return result;
        }
    }

}


