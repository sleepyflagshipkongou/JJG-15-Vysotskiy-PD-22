namespace lab11
{
    static class Extension
    {
        public static List<Student> FindStudent(this List<Student> list, StudentPredicateDelegate spd)
        {
            List<Student> reqList = new List<Student>();
            foreach (Student st in list)
            {
                if (spd.Invoke(st))
                    reqList.Add(st);
            }
            return reqList;
        }

        public static void DisplayList(this List<Student> list)
        {

            foreach (Student st in list)
            {
                Console.WriteLine("Имя: {0}", st.FirstName);
                Console.WriteLine("Фамилия: {0}", st.LastName);
                Console.WriteLine("Возраст: {0}", st.Age);
            }
        }
    }
}