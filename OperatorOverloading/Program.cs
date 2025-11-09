using OperatorOverloading.Task1;
using OperatorOverloading.Task2;
using OperatorOverloading.Task3;
using System.Text;

namespace OperatorOverloading
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = new UTF8Encoding(false);
            Console.InputEncoding = new UTF8Encoding(false);

            //Task1();
            //Task2();
            Task3();

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

        static void Task2()
        {
            try
            {
                var kyiv = new City("Киев", 2_967_000, "Украина");
                var lviv = new City("Львов", 717_000, "Украина");

                Console.WriteLine("Население до изменений");
                Console.WriteLine(kyiv);  
                Console.WriteLine(lviv); 

                var kyivPlus = kyiv + 10_000; 
                var lvivMinus = lviv - 17_000; 

                Console.WriteLine("\r\nНаселение после изменений");
                Console.WriteLine(kyivPlus);  
                Console.WriteLine(lvivMinus); 

                Console.WriteLine($"\r\nДо изменений: население Киева ({kyiv.Population}) больше, чем у Львова ({lviv.Population}) — {(kyiv > lviv)}");
                Console.WriteLine($"До изменений: население Киева ({kyiv.Population}) меньше, чем у Львова ({lviv.Population}) — {(kyiv < lviv)}");
                Console.WriteLine($"До изменений: население Киева ({kyiv.Population}) и Львова ({lviv.Population}) равны — {(kyiv == lviv)}");

                Console.WriteLine($"\r\nПосле изменений: население Киева ({kyivPlus.Population}) больше, чем у Львова после уменьшения ({lvivMinus.Population}) — {(kyivPlus > lvivMinus)}");
                Console.WriteLine($"После изменений: население Киева ({kyivPlus.Population}) меньше, чем у Львова после уменьшения ({lvivMinus.Population}) — {(kyivPlus < lvivMinus)}");
                Console.WriteLine($"После изменений: население Киева ({kyivPlus.Population}) равно населению Львова после уменьшения ({lvivMinus.Population}) — {(kyivPlus == lvivMinus)}");

                // error
                var bad = lviv - 1_000_000;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\r\nОшибка: {ex.Message}");
            }
        }

        static void Task3()
        {
            try
            {
                var ivan = new CreditCard("Иван Петров", 4441114454322345L, "023", 1250.50m);
                var olena = new CreditCard("Олена Іваненко", 4441111134569876L, "023", 980.00m);

                Console.WriteLine("Баланс до изменений");
                Console.WriteLine(ivan);
                Console.WriteLine(olena);

                var ivanPlus = ivan + 300.00m;  
                var olenaMinus = olena - 150.00m; 
                olenaMinus.ChangeCVC("777"); // ----------------- ChangeCVC

                Console.WriteLine("\r\nБаланс после изменений");
                Console.WriteLine(ivanPlus);
                Console.WriteLine(olenaMinus);

                Console.WriteLine($"\r\nДо изменений: баланс карты Ивана ({ivan.Balance}) больше, чем у Олены ({olena.Balance}) — {(ivan > olena)}");
                Console.WriteLine($"До изменений: баланс карты Ивана ({ivan.Balance}) меньше, чем у Олены ({olena.Balance}) — {(ivan < olena)}");
                Console.WriteLine($"До изменений: CVC Ивана и Олены равны — {(ivan == olena)}");

                Console.WriteLine($"\r\nПосле изменений: баланс Ивана ({ivanPlus.Balance}) больше, чем у Олены после списания ({olenaMinus.Balance}) — {(ivanPlus > olenaMinus)}");
                Console.WriteLine($"После изменений: баланс Ивана ({ivanPlus.Balance}) меньше, чем у Олены после списания ({olenaMinus.Balance}) — {(ivanPlus < olenaMinus)}");
                Console.WriteLine($"После изменений: CVC Ивана и Олены равны — {(ivanPlus == olenaMinus)}");

                // ошибка (списание больше доступного)
                var bad = olena - 10_000m;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\r\nОшибка: {ex.Message}");
            }
        }
    }
}