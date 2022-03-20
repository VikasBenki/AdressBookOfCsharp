using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{

    public class FileOperations
    {
        /// <summary>
        /// write person details into data.txt
        /// </summary>
        /// <param name="addressDictionary"></param>
        public static void WriteInTextFile(Dictionary<string, AddressBookMain> List, string filePath)
        {
            if (File.Exists(filePath))
            {
                //using streamWriter write the data into the file 
                StreamWriter writer = new StreamWriter(filePath);
                foreach (KeyValuePair<string, AddressBookMain> kv in List)
                {
                    //write line method append next dat in the next line
                    writer.WriteLine("AddressBook Name:" + kv.Key);
                    foreach (var list in kv.Value.getContacts())
                    {
                        writer.WriteLine("Name:" + list.firstName + " " + list.lastName +
                            "\n Address:" + list.address + " \nCity:" + list.city + " \nState:" + list.state + "\n Zipcode:" + list.zipCode + 
                            "\n Ph.No:" + list.phoneNumber + "\n Email:" + list.email);
                    }
                }
                //close the stream
                writer.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        /// <summary>
        /// Reading data from data.txt and display to the console
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadFromTextFile(string filePath)
        {
            Console.WriteLine("<---------Data from Text File---------->");
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}

