using System;

namespace PracticalWork2._7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName; // ФИО ученика
            int age; // Возраст
            string email; // Адрес электронной почты
            float programmingPoints; // Балл по программированию
            float mathPoints; // Балл по математике 
            float physicsPoints; // Балл по физике
            float totalPoints; // Сумма баллов
            float gpa; //Средний балл GPA

            fullName = "Иванов Иван Иванович";
            age = 15;
            email = "superivanov@mail.ru";
            programmingPoints = 5.0f;
            mathPoints = 5.0f;
            physicsPoints = 4.0f;
            Console.WriteLine($" ФИО: {fullName}\n" +
                              $" Возраст: {age} лет\n" +
                              $" Email: {email}\n" +
                              $" Баллы по программированию: {programmingPoints}\n" +
                              $" Баллы по математике: {mathPoints}\n" +
                              $" Баллы по физике: {physicsPoints}");
            totalPoints = programmingPoints + mathPoints + physicsPoints;
            gpa = totalPoints / 3;
            Console.ReadKey();
            Console.WriteLine($" Сумма баллов: {totalPoints}\n" +
                              $" Средний балл: {gpa:#.##}\n");


            fullName = "Сидоров Сидор Сидорович";
            age = 14;
            email = "supersidoroff@mail.ru";
            programmingPoints = 3.0f;
            mathPoints = 4.5f;
            physicsPoints = 4.0f;
            totalPoints = programmingPoints + mathPoints + physicsPoints;
            gpa = totalPoints / 3;
            Console.WriteLine($" ФИО: {fullName}\n" +
                              $" Возраст: {age} лет\n" +
                              $" Email: {email}\n" +
                              $" Баллы по программированию: {programmingPoints}\n" +
                              $" Баллы по математике: {mathPoints}\n" +
                              $" Баллы по физике: {physicsPoints}");
            totalPoints = programmingPoints + mathPoints + physicsPoints;
            gpa = totalPoints / 3;
            Console.ReadKey();
            Console.WriteLine($" Сумма баллов: {totalPoints}\n" +
                              $" Средний балл: {gpa:#.##}\n");

            Console.ReadKey();
        }
    }
}
