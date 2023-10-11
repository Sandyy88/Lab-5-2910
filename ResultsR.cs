using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_5_2910
{
    public class ResultsR
    {
        public string Gender { get; set; } = string.Empty;
        public Name Name { get; set; } = new Name(); //Initalizing instances in order to not throw a null reference exception. These may also have question marks when the last name is in another language.
        public Location Location { get; set; } = new Location();
        public string Email { get; set; } = string.Empty;
        public Login Login { get; set; } = new Login();
        public DOB Dob { get; set; } = new DOB();
        public string Phone { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public ID Id { get; set; } = new ID(); //This may sometimes be generated. The api chooses if it wants to or not. This may also happen with other properties.
        public string Nat { get; set; } = string.Empty;

        public ResultsR() { }
        public ResultsR(string gender, Name name, Location location, string email, Login login, DOB dob, string phone, string cell, ID id, string nat)
        {
            Gender = gender;
            Name = name;
            Location = location;
            Email = email;
            Login = login;
            Dob = dob;
            Phone = phone;
            Cell = cell;
            Id = id;
            Nat = nat;
        }

        public override string ToString()
        {
            string s = " ";
            s +=  
                "\n\nPerson: " +

                Name?.ToString() +

                "\n\n\tDATE OF BIRTH INFO:" + //can come back and fix this lol
                "\n\t\tDate: " + Dob?.Date +
                "\n\t\tAge: " + Dob?.Age +

                "\n\n\tOTHER PERSONAL INFO: " + 
                "\n\t\tGender: " + Gender + 
                "\n\t\tEmail: " + Email + 
                "\n\t\tPhone Number: " + Phone +
                "\n\t\tCell: " + Cell + 
                "\n\t\tNationality: " + Nat +

                Location?.ToString() + Id?.ToString() + Login?.ToString();

            s += "\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_";

            return s;
        }

    }
}
