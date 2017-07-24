﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string typeOfData = args[3];
            if (typeOfData == "gr")
            {
                List<GroupData> groups = GenerateGroupsList(count);
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Write("Unrecognized format <" + format + ">");
                }
            }
            else if (typeOfData == "cont")
            {
                List<ContactData> contacts = GenerateContactsList(count);
                if (format == "csv")
                {
                    WriteContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Write("Unrecognized format <" + format + ">");
                }
            }
            else
            {
                System.Console.Write("Invalid value args[3] = <" + typeOfData + ">." 
                    + "\r\nPossible values: "
                    + "\r\n<gr> = Groups; " 
                    + "\r\n<cont> = Contacts.");
            }

            writer.Close();
        }

        private static List<GroupData> GenerateGroupsList(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

            return groups;
        }

        private static List<ContactData> GenerateContactsList(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(20), TestBase.GenerateRandomString(20))
                {
                    Middlename = TestBase.GenerateRandomString(20),
                    Nickname = TestBase.GenerateRandomString(20),
                    Title = TestBase.GenerateRandomString(20),
                    Company = TestBase.GenerateRandomString(20),
                    Address = TestBase.GenerateRandomString(50),
                    HomePhone = TestBase.GenerateRandomString(20),
                    MobilePhone = TestBase.GenerateRandomString(20),
                    WorkPhone = TestBase.GenerateRandomString(20),
                    Fax = TestBase.GenerateRandomString(20),
                    Email = TestBase.GenerateRandomString(20),
                    Email2 = TestBase.GenerateRandomString(20),
                    Email3 = TestBase.GenerateRandomString(20),
                    Homepage = TestBase.GenerateRandomString(20),
                    Address2 = TestBase.GenerateRandomString(50),
                    Phone2 = TestBase.GenerateRandomString(20),
                    Notes = TestBase.GenerateRandomString(50)
                });
            }

            return contacts;
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16},${17}",
                    contact.Firstname,
                    contact.Lastname,
                    contact.Middlename,
                    contact.Nickname,
                    contact.Title,
                    contact.Company,
                    contact.Address,
                    contact.HomePhone,
                    contact.MobilePhone,
                    contact.WorkPhone,
                    contact.Fax,
                    contact.Email,
                    contact.Email2,
                    contact.Email3,
                    contact.Homepage,
                    contact.Address2,
                    contact.Phone2,
                    contact.Notes
                    ));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
