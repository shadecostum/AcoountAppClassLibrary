using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoountAppClassLibrary.Service
{
    public class AccountManager
    {

        public List<AccountPerson> personsList { get; set; }
        public static string sfilePath = @"C:\TextFolder\DataBase6.txt";

        public AccountManager()
        {
            personsList = new List<AccountPerson>();//list new assigned

        }

        public void CreateAccount(string accountName, string bankName, int balance)
        {
            //2 class accountPerson details store new object created and passed to stream write file
            AccountPerson accountPerson = new AccountPerson { AccountName = accountName, BankName = bankName, Balance = balance };
            StreamFile.StreamWriteFunction(accountPerson, sfilePath);
        }

        public AccountPerson ReadFilePass()
        {
            AccountPerson readFileObj = StreamFile.StreamWriteFunction(sfilePath);

            return readFileObj;
        }

        public int DepositAmount(int dataa)
        {
            AccountPerson accountDeposite = personsList.Find(AccountPerson => AccountPerson.Balance == AccountPerson.Balance);
            if (accountDeposite != null)
            {
                // Assign the balance to the 'data' out parameter
                accountDeposite.Balance = accountDeposite.Balance + dataa;
            }
            return dataa;
        }



        public void WidrowAmount(int widrowAmount, out string feedBack)
        {
            AccountPerson amountWidrow = personsList.Find(AccountPerson => AccountPerson.Balance == AccountPerson.Balance);
            if (amountWidrow != null)
            {

                int checkBalance = amountWidrow.Balance - widrowAmount;
                if (checkBalance > 500)
                {
                    amountWidrow.Balance = amountWidrow.Balance - widrowAmount;
                    feedBack = $"sucess Balance{amountWidrow.Balance}";
                    return;
                }


            }
            throw new InsufficentBalanceException("Minimum balance amount 500");
        }

        //4.3 list added read data by this function
        public void ListCreated(AccountPerson readFileObj)
        {
            personsList.Add(readFileObj);
        }

        public void SavingFile()
        {
            AccountPerson accountDeposite = personsList.Find(AccountPerson => AccountPerson.Balance == AccountPerson.Balance);
            if (accountDeposite != null)
            {
                // Assign the balance to the 'data' out parameter
                AccountPerson accountPerson = new AccountPerson { AccountName = accountDeposite.AccountName, BankName = accountDeposite.BankName, Balance = accountDeposite.Balance };
                StreamFile.StreamWriteFunction(accountPerson, sfilePath);
            }

        }
    }
}
