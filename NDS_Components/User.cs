using System;
using static NDS_GEN.Program;
using System.Net.Mail;

namespace NDS_GEN.NDS_Components
{
    public class User
    {
        //private string _id;

        private string _name;private string Name
        {
            get => _name;
            set => _name = CheckInput(value);
        }
        private string _surname;private string Surname
        {
            get => _surname;
            set => _surname = CheckInput(value);
        }
        private string _email;public string Email
        {
            get => _email;
            set => _email = CheckEmail(value);
        }
        private string _username;public string Username
        {
            get => _username;
            set => _username =  CheckInput(value);
        }

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Username = $"{Name}:{Surname}";
            Email = email;
        }
        
        private  string CheckEmail(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return email;
            }
            catch (FormatException)
            {
                throw new ArgumentNullException(nameof(email));
            }
        }
    }
}