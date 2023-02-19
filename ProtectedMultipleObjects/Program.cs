﻿using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{
    //Base Class
    class Member
    {
        protected int _Id;
        protected string _FirstName;
        protected string _LastName;
        protected int _Age;
        protected string _Email;

        // default constructor
        public Member()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
            _Email = string.Empty;
        }
        //parameterized constructor
        public Member(int id, string firstName, string lastName, int age, string email)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
            _Email = email;
        }
      
        public virtual void addChange()
        {
            Console.Write("ID=");
            _Id=int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName=Console.ReadLine();
            Console.Write("Age=");
           _Age =int.Parse(Console.ReadLine());
            Console.Write("Email=");
            _Email =Console.ReadLine();
        }
        public virtual void print()
        {

            Console.WriteLine("       Standard Member Information     ");
            Console.WriteLine();
            Console.WriteLine($"      ID: {_Id}");
            Console.WriteLine($"    Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}");
            Console.WriteLine($"    Email: {_Email}");
        }
    }
    class Premium : Member
    {
        private string _MothersMaidenName;
        private int _ZipCode;

        public Premium()
            
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
            _Email = string.Empty;
            _ZipCode = 0;
            _MothersMaidenName = string.Empty;
        }
        public Premium(int id, string firstname, string lastname, int age, string email, string mothersmaidenname, int zipcode)
            : base(id, firstname, lastname, age, email)
        {
            _Id = id;
            _FirstName = firstname;
            _LastName = lastname;
            _Age = age;
            _Email = email;
            _MothersMaidenName = mothersmaidenname;
            _ZipCode = zipcode;
        }
       
        public override void addChange()
        {
            Console.Write("ID=");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName = Console.ReadLine();
            Console.Write("Age=");
            _Age = int.Parse(Console.ReadLine());
            Console.Write("Email=");
            _Email = Console.ReadLine();
            Console.Write("Mother's Maiden Name=");
            _MothersMaidenName = Console.ReadLine();
            Console.Write("Zip Code=");
            _ZipCode = int.Parse(Console.ReadLine());
        }
        public override void print()
        {
            Console.WriteLine("       Premium Member Information     ");
            Console.WriteLine();
            Console.WriteLine($"     ID: {_Id}     Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}   Zip Code: {_ZipCode}");
            Console.WriteLine($"     Mother's Maiden Name: {_MothersMaidenName}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many Standard PC Gaming Club Members do you want to enter?");
            int maxMbr;
            while (!int.TryParse(Console.ReadLine(), out maxMbr))
                Console.WriteLine("Please enter a whole number");
            // array of Employee objects
            Member[] mbr = new Member[maxMbr];
            Console.WriteLine("How many Premium PC Gaming Club Members do you want to enter?");
            int maxPrm;
            while (!int.TryParse(Console.ReadLine(), out maxPrm))
                Console.WriteLine("Please enter a whole number");
            // array of Premium Member objects
            Premium[] prm = new Premium[maxPrm];

            int choice, rec, type;
            int mbrCounter = 0, prmCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Premium Member or 2 for Standard Member");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Premium Member or 2 for Standard Member");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //Premium
                            {
                                if (prmCounter <= maxPrm)
                                {
                                    prm[prmCounter] = new Premium(); // places an object in the array instead of null
                                    prm[prmCounter].addChange();
                                    prmCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of Premium Members has been added");

                            }
                            else //member
                            {
                                if (mbrCounter <= maxMbr)
                                {
                                    mbr[mbrCounter] = new Member(); // places an object in the array instead of null
                                    mbr[mbrCounter].addChange();
                                    mbrCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of Premium Members has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //Premium Member
                            {
                                while (rec > prmCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                prm[prmCounter].addChange();
                            }
                            else // member
                            {
                                while (rec > mbrCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mbr[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //PremiumMember
                            {
                                for (int i = 0; i < prmCounter; i++)
                                    prm[i].print();
                            }
                            else // Employee
                            {
                                for (int i = 0; i < mbrCounter; i++)
                                    mbr[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}

