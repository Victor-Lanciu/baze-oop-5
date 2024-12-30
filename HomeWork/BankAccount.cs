using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HomeWork
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }

        public BankAccount(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public abstract bool Deposit(decimal amount);

        public abstract bool Withdraw(decimal amount);


    }
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }
        public SavingsAccount(string accountNumber, decimal balance, decimal interestedRate) : base(accountNumber, balance)
        {
            InterestRate = interestedRate;
        }
        public override bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Suma depusa trebuie sa fie mai mare ca 0");
                return false;
            }

            Balance += amount;
            decimal interested = Balance * InterestRate;
            Balance += interested;

            Console.WriteLine($"Suma depusa: {amount}.Dobanda aplicata: {InterestRate*100}%. Sold curent = {Balance}");
            return true;
        }
        public override bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Nu dispuneti de mijloace suficiente");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Suma retrasa: {amount}.Sold curent = {Balance}");
            return true;
        }
    }

    public class CheckingAccount : BankAccount
    {
        public decimal OverdraftLimit { get; private set; }
        public CheckingAccount(string accountNumber, decimal balance, decimal overdraftLimit) : base(accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }
        public override bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Suma depusa trebuie sa fie mai mare ca 0");
                return false;

            }

            Balance += amount;
            Console.WriteLine($"Suma depusa: {amount}.Sold curent = {Balance}");
            return true;
        }
        public override bool Withdraw(decimal amount)
        {
            if (amount > Balance + OverdraftLimit)
            {
                Console.WriteLine("Nu dispuneti de mijloace suficiente, ati depasit limita de creditare");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Suma retrasa: {amount}.Sold curent = {Balance}");
            return true;
        }
    }
}
