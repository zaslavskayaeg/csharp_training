using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails;
        private string allPhones;
        private string contactInfo;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname & Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = <" + Firstname + ">" 
                + "\nlastname = <" + Lastname+ ">" 
                + "\nmiddlename = <" + Middlename + ">" 
                + "\nnickname = <" + Nickname + ">" 
                + "\ntitle = <" + Title + ">" 
                + "\ncompany = <" + Company + ">" 
                + "\naddress = <" + Address + ">" 
                + "\nhomePhone = <" + HomePhone + ">" 
                + "\nmobilePhone = <" + MobilePhone + ">" 
                + "\nworkPhone = <" + WorkPhone + ">" 
                + "\nfax = <" + Fax + ">" 
                + "\nemail = <" + Email + ">" 
                + "\nemail2 = <" + Email2 + ">" 
                + "\nemail3 = <" + Email3 + ">" 
                + "\nhomepage = <" + Homepage + ">" 
                + "\naddress2 = <" + Address2 + ">" 
                + "\nphone2 = <" + Phone2 + ">" 
                + "\nnotes = <" + Notes + ">";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.Equals(this.Lastname, other.Lastname))
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return Lastname.CompareTo(other.Lastname);
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";

            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string GetNameFull(string firstname, string middlename, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = Firstname + " ";
            }
            if (middlename != null && middlename != "")
            {
                bufer = bufer + Middlename + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + Lastname + " ";
            }
            return bufer.Trim();
        }


        private string GetPhonesList(string homePhone, string mobilePhone, string workPhone, string fax)
        {
            string bufer = "";
            if (homePhone != null && homePhone != "")
            {
                bufer = bufer + "H: " + EndStringInsert(HomePhone);
            }
            if (mobilePhone != null && mobilePhone != "")
            {
                bufer = bufer + "M: " + EndStringInsert(MobilePhone);
            }
            if (workPhone != null && workPhone != "")
            {
                bufer = bufer + "W: " + EndStringInsert(WorkPhone);
            }
            if (fax != null && fax != "")
            {
                bufer = bufer + "F: " + EndStringInsert(Fax);
            }
            return bufer.Trim();
        }

        private string GetEmailList(string email, string email2, string email3, string homepage)
        {
            string bufer = "";
            if (email != null && email != "")
            {
                bufer = bufer + EndStringInsert(email);
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + EndStringInsert(email2);
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + EndStringInsert(email3);
            }
            if (homepage != null && homepage != "")
            {
                bufer = bufer + EndStringInsert(StringHomepage(homepage));
            }
            return bufer.Trim();
        }

        private string StringHomepage(string homepage)
        {
            if (homepage == null || homepage == "")
            {
                return "";
            }
            return "Homepage:" + "\r\n" + homepage;
        }

        private string StringPhone2(string phone2)
        {
            if (phone2 == null || phone2 == "")
            {
                return "";
            }

            return "P: " + Phone2;
        }


        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EndStringInsert(Email) + EndStringInsert(Email2) + EndStringInsert(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string EndStringInsert(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return entry + "\r\n";
        }

        private string StartStringInsert(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return "\r\n" + entry;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }
    
        public string Id { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string ContactInfo
        {
            get
            {
                if (contactInfo != null)
                {
                    return contactInfo;
                }
                else
                {
                    return (
                        EndStringInsert(EndStringInsert(ContactInfoList(Firstname, Middlename, Lastname, Nickname, Title, Company, Address)))
                        + EndStringInsert(EndStringInsert(GetPhonesList(HomePhone, MobilePhone, WorkPhone, Fax)))
                        + EndStringInsert(EndStringInsert(GetEmailList(Email, Email2, Email3, Homepage)))
                        + StartStringInsert(Address2)
                        + EndStringInsert(StartStringInsert(StartStringInsert(StringPhone2(Phone2))))
                        + StartStringInsert(Notes)).Trim();
                }
            }
            set
            {
                contactInfo = value;
            }
        }

        private string ContactInfoList(string firstname, string middlename, string lastname, string nickname, string title, string company, string address)
        {
            return EndStringInsert(GetNameFull(firstname, middlename, lastname))
                        + EndStringInsert(nickname)
                        + EndStringInsert(title)
                        + EndStringInsert(company)
                        + EndStringInsert(address).Trim();
        }
    }

}
