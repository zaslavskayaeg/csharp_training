using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{

    public class ContactData  : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

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

        public override string ToString()
        {
            return "firstname = <" + Firstname + ">"
                + "\nlastname = <" + Lastname + ">";
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

    }

}
