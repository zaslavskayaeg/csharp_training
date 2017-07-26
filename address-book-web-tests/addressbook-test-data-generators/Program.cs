﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfData = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];




            if (typeOfData == "group")
            {
                List<GroupData> groups = GenerateGroupsList(count);
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Write("Unrecognized format <" + format + ">");
                    }
                    writer.Close();
                }
            }
            else if (typeOfData == "contact")
            {
                List<ContactData> contacts = GenerateContactsList(count);
                if (format == "excel")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Write("Unrecognized format <" + format + ">");
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Write("Invalid value args[0] = <" + typeOfData + ">."
                    + "\r\nPossible values: "
                    + "\r\n<group> = ContactData type; "
                    + "\r\n<contacts> = ContactData type.");
            }
        }

        private static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            String fullPuth = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPuth);
            wb.SaveAs(fullPuth);
            wb.Close(0);
            app.Visible = false;
            app.Quit();
        }

        private static void WriteContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.Middlename;
                sheet.Cells[row, 4] = contact.Nickname;
                sheet.Cells[row, 5] = contact.Title;
                sheet.Cells[row, 6] = contact.Company;
                sheet.Cells[row, 7] = contact.Address;
                sheet.Cells[row, 8] = contact.HomePhone;
                sheet.Cells[row, 9] = contact.MobilePhone;
                sheet.Cells[row, 10] = contact.WorkPhone;
                sheet.Cells[row, 11] = contact.Fax;
                sheet.Cells[row, 12] = contact.Email;
                sheet.Cells[row, 13] = contact.Email2;
                sheet.Cells[row, 14] = contact.Email3;
                sheet.Cells[row, 15] = contact.Homepage;
                sheet.Cells[row, 16] = contact.Address2;
                sheet.Cells[row, 17] = contact.Phone2;
                sheet.Cells[row, 18] = contact.Notes;
                row++;
            }
            String fullPuth = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPuth);
            wb.SaveAs(fullPuth);
            wb.Close(0);
            app.Visible = false;
            app.Quit();
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

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
