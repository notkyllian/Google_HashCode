using System;
using System.Collections.Generic;

namespace HashCode
{
    public class Pizza
    {
        public int slices;
    }
    public class Order
    {
        public int maxslices;
        public List<Pizza> list = new List<Pizza>();
    }
    class Program
    {

        private static void sum_up(List<int> numbers, int target)
        {
            sum_up_recursive(numbers, target, new List<int>());
        }

        private static void sum_up_recursive(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int x in partial) s += x;

            if (s == target)
                Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);

            if (s >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                List<int> partial_rec = new List<int>(partial);
                partial_rec.Add(n);
                sum_up_recursive(remaining, target, partial_rec);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Begin...");

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Refactor\source\repos\HashCode\HashCode\HashCode\HashCode\order1.txt");

            /*
             * 
             *          100 10
             *          4 14 15 18 29 32 36 82 95 95
             * 
             * 
             */




            //1 lijn
            // 0 1
            // 0 = maxslices 
            // 1 = useless
            string lijn1 = lines[0]; string[] n1 = lijn1.Split(' ');
            Order order = new Order();
            order.maxslices = Convert.ToInt32(n1[0]);
            Console.WriteLine($"Max amount of slices: {order.maxslices}");




            //2delijn
            // per spatie een index
            // Order.list.add(New pizza(index));
            string lijn2 = lines[1]; string[] n2 = lijn2.Split(' ');

            foreach (var slices in n2)
            {
                Pizza p = new Pizza();
                p.slices = Convert.ToInt32(slices);
                order.list.Add(p);
            }

            Console.WriteLine($"Amount of pizzas: {order.list.Count}");
            Console.WriteLine("");



            

            List<int> integers = new List<int>();
            foreach(Pizza p in order.list)
            {
                Console.WriteLine($"Type {order.list.IndexOf(p)}: {p.slices} slices");
                integers.Add(p.slices);
            }
            Console.WriteLine("Starting calculations");

            sum_up(integers, order.maxslices);

















            Console.ReadKey();
        }

        // -----------------Problem Definition-----------------
        /*  
            The  pizzeria  has  different  types  of  pizza,  and  to  keep  the  food  ordering  for  your  hub                                
            interesting,  you  can  only  order at  most  one  pizza  of  each  type.  
            
            Fortunately,  there  are many   types   of   pizza   to   choose from!  
            
            Each  type  of  pizza  has  a  specified  size:  the  size  is  the  number  of  slices  in  a  pizza  of  this type. 
            
            You estimated  the  maximum  number  of  pizza  slices  that  you  want  to  order  for  your hub  based  on  the  number  of  registered  participants.  

            In  order  to  reduce  food  waste, your  goal  is  to  order as  many  pizza  slices  as  possible,  but not  more  than  the maximum   number . 

         */

        // -----------------Input data set-----------------
        /*
         *  The first line of the data set contains the following data:
         *  The second line contains N (number) integers -> the number of slices in each type of pizza in non-decreasing order.
         * 
         *  Example file:   Description:
         *  17 4            17 slices maximum, 4 diffrent types of pizza.
         *  2 5 6 8         Type 0 has 2 slices, Type 1 has 5 slices, Type 2 has 6 slices and Type 3 has 8 slices
         * 
         * https://i.imgur.com/C5USPht.png
         * 
         */

        // -----------------Output data set-----------------
        /*
         * The output should contain two lines:
                ● The first line should contain a single integer K (0 ≤ K ≤ N) -> the number of different types of pizza to order.
                ● The second line should contain K numbers 
                –>  the types of pizza to order (the types of pizza are numbered from 0 to N-1 in the order they are listed in the input).
        */

        // ----------------- Example -----------------
        /*
         * 
         * 
         * So in the example input file we know we need 17 slices maximum and there are 4 different types of pizza:
         *              - Type 0: 2 slices
         *              - Type 1: 5 slices
         *              - Type 2: 6 slices
         *              - Type 3: 8 slices
         *              
         * Optimal output file:
         * 3 types of pizza
         * 
         * 0 2 3 
         * 
         * Pizza 0 has 2 slices
         * Pizza 2 has 6 slices
         * Pizza 3 has 8 slices
         * 
         * 2+6+8 = 16 slices
         * 
         * 
         * 
         * 
         */

    }
}
