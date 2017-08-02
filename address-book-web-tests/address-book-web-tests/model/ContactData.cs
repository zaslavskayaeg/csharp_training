using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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

        public ContactData()
        {
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

        [JsonIgnore]
        [XmlIgnore]
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

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [JsonIgnore]
        [XmlIgnore]
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

        [JsonIgnore]
        [XmlIgnore]
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
            return (EndStringInsert(GetNameFull(firstname, middlename, lastname))
                        + EndStringInsert(nickname)
                        + EndStringInsert(title)
                        + EndStringInsert(company)
                        + EndStringInsert(address)).Trim();
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contucts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

    }

}
