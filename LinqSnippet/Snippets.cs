using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippet
{
    public class Snippets
    {

        static public void BasicLinq()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };
            Console.WriteLine("--------Use select--------");
            var carLista = from car in cars select car;
            foreach (var item in carLista) Console.WriteLine(item);

            // use where
            Console.WriteLine("--------Use select and where--------");
            var audiLista = from car in cars where car.Contains("Audi") select car;
            foreach (var item in audiLista) Console.WriteLine(item);

        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9 };
            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

            foreach(var item in  processedNumberList) Console.WriteLine(item);
        }

        static public void SearchExamples()
        {
            List<string> textLista = new List<string>
            {
                "a","bx","c","d","e","cj","f","c"
            };

            var first = textLista.First();

            var ctext = textLista.First(value => value.Equals("c"));

            var jtext = textLista.First(value => value.Equals("j"));

            var firstOrDefault = textLista.FirstOrDefault(value => value.Contains("x"));

            var lastOrDefault = textLista.LastOrDefault(value => value.Contains("z"));

            var uniqueText = textLista.Single();
            var uniqueOrDefault = textLista.SingleOrDefault();

            int[] eventNumbers = { 0, 2, 4, 6, 8 };
            int[] otherNumbers = { 0, 2, 6};

            var myEventNumbers = eventNumbers.Except(otherNumbers);


        }

        static public void MultipleSelector()
        {
            string[] myOptions =
            {
                "Optión 1, text 1",
                "Optión 2, text 2",
                "Optión 3, text 3"
            };

            var myOptionsSelection = myOptions.SelectMany(value => value.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Marco",
                            Email="Marco@example.com",
                            Salary = 400
                        },
                        new Employee
                        {
                            Id=2,
                            Name="Luis",
                            Email="luis@example.com",
                            Salary = 500
                        },
                        new Employee
                        {
                            Id=3,
                            Name="Maria",
                            Email="maria@example.com",
                            Salary = 800
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id=4,
                            Name="Pepe",
                            Email="pepe@example.com",
                            Salary = 500
                        },
                        new Employee
                        {
                            Id=5,
                            Name="Jessica",
                            Email="jessica@example.com",
                            Salary = 850
                        },
                        new Employee
                        {
                            Id=6,
                            Name="Nataly",
                            Email="nataly@example.com",
                            Salary = 320
                        }
                    }
                }
            };

            var employeeLista = enterprises.SelectMany(value => value.Employees);

            bool hasEnterprise = enterprises.Any();

            bool hasEmployee = enterprises.Any(value => value.Employees.Any());

            bool hasEmployeeWithSalaryMoreThanOrEqual500 =
                enterprises.Any(value =>
                value.Employees.Any(emp => emp.Salary >= 500));

        }

        static public void linqColletion()
        {
            var firslista = new List<string>() { "a","b","c"};
            var secondlista = new List<string>() { "a", "c", "d" };


            // inner join
            var commanResult = from element in firslista
                               join secondElement in secondlista
                               on element equals secondElement
                               select new { element, secondElement };
            var commandResult2 = firslista.Join(
                secondlista,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement}
                );


            // outer join - left
            var leftOuterJoin = from a in firslista
                                join b in secondlista
                                on a equals b
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where a != temporalElement
                                select new { Element = a };

            var leftOuterJoin2 = from a in firslista
                                 from b in secondlista.Where(val => val == a).DefaultIfEmpty()
                                 select new { Element = a, SecondElement = b };

            // outer join - right
            var rightOuterJoin = from a in secondlista
                                 join b in firslista
                                 on a equals b
                                 into temporalLista
                                 from temporalElement in temporalLista.DefaultIfEmpty()
                                 where a != temporalElement
                                 select new { Element = a };

            // union
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myLista = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            var skipTwoFirsValue = myLista.Skip(2);
            var skipLastTwoValues = myLista.SkipLast(2);
            var skipWhileSmallerThan4 = myLista.SkipWhile(num => num < 4);

            var takefirstvalues = myLista.Take(2);
            var takelasttwovaluse = myLista.TakeLast(2);
            var takewhilesmallerthan4 = myLista.TakeWhile(num => num < 4);

        }

    }
}
