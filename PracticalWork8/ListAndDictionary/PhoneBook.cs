

namespace PracticalWork8
{
    internal class PhoneBook
    {
        private string _phone;
        private string _fullName;
        private readonly Dictionary<string, string> phoneBook = new();

        public void AddSubcriber(string phoneNumber, string fullName)
        {
            _phone = phoneNumber;
            _fullName = fullName;
            if (!phoneBook.ContainsKey(phoneNumber))
            {
                phoneBook.Add(phoneNumber, fullName);
            }
            else
            {
                Console.WriteLine($"Запись с номером {phoneNumber} уже присутствует в базе!\n");
            }
        }

        public void DeleteSubscriber(string phoneNumber)
        {
            if (phoneBook.ContainsKey(phoneNumber))
            {
                Console.WriteLine($"Удален пользователь с номером телефона {phoneNumber}");
                phoneBook.Remove(phoneNumber);
            }
            else
            {
                Console.WriteLine("Пользователь с указанным номером не найден!\n");
            }
        }

        public void FindByNumber(string phoneNumber)
        {
            if (phoneBook.TryGetValue(phoneNumber, out _fullName))
            {
                Console.WriteLine($"{_phone} | {_fullName}");
            }
            else
            {
                Console.WriteLine("Пользователь с указанным номером не найден!\n");
            }
        }

        public void PrintAllSubscribes()
        {
            foreach (KeyValuePair<string, string> pairs in phoneBook)
            {
                Console.WriteLine($"{pairs} ");
            }
        }
    }
}
