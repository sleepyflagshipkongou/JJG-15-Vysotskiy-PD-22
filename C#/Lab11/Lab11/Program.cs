namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            patient first = new patient();

            Hospital hospital = new Hospital();


            hospital.RenAndex(first);
            hospital.DisplayInfo(first);
            Console.WriteLine();
            hospital.CompleteProduct(first);
            hospital.DisplayInfo(first);

            //task 2
            List<Student> pd22Group = new List<Student>();

            pd22Group.Add(new Student("Vlad", "Osymak", 17));
            pd22Group.Add(new Student("Valera", "Bilous", 18));
            pd22Group.Add(new Student("Roma", "Oleksenko", 20));
            pd22Group.Add(new Student("Dana", "Prokopets", 19));
            pd22Group.Add(new Student("Valentyn", "Shovtenko", 21));
            pd22Group.Add(new Student("Dima", "Vdovin", 23));
            pd22Group.Add(new Student("Artem", "Iluchenko", 24));
            pd22Group.Add(new Student("Bohdan", "Student", 50));
            pd22Group.Add(new Student("Vitalik", "Woloshyn", 44));
            pd22Group.Add(new Student("Edik", "Petrenko", 14));


            List<Student> adults = new List<Student>();
            StudentPredicateDelegate spd;

            Console.WriteLine("\nТолько взрослые");
            spd = Student.Adult;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nСтуденты которые имеют первую букву «А»");
            spd = Student.FirstSymbolIsA;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nСтуденты которые имеют больше 3-х символов ");
            spd = Student.LongLastName;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nВзросыле через методы");
            spd = student => student.Age >= 18 ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nСтуденты которые имеют первую букву «А» через методы");
            spd = student => student.FirstName[0] == 'A' ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nСтуденты которые имеют больше 3-х символов через методы");
            spd = student => student.LastName.Length > 3 ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();


            Console.WriteLine("\n\n20-25 лет");
            spd = student => student.Age > 20 && student.Age < 25 ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nИщем Диму здесь");
            spd = student => student.FirstName == "Dima" ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

            Console.WriteLine("\nИщем Белоуса здесь");
            spd = student => student.LastName == "Bilous" ? true : false;
            adults = pd22Group.FindStudent(spd);
            adults.DisplayList();

        }
    }
}