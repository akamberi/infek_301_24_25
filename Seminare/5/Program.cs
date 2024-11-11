using ConsoleApp8;

public class Program
{
    static ClassRoom classRoom;
    public static void Main(string[] args)
    {
        //classRoom = ClassRoom.CreateClassroom();
        classRoom = new ClassRoom
        {
            Name = "cs1",
            Profesor = new Person
            {
                Name = "ak",
                Surname = "ak",
                Password = "ak",
                PersonType = PersonType.PROFESOR
            },
            Students = new List<Person>()
        };
        Person authorizedUser = null;
        authorizedUser = Login();
        while (authorizedUser != null)
        {
            AfishoMenu(authorizedUser);
            ProcesoMenu(ref authorizedUser);
        }
    }

    public static Person Login()
    {
        Console.Write("Jep emrin e perdoruesit: ");
        string name = Console.ReadLine();
        Console.Write("Jep fjalekalimin e perdoruesit: ");
        string pass = Console.ReadLine();

        if (name == classRoom.Profesor.Name && pass == classRoom.Profesor.Password)
        {
            return classRoom.Profesor;
        }
        else
        {
            foreach (var std in classRoom.Students)
            {
                if (name == std.Name && pass == std.Password)
                {
                    return std;
                }
            }
        }
        Console.WriteLine("Kredenciale te pasakta");
        return Login();
    }

    static void AfishoMenu(Person authorizedUser)
    {        
        if (authorizedUser.PersonType == PersonType.PROFESOR)
        {
            Console.WriteLine("1. Shiko studentet");
            Console.WriteLine("2. Shto student");
        }
        else
        {
            Console.WriteLine("1. Shiko notat");
        }

        Console.WriteLine("0. Logout");
    }

    static void Logout(ref Person authorizedUser)
    {
        Console.WriteLine("Faleminderit qe perdoret programin tone.\nVendosni kredencialet per te vijuar perseri");
        authorizedUser = Login();
    }

    static void AfishoStudentet()
    {
        Console.WriteLine("Studentet e klases: ");        
        foreach (var student in classRoom.Students)
        {
            Console.WriteLine(student);
        }
        AfishoMenuPasStudenteve();
    }

    static void AfishoMenuPasStudenteve()
    {
        Console.WriteLine("1. Shto note");
        Console.WriteLine("0. Kthehu");
        if (Console.ReadLine() == "1")
        {
            //var std = classRoom.KerkoStudent(Console.ReadLine(), Console.ReadLine());            
        }
    }

    static void ProcesoMenu(ref Person authorizedUser)
    {
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                {
                    if (authorizedUser.PersonType == PersonType.PROFESOR)
                    {
                        AfishoStudentet();
                    }
                    else
                    {
                        authorizedUser.AfishoNotat();
                    }
                    break;
                }
            case "2":
                {
                    if (authorizedUser.PersonType == PersonType.PROFESOR)
                    {
                        classRoom.ShtoStudent();
                    }
                    break;
                }
            case "0":
                {
                    Logout(ref authorizedUser);
                    break;
                }
            default:
                {
                    Console.WriteLine("Veprimi i pasakte");
                    break;
                }
        }
    }

}
public enum PersonType
{
    STUDENT,
    PROFESOR
}

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public PersonType PersonType { get; set; }
    public List<int> Grades { get; set; }
    public bool HasPassed
    {
        get
        {
            if (PersonType == PersonType.PROFESOR)
                throw new ArgumentOutOfRangeException("Vetem per studentet mund te verifikohet jane kalues ose jo");
            if (Grades == null) throw new ArgumentNullException("Studenti nuk ka asnje note");
            return Grades.Average() > 4.0;
        }
    }

    public static Person CreateProfessor()
    {
        Person prof = new Person();
        Console.Write("Jep emrin e profesorit: ");
        prof.Name = Console.ReadLine();
        Console.Write("Jep mbiemrin e profesorit: ");
        prof.Surname = Console.ReadLine();
        Console.Write("Jep fjalekalimin: ");
        prof.Password = Console.ReadLine();
        prof.PersonType = PersonType.PROFESOR;
        return prof;
    }

    public static Person CreateStudent()
    {
        Person student = new Person();
        Console.Write("Jep emrin e studentit: ");
        student.Name = Console.ReadLine();
        Console.Write("Jep mbiemrin e studentit: ");
        student.Surname = Console.ReadLine();
        Console.Write("Jep fjalekalimin: ");
        student.Password = Console.ReadLine();
        student.Grades = new List<int>();
        student.PersonType = PersonType.STUDENT;
        return student;
    }

    public void AfishoNotat()
    {
        Console.WriteLine("Notat e studentit: ");
        foreach (var grade in Grades)
        {
            Console.Write(grade + "\t");
        }
        Console.WriteLine($"\nStudenti eshte: {(HasPassed ? "kalues" : "jo kalues")}");
    }

    public override string ToString()
    {
        return $"Emri: {Name} {Surname}";
    }

}
internal class ClassRoom
    {
        public string Name { get; set; }
        public List<Person> Students { get; set; }
        public Person Profesor { get; set; }
        public static ClassRoom CreateClassroom()
        {
            var r = new ClassRoom();
            Console.Write("Jep emrin e klases: ");
            r.Name = Console.ReadLine();
            r.Students = new List<Person>();
            r.Profesor = Person.CreateProfessor();
            return r;
        }

        public void ShtoStudent()
        {
            Students.Add(Person.CreateStudent());
        }

        public Person KerkoStudent(string name, string surname)
        {
            foreach (var std in Students)
            {
                if (std.Name == name && std.Surname == surname)
                    return std;
            }
            return null;
        }
    }
