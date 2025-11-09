using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Task1
{
    //100    int
    //100L   long
    //100m   decimal
    //100.0  double
    //100f   float

    public class Employee
    {
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0m)
                    throw new ArgumentOutOfRangeException(nameof(value), "Зарплата не может иметь отрицательно значение");
                if (value > decimal.MaxValue) 
                    throw new ArgumentOutOfRangeException(nameof(value), "Вы столько не зарабатываете");

                _salary = value;
            }
        }

        public Employee(string firstName, string lastName, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        // збільшення зарплати на вказану кількість
        public static Employee operator +(Employee e, decimal amount)
        {
            if (amount < 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), "Зарплата не может иметь отрицательно значение");

            return new Employee(e.FirstName, e.LastName, e.Salary + amount);
        }

        // зменшення зарплати на вказану кількість
        public static Employee operator -(Employee e, decimal amount)
        {
            if (amount < 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), "Зарплата не может иметь отрицательно значение");

            var newSalary = e.Salary - amount;

            if (newSalary < 0m)
                throw new InvalidOperationException("Зарплата не может уходить в минус");

            return new Employee(e.FirstName, e.LastName, newSalary);
        }

        // перевірка на рівність
        public static bool operator ==(Employee a, Employee b)
        {
            return a.Salary == b.Salary;
        }

        // перевірка на не рівність
        public static bool operator !=(Employee a, Employee b)
        {
            return !(a == b);
        }

        // перевірка на меншу 
        public static bool operator <(Employee a, Employee b)
        {
            return a.Salary < b.Salary;
        }

        // перевірка на більшу 
        public static bool operator >(Employee a, Employee b)
        {
            return a.Salary > b.Salary;
        }

        public override string ToString() => $"{LastName} {FirstName}: {Salary} грн";
    }
}
