using System;
using System.Collections.Generic;
using System.Text;

namespace tubig.DataModel
{
    public class Contacts
    {
        public static IEnumerable<Contacts> Get()
        {
            return new List<Contacts>
            {
                new Contacts() 
                {   UserId="1", 
                    FirstName="Contact", 
                    LastName="One", 
                    Email="contact.one@gmail.com",
                    Phone="1234131332", 
                    PhotoUrl="icon.png",
                    Country="India"
                },
                new Contacts()
                {
                    UserId="2", 
                    FirstName="Contact", 
                    LastName="Two",
                    Email="contact.two@gmail.com",
                    Phone="12894131332",
                    PhotoUrl="icon.png",
                    Country="India" 
                },
                new Contacts() 
                {
                    UserId="3",
                    FirstName="Contact", 
                    LastName="Three",
                    Email="contact.three@gmail.com",
                    Phone="4234242235", 
                    PhotoUrl="icon.png",
                    Country="India" 
                },

                new Contacts()
                {
                    UserId="4",
                    FirstName="Contact",
                    LastName="Four",
                    Email="contact.four@gmail.com",
                    Phone="6443245633",
                    PhotoUrl="icon.png",
                    Country="India" 
                },

                new Contacts()
                {
                    UserId="5", 
                    FirstName="Contact", 
                    LastName="Five",
                    Email="contact.five@gmail.com",
                    Phone="4234242235", 
                    PhotoUrl="icon.png",
                    Country="India" 
                },

                new Contacts()
                {
                    UserId="6", 
                    FirstName="Contact",
                    LastName="Six", 
                    Email="contact.six@gmail.com",

                    Phone="2344324443", 
                    PhotoUrl="icon.png",
                    Country="India"
                },
                new Contacts() 
                {UserId="7",
                    FirstName="Contact",
                    LastName="Seven",
                    Email="contact.seven@gmail.com",
                    Phone="234234234",
                    PhotoUrl="icon.png",
                    Country="India"
                },
                new Contacts()
                {
                    UserId="8",
                    FirstName="Contact", 
                    LastName="Eight",
                    Email="contact.eight@gmail.com",
                    Phone="4234242235", 
                    PhotoUrl="icon.png",
                    Country="India" 
                },
            };
        }



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Country { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
