namespace LinQLab1
{
    class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
    class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] Subjects { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var q1 = numbers.OrderBy(x => x).Distinct();
            foreach (var x in q1)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("=============================================");
            foreach (var x in q1)
            {
                Console.WriteLine($"< Number = {x}, Multiply = {x * x} >");
            }
            #endregion
            #region Task 2
            Console.WriteLine("=============================================");
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            var q2 = names.Where(x => x.Length == 3);
            foreach (var x in q2)
            {
                Console.WriteLine(x);
            }
            var q3 = from x in names
                     where x.Length == 3
                     select x;
            Console.WriteLine("=============================================");
            foreach (var x in q3)
            {
                Console.WriteLine(x);
            }
            var q4 = names.Where(x => x.ToLower().Contains("a")).OrderBy(x => x.Length);
            Console.WriteLine("=============================================");
            foreach (var x in q4)
            {
                Console.WriteLine(x);
            }
            var q5 = from x in names
                     where x.ToLower().Contains("a")
                     orderby x.Length
                     select x;
            Console.WriteLine("=============================================");
            foreach (var x in q5)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("=============================================");
            var q6 = names.Take(2);
            foreach (var x in q6)
            {
                Console.WriteLine(x);
            }
            var q7 = (from x in names
                      select x).Take(2);
            Console.WriteLine("=============================================");
            foreach (var x in q7)
            {
                Console.WriteLine(x);
            }
            #endregion
            #region Task 3
            List<Student> students = new List<Student>()
        {
            new Student()
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Mohammed",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 33, Name = "UML" }
                }
            },
            new Student()
            {
                ID = 2,
                FirstName = "Mona",
                LastName = "Gala",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 34, Name = "XML" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 3,
                FirstName = "Yara",
                LastName = "Yousf",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Ali",
                Subjects = new Subject[]
                {
                    new Subject() { Code = 33, Name = "UML" }
                }
            }
        };
            var q8 = students.Select(x => new
            {
                FullName = $"{x.FirstName} {x.LastName}",
                NumberOfSubjects = x.Subjects.Count()
            });
            foreach (var x in q8)
            {
                Console.WriteLine($"< Full Name = {x.FullName}, Number of Subjects = {x.NumberOfSubjects} >");
            }
            Console.WriteLine("=============================================");
            var q9 = students.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName).Select(x => $"{x.FirstName} {x.LastName}");
            foreach (var x in q9)
            {
                Console.WriteLine(x);
            }
            var q10 = students.SelectMany(x => x.Subjects,
                (x, y) => new { StudentName = x.FirstName + " " + x.LastName, SubjectName = y.Name });
            Console.WriteLine("=============================================");
            foreach (var x in q10)
            {
                Console.WriteLine($"< {x} >");
            }
            Console.WriteLine("=============================================");
            var q11 = students.SelectMany(student => student.Subjects,(student, subject) => new { student, subject })
                .GroupBy(x => x.student.FirstName + " " + x.student.LastName,x => x.subject,(key, values) => new { StudentName = key, Subjects = values });

            foreach (var item in q11)
            {
                Console.WriteLine(item.StudentName);
                foreach (var subject in item.Subjects)
                {
                    Console.WriteLine($"\t {subject.Name}");
                }
            }
            #endregion
            //var q100 = students.SelectMany(s => s.Subjects.Select(sub => new { s.FirstName ,sub.Name } ));
            //foreach (var item in q11)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
