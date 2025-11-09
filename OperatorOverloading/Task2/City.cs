using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Task2
{
    //100    int
    //100L   long
    //100m   decimal
    //100.0  double
    //100f   float

    public class City
    {
        public string Name { get; } = string.Empty;
        public string Country { get; } = string.Empty;

        private long _population;

        public long Population
        {
            get => _population;
            set
            {
                if (value < 0L) 
                    throw new ArgumentOutOfRangeException(nameof(value), "Значение цифры населения не может быть отрицательным");

                _population = value;
            }
        }

        public City(string name, long population, string country)
        {
            Name = name;
            Country = country;
            Population = population;
        }

        // збільшення кількості жителів на вказану кількість
        public static City operator +(City c, long amount)
        {
            if (amount < 0L)
                throw new ArgumentOutOfRangeException(nameof(amount), "Значение цифры населения не может быть отрицательным");

            return new City(c.Name, c.Population + amount, c.Country);
        }

        // меншення кількості жителів на вказану кількість
        public static City operator -(City c, long amount)
        {
            if (amount < 0L)
                throw new ArgumentOutOfRangeException(nameof(amount), "Значение цифры населения не может быть отрицательным");

            var newPop = c.Population - amount;

            if (newPop < 0L) 
                throw new InvalidOperationException("Значение цифры населения не может быть отрицательным");

            return new City(c.Name, newPop, c.Country);
        }

        // перевірка на рівність
        public static bool operator ==(City a, City b)
        {
            return a.Population == b.Population;
        }

        // перевірка на не рiвнiсть
        public static bool operator !=(City a, City b)
        {
            return !(a == b);
        }

        // перевірка на меншу кількість мешканців
        public static bool operator <(City a, City b)
        {
            return a.Population < b.Population;
        }

        // перевірка на більшу кількість мешканців
        public static bool operator >(City a, City b)
        {
            return a.Population > b.Population;
        }

        public override bool Equals(object? obj)
        {
            if(obj is City city)
            {
                return city.Population == this.Population;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return this.Population.GetHashCode();
        }

        public override string ToString()
        {
            return $"Country: {Country}, City: {Name}, Population: {Population}";
        }
    }
}
