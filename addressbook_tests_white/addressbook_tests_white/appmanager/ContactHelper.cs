using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;*/

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public static string CEDITORWINTITLE = "Contact Editor";
        public static string SUBMITWINTITLE = "Question";

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public void Remove(int i)
        {
            SelectContact(i);
            InitContactRemoval();
            SubmitContactRemove();
        }

        public void Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitAndClose(CEDITORWINTITLE);
        }

        private void SubmitAndClose(string wintitle)
        {
            aux.ControlClick(wintitle, "", "WindowsForms10.BUTTON.app.0.2c908d58");
        }

        private void InitContactCreation()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(CEDITORWINTITLE);
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            return list;
        }

        public int GetContactCount()
        {
            return int.Parse(aux.ControlListView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "", ""));
        }

        public void CheckContactExist()
        {
            if (GetContactCount() < 1)
            {
                ContactData newContact = new ContactData()
                {
                    Firstname = "Test",
                    Lastname = "Testov"
                };

                Create(newContact);
            }
        }

        public void SelectContact(int i)
        {
            aux.ControlListView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "Select", i.ToString(), "");
        }

        public void InitContactRemoval()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
            aux.WinWait(SUBMITWINTITLE);
            
        }

        public void SubmitContactRemove()
        {
            aux.ControlClick(SUBMITWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d52");
        }

        public void FillContactForm(ContactData contact)
        {
            aux.ControlFocus(CEDITORWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d516");
            aux.Send(contact.Firstname);
            aux.ControlFocus(CEDITORWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d513");
            aux.Send(contact.Lastname);
        }

    }
}
