using OperatorOverloading.Task1;
using System.Text;

namespace OperatorOverloading
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = new UTF8Encoding(false);
            Console.InputEncoding = new UTF8Encoding(false);

            Task1();

            Console.ReadLine();
        }


        static void Task1()
        {
            try
            {
                var eIvan = new Employee("Іван", "Петренко", 25000m);
                var eOlena = new Employee("Олена", "Іваненко", 27000m);

                Console.WriteLine("Зп до изменений");
                Console.WriteLine(eIvan);
                Console.WriteLine(eOlena);

                var newEIvan = eIvan + 3000m;   // 28 000
                var newEOlena = eOlena - 2000m;  // 25 000

                Console.WriteLine("\r\nЗп после изменений");
                Console.WriteLine(newEIvan);
                Console.WriteLine(newEOlena);

                Console.WriteLine($"\r\nДо изменений: зарплата Івана ({eIvan.Salary}) больше, чем у Олени ({eOlena.Salary}) — {(eIvan > eOlena)}");
                Console.WriteLine($"До изменений: зарплата Івана ({eIvan.Salary}) менше, чем у Олени ({eOlena.Salary}) — {(eIvan < eOlena)}");
                Console.WriteLine($"До изменений: зарплати Івана ({eIvan.Salary}) и Олени ({eOlena.Salary}) равны — {(eIvan == eOlena)}");

                Console.WriteLine($"\r\nПосле изменений: зарплата Івана ({newEIvan.Salary}) больше, чем у Олени ({newEOlena.Salary}) — {(newEIvan > newEOlena)}");
                Console.WriteLine($"После изменений: зарплата Івана ({newEIvan.Salary}) менше, чем у Олени ({newEOlena.Salary}) — {(newEIvan < newEOlena)}");
                Console.WriteLine($"После изменений: зарплата Івана ({newEIvan.Salary}) равна зарплате Олени после уменьшения ({newEOlena.Salary}) — {(newEIvan == newEOlena)}");

                // error
                var bad = eIvan - 999999m;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\r\nОшибка: {ex.Message}");
            }

        }
    }
}