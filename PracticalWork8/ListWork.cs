

namespace PracticalWork8
{
    internal class ListWork
    {
        private List<int> _intValues = new List<int>();
        
        public List<int> CompleteTheList() // заполняем список значенимями от 0 до 100
        {
            Random random = new();
            for (int i = 0; i < 100; i++)
            {
                int value = random.Next(101);
                _intValues.Add(value);
            }
            return _intValues;
        }
        
        public void PrintList(List<int> list) // принимаем список в качестве параметра и выводим на экран
        {
            foreach (var item in list)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        public List<int> DeleteValuesFrom25To50(int deleteFrom, int deleteTo) // принимаем на вход диапазон значений от..до и удаляем числа из диапазона из списка
        {
            int countDeletedValues = 0;
            foreach (var value in _intValues)
            {
                if (value > deleteFrom & value < deleteTo)
                {
                    countDeletedValues++;
                }
            }
            _intValues.RemoveAll(x => x > deleteFrom && x < deleteTo);
            Console.WriteLine($"Удалено значений:  {countDeletedValues}\n");
            Console.WriteLine("Новый список имеет вид: ");
            return _intValues;
        }
    }
}
