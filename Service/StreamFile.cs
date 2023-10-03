using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AcoountAppClassLibrary.Service
{
    public static class StreamFile
    {

        public static void StreamWriteFunction(AccountPerson details, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, details);

            }

        }


        //3.1 here writing the read file function and data type casting to accountperson and this data forward function called 
        public static AccountPerson StreamWriteFunction(string filePath)
        {
            AccountPerson person = null;
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                person = (AccountPerson)formatter.Deserialize(fileStream);
            }
            return person;
        }
    }
}
