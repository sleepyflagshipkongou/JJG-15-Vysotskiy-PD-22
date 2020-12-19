namespace lab11
{
    delegate bool StudentPredicateDelegate(Student student);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0) age = 17;
                else { age = value; }
            }
        }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public static bool Adult(Student student)
        {
            if (student.Age >= 18) return true;
            return false;
        }

        public static bool FirstSymbolIsA(Student student)
        {
            if (student.FirstName[0] == 'A') return true;
            return false;
        }

        public static bool LongLastName(Student student)
        {
            if (student.LastName.Length > 3) return true;
            return false;
        }
    }
}