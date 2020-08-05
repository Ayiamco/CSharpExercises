using System;

namespace Chapter20Question8.Interfaces
{
    interface IAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; set; }
        int CustomerAge { get; }
        DateTime DateOpened { get; }
        string Name { get; }

        decimal Credit(decimal amt);
        string GetAccountInfo();
    }
}