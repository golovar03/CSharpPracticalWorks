namespace XMLProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new();
            Person person = new();
            Repository repository = new Repository();
            
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Введите данные пользователя.");
                person.CreatePerson();
                persons.Add(person);     
            }
            Repository.AddPerson(persons);
        }
    }
}