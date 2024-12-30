namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount account = new SavingsAccount("1", 10000, 0.07m);
            Console.WriteLine($"Sold initial = {account.Balance}");
            account.Deposit(1233);
            account.Withdraw(10);
            

            CheckingAccount secondAccount = new CheckingAccount("123", 50000,500);
            Console.WriteLine($"Sold initial = {secondAccount.Balance}");
            secondAccount.Deposit(-50);
            secondAccount.Withdraw(800);
            
        }
    }
}
