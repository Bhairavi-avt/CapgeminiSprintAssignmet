using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class student
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string smailid { get; set; }
        public string branch { get; set; }
        public double per { get; set; }

        public List<string> skills { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<student> Slist = new List<student>() {
             new student(){firstname="Anna",lastname="Delvey",smailid="anaa@gmail.com",branch="CS",per=76.90,skills=new List<string>{"C#.NET","SQL" } },
             new student(){firstname="John",lastname="Evans",smailid="john@gmail.com",branch="EC",per=83.67,skills=new List<string>{"C#.NET","JAVA" } },
              new student(){firstname="Anna",lastname="Galdot",smailid="smith@gmail.com",branch="EC",per=55.87 ,skills=new List<string>{"PHP","SQL" }},
              new student(){firstname="Monica",lastname="Richards", smailid="monica@gmail.com",branch="CS",per=87.00,skills=new List<string>{"HTML","JAVASCRIPT" } },
              new student(){firstname="Ross",lastname="Richards", smailid="ross@gmail.com",branch="ENTC",per=60.87,skills=new List<string>{"DJANGO","SQL" } }
            };

            

            //Select
            Console.WriteLine("------------Select------------------------"); 

            var query = Slist.Select(i => i); 

            foreach (var i in query)
            {
                Console.WriteLine(i.firstname + "," + i.lastname + ","+ i.smailid + "," + i.branch + "," + i.per);
            }

            Console.WriteLine("------------SelectMany------------------------");
            var selectm = Slist.SelectMany(i => i.skills);
            foreach (var i in selectm)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("-------------------");

            //Select, where
            Console.WriteLine("------------where------------------");

            var query1 = from i in Slist where i.per > 65 & i.per< 90 select i; 
          
            foreach (var i in query1)
            {
                Console.WriteLine(i.firstname + "," + i.lastname + ","+ i.smailid + "," + i.branch + "," + i.per);
            }
            Console.WriteLine("-------------------");

            // Let
            
            Console.WriteLine("---------Let-----------------");
            var query2 = from i in Slist let res = i.per + 10 select res; 

            foreach (int i in query2)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("-------------------");

            //Into
            Console.WriteLine("---------Into-----------------");
            var INTO = from i in Slist
                       where i.branch == "CS"
                       select i into res
                       where res.firstname.StartsWith("M")
                       select res;
            foreach (var i in INTO)
            {
                Console.WriteLine(i.firstname + "," + i.lastname);
            }
            Console.WriteLine("-------------------");

            //OFFTYPE
            Console.WriteLine("---------OFFTYPE-Double-----------------");
            var offd = (from i in Slist select i.per).OfType<double>();
            foreach(var i in offd)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine("-------------------");

            Console.WriteLine("---------OFFTYPE-string-----------------");
            var offs = (from i in Slist select i.firstname).OfType<string>();
            foreach (var i in offs)
            {
                Console.WriteLine(i);

            }
            Console.WriteLine("-------------------");


            //take,takewhile,skip,skipwhile
            Console.WriteLine("-----------Take------------------");
            
            IEnumerable<student> query3 = (from i in Slist where i.per > 55 select i).Take(4);
            foreach (var i in query3)
            {
                Console.WriteLine(i.firstname + " ," + i.lastname);
            }
            Console.WriteLine("-----------SKIP QUERY----------");
            var query4 = Slist.Skip(2);
            foreach (var i in query4)
            {
                Console.WriteLine(i.firstname + "," + i.lastname);
            }

            Console.WriteLine("-------------TAKE WHILE QUERY-------------");
            var query5 = Slist.TakeWhile(i => i.firstname == "Anna");
            foreach (var i in query4)
            {
                Console.WriteLine(i.firstname + " ," + i.lastname);
            }
            Console.WriteLine("-------------SKIP WHILE QUERY------------");
            var query6 = Slist.SkipWhile(i => i.firstname == "Monica");
            foreach (var i in query6)
            {
                Console.WriteLine(i.firstname + " ," + i.lastname);
            }




            //first,firstordefault,last,lastdefault,single,singleordefault,elementat,elementatordefault.

            Console.WriteLine("---------------first----------------.");

            var query55 = (from i in Slist where i.branch == "CS" select i.firstname).First();
            Console.WriteLine(query55);
            
            Console.WriteLine("---------FirstOrDefault----------");

            var query9 = (from i in Slist where i.branch == "EC" select i.firstname).FirstOrDefault();
            Console.WriteLine(query9);
            
            Console.WriteLine("---------Last----------");

            var query10 = (from i in Slist where i.branch == "CS" select i.firstname).Last();
            Console.WriteLine(query10);
            
            Console.WriteLine("-----------LastOrDefault--------");


            var query11 = (from i in Slist where i.branch == "EC" select i.firstname).LastOrDefault();
            Console.WriteLine(query11);
            
            Console.WriteLine("---------Single----------");

            var query12 = (from i in Slist where i.branch == "ENTC" select i.firstname).Single();
            Console.WriteLine(query12);
            
            Console.WriteLine("----------SingleOrDefault---------");

            var query13 = (from i in Slist where i.branch == "ENTC" select i.firstname).SingleOrDefault();
            Console.WriteLine(query13);
            
            Console.WriteLine("-------ElementAt------------");

            var query14 = (from i in Slist select i.firstname).ElementAt(4);
            Console.WriteLine(query14);
            
            Console.WriteLine("--------ElementAtOrDefault-----------");

            var query15 = (from i in Slist select i.lastname).ElementAtOrDefault(5);
            Console.WriteLine(query15);
            Console.WriteLine("-------------------");


            //order by,group by
           

            Console.WriteLine("------------ORDER BY QUERY (DESCENDING)----------");
            var query16 = Slist.OrderByDescending(i => i.lastname);
            foreach (var i in query16)
            {
                Console.WriteLine(i.firstname + " " + i.lastname);
            }
            Console.WriteLine("-----------ORDER BY QUERY (ASCENDING)-------------");

            var query17 = Slist.OrderBy(i => i.lastname);
            foreach (var i in query17)
            {
                Console.WriteLine(i.firstname + " " + i.lastname);
            }

            Console.WriteLine("------------GroupBy-------");

            var query18 = Slist.GroupBy(i => i.branch);

            foreach (var group in query18)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("Group By");
                foreach (var i in group)
                {
                    Console.WriteLine(i.firstname + "," + i.per);
                }
            }
            Console.WriteLine("-------------------");

            //Aggregate function
            Console.WriteLine("-------------Aggregate function-----------------");
            Console.WriteLine("--------------------Sum-----------------------------");

            double sum = (from i in Slist select i.per).Sum(); //Linq
           //double sum = Slist.Select(i=>i.per).Sum(); //Lamda
            Console.WriteLine(sum);
            Console.WriteLine("-------------------");

            Console.WriteLine("------------------Max----------------------");

            double max = (from i in Slist  select i.per).Max();

            Console.WriteLine(max);
            Console.WriteLine("-------------------");


            Console.WriteLine("---------------Avg-----------------------");
            double avg = (from i in Slist select i.per).Average();

            Console.WriteLine(avg);
            Console.WriteLine("-------------------");

            Console.WriteLine("------------Count------------------");
            int count = (from i in Slist select i).Count();

            Console.WriteLine(count);
            Console.WriteLine("-------------------");


            Console.WriteLine("-----------Distinct--------------");
            List<int> list2 = new List<int>() { 1, 2, 3, 1, 2, 4, 5, 3, 6, 5 };
            var query19 = list2.Distinct();

            foreach (var i in query19)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------------");

            
            Console.WriteLine("IEnumerable,IQueryable<");

            //IEnumerable<student> query20 = (from i in Slist select i).AsEnumerable();

            IQueryable<student> query21 = (from i in Slist select i).AsQueryable();

            Console.WriteLine("-------------------");

            // startswith,endswith,contains
            Console.WriteLine("Startswith");

            var query22 = Slist.Where(i => i.firstname.StartsWith('A'));

            foreach (var i in query22)
            {
                Console.WriteLine(i.firstname);
            }

            Console.WriteLine("-------------------");

            Console.WriteLine("Endswith");

            var query23 = Slist.Where(i => i.lastname.EndsWith('S'));
            foreach (var i in query23)
            {
                Console.WriteLine(i.lastname);
            }
            Console.WriteLine("-------------------");

            Console.WriteLine("Contains");

            var query24 = Slist.Where(i => i.firstname.Contains('a'));
            foreach (var i in query24)
            {
                Console.WriteLine(i.firstname);
            }

            //Deferred and immediate execution
            Console.WriteLine("----------------Deferred Execution-------------------------------");
            Slist.Add(new student() { firstname = "Sana", lastname = "Gill", smailid = "sana@gmail.com", branch = "EE", per = 94 });
            var query25 = Slist.Select(i => i); 

            foreach (var i in query25)
            {
                Console.WriteLine(i.firstname + "," + i.lastname + "," + i.smailid + "," + i.branch + "," + i.per);
            }

            Console.WriteLine("-------------------");
            
            Console.WriteLine("-----------------Immediate Execution-------------------");
            var query26 = (from i in Slist where i.per < 80 select i).Count();
            Console.WriteLine("Count of values per<80:" +query26);
            Console.WriteLine("-------------------");

           

                                                             Console.WriteLine("----------Task2---------");
            int[] array1 = new int[] { 10, 20, 10, 50, 60, 30, 40, 70, 80, 90,100 };
            int[] array2= new int[] { 5, 7, 55, 66, 27, 38, 90, 44, 12, 45 };

            var query31 = array1.Except(array2);
            Console.WriteLine("\n------------Expect Query-----------");
            foreach (var i in query31)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("\n-------------Union Query------------");
            var query32 = array1.Union(array2);
            foreach (var i in query32)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("---------------Intersect Query----------");
            var query33 = array1.Intersect(array2);
            foreach (var i in query33)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("---------------Concat Query----------");
            var query34 = array1.Concat(array2);
            foreach (var i in query34)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine("-----------------------");

            Console.WriteLine("Aggregate Functions:-");

            Console.WriteLine("-----------------------");

            Console.WriteLine("Sum:-");

            int sum1 = (from i in array1 select i).Sum();
            int sum2 = (from i in array2 select i).Sum();

            Console.WriteLine("Total Sum of two arrays:-" + (sum1 + sum2));

            Console.WriteLine("-----------------------");
            Console.WriteLine("Max:-");

            int max1 = (from i in array1 select i).Max();
            int max2 = (from i in array2 select i).Max();

            Console.WriteLine("Maximum number in both arrays:-" + (max1, max2));

            Console.WriteLine("-----------------------");
            Console.WriteLine("Min:-");

            int min1 = (from i in array1 select i).Min();
            int min2 = (from i in array2 select i).Min();

            Console.WriteLine("Minimum number in both arrays:-" + (min1, min2));

            Console.WriteLine("-----------------------");
            Console.WriteLine("Average:-");

            double avg1 = (from i in array1 select i).Average();
            double avg2 = (from i in array2 select i).Average();

            Console.WriteLine("Average of arrays:-" + (avg1, avg2));

            Console.WriteLine("-----------------------");
            Console.WriteLine("Count:-");

            int count1 = (from i in array1 select i).Count();
            int count2 = (from i in array2 select i).Count();

            Console.WriteLine("Total number of elements in two arrays:-" + (count1, count2));
























        }
    }
}