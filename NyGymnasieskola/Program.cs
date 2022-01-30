//Mattias Kokkonen SUT21
using NyGymnasieskola.Models;
using System;
using System.Linq;

namespace NyGymnasieskola
{
    class Program
    {
        static void Main(string[] args)
        {

            Meny();

            static void Meny()
                {

                SampleDbContext Context = new SampleDbContext();

                Console.WriteLine("Meny, välj en siffra\n1: Se alla Studerande Förnamn\n1: Se alla Studerande EfterName\n3: se alla lärare\n4: Hämta ut alla elever i en viss klass\n5: Lägg till Personal");
                byte KontoVal = 0;
                bool input = false;
                do
                {

                    input = byte.TryParse(Console.ReadLine(), out KontoVal);
                    if (input == false)
                    {
                        Console.WriteLine("Ogiltigt val!");

                    }
                } while (input == false);

                switch (KontoVal)
                {
                    case 1:
                        SeeAllStudForeName(Context);
                        Console.WriteLine("-----------------");
                        Meny();
                        break;
                    case 2:
                        SeeAllStudLastName(Context);
                        Console.WriteLine("-----------------");
                        Meny();
                        break;
                    case 3:
                        SeeAllTeachers(Context);
                        Console.WriteLine("-----------------");
                        Meny();
                        break;
                    case 4:
                        EleverIEnKlass(Context);
                        Console.WriteLine("-----------------");
                        Meny();
                        break;
                    case 5:
                        AddEmployee(Context);
                        Console.WriteLine("-----------------");
                        Meny();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        Meny();
                        break;
                }


            }


        }
        public static void SeeAllStudForeName(SampleDbContext Context)
        {

            var Eleven = from Elev in Context.Student
                         orderby Elev.FName ascending
                         select Elev;
            Console.WriteLine("Alla elever:");
            foreach (var item in Eleven)
            {
                Console.Write($" Namn: {item.FName} ");
                Console.Write($" {item.LName}");
                Console.WriteLine();
            }
        }
        public static void SeeAllStudLastName(SampleDbContext Context)
        {

            var Eleven = from Elev in Context.Student
                         orderby Elev.LName ascending
                         select Elev;
            Console.WriteLine("Alla elever:");
            foreach (var item in Eleven)
            {
                Console.Write($" Namn: {item.FName} ");
                Console.Write($" {item.LName}");
                Console.WriteLine();
            }
        }
        public static void SeeAllTeachers(SampleDbContext Context)
        {
            Console.WriteLine("");
            Console.WriteLine("Alla lärare:");
            var Teacher = Context.Employee
                          .Where(p => p.WorkRole == "Lärare")
                          .OrderBy(p => p.FName);
            foreach (var item in Teacher)
            {
                Console.Write($" Namn :{item.FName} ");
                Console.Write($" {item.LName}");
                Console.WriteLine();
            }
        }
        public static void EleverIEnKlass(SampleDbContext Context)
        {
            Console.WriteLine("Meny, Skriv in en klass\nEngelska\nSvenska\nMatte\nSamhäll");

            string input = Console.ReadLine();

            var innerjoining = Context.Student.Join(Context.Course,
                Student => Student.StudentId,
                Course => Course.StudentId,
                    (Student, Course) => new
                    {
                        FName = Student.FName,
                        CourseName = Course.CourseName
                    }
                ).Where(p => p.CourseName == input);

            foreach (var item in innerjoining)
            {
                Console.Write($"Namn: {item.FName}");
                Console.Write($", Kurs:{item.CourseName}");
                Console.WriteLine();
            }



        }
        public static void AddEmployee(SampleDbContext Context)
        {

            Employee E1 = new Employee();
            Console.WriteLine("Skriv förnamn");
                string forename = Console.ReadLine();
                E1.FName = forename;
                Console.WriteLine("Skriv Efternamn");
                string lastname = Console.ReadLine();
                E1.LName = lastname;
                Console.WriteLine("Yrkesroll");
                string Role = Console.ReadLine();
                E1.WorkRole = Role;

            var TopId = Context.Employee.Where(e => e.EmployeeId >= E1.EmployeeId);
            int Key = 0;
            foreach (var item in TopId)
            {
                if(item.EmployeeId == Key)
                {
                    Key++;
                }
            }
            E1.EmployeeId = Key;

                Context.Add(E1);
                Context.SaveChanges();
            
        }
      
    }

}
