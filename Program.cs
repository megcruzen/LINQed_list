﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQed_list
{
    class Program
    {
        static void Main(string[] args)
        {

        /* Restriction/Filtering Operations */

            // Find the words in the collection that start with the letter 'L'
                List<string> fruitList = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

                IEnumerable<string> LFruits = from fruit in fruitList
                    where fruit[0] == 'L'
                    select fruit;

                // fruitList.Where((fruit) => fruit[0] = 'L');

                // foreach (string fruit in LFruits)
                // {
                //     Console.WriteLine(fruit);
                // }

                Console.WriteLine($"Fruit that start with L: {String.Join(", ", LFruits)}");
                Console.WriteLine("--------");


            // Which of the following numbers are multiples of 4 or 6
                List<int> numbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

                IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0).OrderBy(n => n);

                // Console.WriteLine("Numbers that are multiples of 4 or 6:");
                // foreach (int number in fourSixMultiples) {
                //     Console.WriteLine(number);
                // }

                Console.WriteLine($"Numbers that are multiples of 4 or 6: {String.Join(", ", fourSixMultiples)}");
                Console.WriteLine("--------");


            /* Ordering Operations */

                // Order these student names alphabetically, in descending order (Z to A)
                    List<string> names = new List<string>()
                    {
                        "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                        "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                        "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                        "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                        "Francisco", "Tre"
                    };

                    IEnumerable<string> descend = from name in names
                        orderby name descending
                        select name;

                    Console.WriteLine($"Student names: {String.Join(", ", descend)}");
                    Console.WriteLine("--------");


                // Build a collection of these numbers sorted in ascending order
                    List<int> numberList = new List<int>()
                    {
                        15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                    };

                    IEnumerable<int> ascendingNumbers = from number in numberList
                        orderby number ascending
                        select number;

                    Console.WriteLine($"Ascending numbers: {String.Join(", ", ascendingNumbers)}");
                    Console.WriteLine("--------");


            /* Aggregate Operations */

                // Output how many numbers are in this list
                    List<int> numberCollection = new List<int>()
                    {
                        15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                    };

                    int numberOfNumbers = numberCollection.Count();
                    Console.WriteLine($"There are {numberOfNumbers} numbers in the collection.");
                    Console.WriteLine("--------");


                // How much money have we made?
                    List<double> purchases = new List<double>()
                    {
                        2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
                    };

                    double totalAmount = purchases.Sum();
                    Console.WriteLine($"We made ${totalAmount}.");
                    Console.WriteLine("--------");


                // What is our most expensive product?
                    List<double> prices = new List<double>()
                    {
                        879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
                    };

                    double mostExpensive = prices.Max();
                    Console.WriteLine($"Our most expensive product is ${mostExpensive}.");
                    Console.WriteLine("--------");



            /* Partitioning Operations */

                // Store each number in the following List until a perfect square is detected.
                    List<int> wheresSquaredo = new List<int>()
                    {
                        66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
                    };

                    foreach (int number in wheresSquaredo) {
                        // Console.WriteLine($"{number}: {Math.Sqrt(number)}");
                        Console.WriteLine($"{number}'s square root: {Math.Sqrt(number)}");
                    }

                    IEnumerable<int> notSquares =
                        wheresSquaredo.TakeWhile(number => ((Math.Ceiling(Math.Sqrt(number))*Math.Ceiling((Math.Sqrt(number))) != number)));

                    // foreach (int number in notSquares) {
                    //     Console.WriteLine($"The numbers occuring before the first perfect square are: {number}");
                    // }
                    Console.WriteLine($"The numbers occuring before the first perfect square are: {String.Join(", ", notSquares)}");
                    Console.WriteLine("--------");




            /* Using Custom Types */

                // Build a collection of customers who are millionaires

                    List<Customer> customers = new List<Customer>() {
                        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                    };

                    List<BankEntry> millionaireReport = customers.Where(customer => customer.Balance >= 1000000)
                    .Select(customer =>
                        new BankEntry {
                            Name = customer.Name,
                            Balance = customer.Balance,
                            Bank = customer.Bank
                        }
                    ).ToList();

                    foreach (BankEntry entry in millionaireReport)
                    {
                        Console.WriteLine($"{entry.Name} is a millionaire.");
                    }

                    Console.WriteLine("--------");


                    // Given the same customer set, display how many millionaires per bank.

                    IEnumerable<BankCount> bankMillionaires = (from millionaire in millionaireReport
                        group millionaire by millionaire.Bank into bankGroup
                        select new BankCount {
                            Name = bankGroup.Key,
                            Count = bankGroup.Count(millionaire => millionaire.Bank == bankGroup.Key)
                        });

                    Console.WriteLine("Number of millionaires at each bank:");
                    foreach (BankCount entry in bankMillionaires) {
                        Console.WriteLine($"{entry.Name}: {entry.Count}");
                    }
                    Console.WriteLine("--------");

            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
                */

                 // Create some banks and store in a List
                    List<Bank> banks = new List<Bank>() {
                        new Bank(){ Name="First Tennessee", Symbol="FTB"},
                        new Bank(){ Name="Wells Fargo", Symbol="WF"},
                        new Bank(){ Name="Bank of America", Symbol="BOA"},
                        new Bank(){ Name="Citibank", Symbol="CITI"},
                    };

                /*
                    You will need to use the `Where()`and `Select()` methods to generate instances of the following class.

                    public class ReportItem
                    {
                        public string CustomerName { get; set; }
                        public string BankName { get; set; }
                    }
                */

                IEnumerable<ReportItem> millionaireBanks = (from customer in customers
                    where customer.Balance >= 1000000
                    orderby customer.Name.Split(' ')[1]
                    join bank in banks on customer.Bank equals bank.Symbol
                    select new ReportItem {
                        CustomerName = customer.Name,
                        BankName = bank.Name
                    });

                Console.WriteLine("Millionaires and their banks:");
                foreach (var item in millionaireBanks)
                {
                    Console.WriteLine($"{item.CustomerName} at {item.BankName}");
                }

            }
    }

    public class Bank {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    public class Customer {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    internal class BankEntry {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    internal class BankCount {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    public class ReportItem {
        public string CustomerName {get; set;}
        public string BankName {get; set;}
    }
}


