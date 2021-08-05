﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp_PayRoll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementaion of PayRoll service using ADO.NET");
            PayRoll_Service payRoll = new PayRoll_Service();
            bool Continue = true;
            while (Continue)
            {
                Console.WriteLine("1.Retrive all data\n2.Update salary\n3.Exit");
                Console.Write("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        payRoll.GetAllData();
                        break;
                    case 2:
                        payRoll.UpdateSalary();
                        break;
                    case 3:
                        Continue = false;
                        break;
                    default:
                        break;
                }
            }
            Console.Read();

        }
    }
}

