using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeferredAndImmediateExcutionInLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var empTable = new List<Employee>(new Employee[] {
            new Employee(){  Id=1, Name="Pawan", Age=35},
            new Employee(){  Id=2, Name="Kamal", Age=70},
            new Employee(){  Id=3, Name="Rohit", Age=73}


            });
/* The query is actually executed when the query variable is iterated over, not when the query variable is created. 
This is called deferred execution.
---------------------------------------------------
Deferred execution is important as it gives you the flexibility of constructing a query in several steps
 by separating query construction from query execution.
------------------------------------------------------------------------------------
This allows you to execute a query as frequently as you want to, like fetching the latest information from a database that is being updated frequently by other applications.
 You will always get the latest information from the database in this case.
----------------------------------------------------------------------------------
The basic difference between a Deferred execution vs Immediate execution is that Deferred execution of queries produce a sequence of values, 
whereas Immediate execution of queries return a singleton value and is executed immediately.
--------------------------------------------------------------------------------------------------
To force immediate execution of a query that does not produce a singleton value, you can call the ToList(), ToDictionary() or the ToArray() method on a query or query variable. These are called conversion operators which allow you to make a copy/snapshot of the result and access is as many times you want, without the need to re-execute the query.
*/
            var ImmediateQuery = (from e in empTable where e.Age > 45 select new { e.Name }).ToList();

            empTable.Add(new Employee() { Id = 1, Name = "dolly", Age = 90 });
            foreach (var item in ImmediateQuery)
            {
            Console.Write(item.Name +",");

            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            var DeferredQuery = (from e in empTable where e.Age > 45 select new { e.Name });

            empTable.Add(new Employee() { Id = 1, Name = "dolly", Age = 90 });
            foreach (var item in DeferredQuery)
            {
            Console.Write(item.Name + ",");

            }
        }
    }
  
}
   
