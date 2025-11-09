using OperatorOverloading.Task2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OperatorOverloading.Task3
{
    //100    int
    //100L   long
    //100m   decimal
    //100.0  double
    //100f   float

    public class CreditCard
    {
        public string Holder { get; }

        private long _number;
        public long Number 
        {
            get => _number;
            private set
            {
                var numStrLength = value.ToString().Length;
                if(numStrLength != 16)
                    throw new ArgumentException("Number должен состоять из 16 цифр.", nameof(value));

                _number = value;
            }
        }

        private string _cvc;
        public string Cvc
        {
            get => _cvc;
            private set
            {
                if (value.Length != 3)
                    throw new ArgumentException("CVC должен состоять из 3 цифр.", nameof(value));

                _cvc = value;
            }
        }

        private decimal _balance;

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0m) 
                    throw new ArgumentOutOfRangeException(nameof(value), "Баланс не может быть отрицательным.");

                _balance = value;
            }
        }

        public CreditCard(string holder, long number, string cvc, decimal balance)
        {
            Holder = holder;
            Number = number;
            Cvc = cvc;
            Balance = balance; 
        }

        public void ChangeCVC(string newCvc)
        {
            this.Cvc = newCvc;
        }

        // збільшення суми грошей на вказану кількість
        public static CreditCard operator +(CreditCard card, decimal amount)
        {
            if (amount < 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), "Баланс не может быть отрицательным.");

            return new CreditCard(card.Holder, card.Number, card.Cvc, card.Balance + amount);
        }

        // зменшення суми грошей на вказану кількість
        public static CreditCard operator -(CreditCard card, decimal amount)
        {
            if (amount < 0m)
                throw new ArgumentOutOfRangeException(nameof(amount), "Баланс не может быть отрицательным.");

            var newBalance = card.Balance - amount;

            if (newBalance < 0m) 
                throw new InvalidOperationException("Нельзя списать больше, чем доступно на карте.");

            return new CreditCard(card.Holder, card.Number, card.Cvc, newBalance);
        }

        // перевірка на рівність
        public static bool operator ==(CreditCard a, CreditCard b)
        {
            return a.Cvc == b.Cvc;
        }

        // перевірка на не рiвнiсть
        public static bool operator !=(CreditCard a, CreditCard b)
        {
            return !(a.Cvc == b.Cvc); 
        }

        // перевірка на меншу кількість суми грошей
        public static bool operator <(CreditCard a, CreditCard b)
        {
            return a.Balance < b.Balance;
        }

        // перевірка на більшу кількість суми грошей
        public static bool operator >(CreditCard a, CreditCard b)
        {
            return a.Balance > b.Balance;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CreditCard card)
            {
                return card.Cvc == this.Cvc;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return this.Cvc.GetHashCode();
        }

        public override string ToString()
        {
            var arr = Number.ToString().ToArray();

            string secNumber = string.Format("XXXX-XXXX-XXXX-XX{0}{1}", arr[14], arr[15]);

            return $"Holder: {Holder}, Card: {secNumber}, CVC: ***";
        }
    }
}
