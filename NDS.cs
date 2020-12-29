using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NDS_GEN.NDS_Components;
using static NDS_GEN.Program;

namespace NDS_GEN
{
    public class Nds
    {
        //HEAD PROPERTIES
        private string _filePath; private string FilePath
        {
            get => _filePath;
            set => _filePath = File.Exists(@value) ? value : throw new ArgumentNullException(nameof(value));
        }
        private string _hashContent; public string HashContent
        {
            get => _hashContent;
            set => _hashContent = CheckHash(FilePath, value);
        }
        private User _user; private User User1
        {
            get => _user;
            set => _user = value ?? throw new ArgumentNullException(nameof(value));
        }
        private string _brief; private string Brief
        {
            get => _brief;
            set => _brief = value.Length <= 200 ? value : throw new ArgumentNullException(nameof(value));
        }
        private string _title; private string Title
        {
            get => _title;
            set => _title = value.Length < 100 ? value : throw new ArgumentNullException(nameof(value));
        }
        private DateTime _start; private DateTime Start { get; set; }
        private DateTime _end; private DateTime End { get; set; }

        
        
        //BODY PROPERTIES
        private User[] _attendee; private User[] Attendee
        {
            get => _attendee;
            set => _attendee = CheckAttendee(value);
        }
        private User[] CheckAttendee(User[] collection)
        {
            if (collection.Length < 1)
                throw new Exception("No User in Attendee, NDS creator have to be in the attendee list.");
            if (collection.Any(user => user == User1)) 
                return collection;
            throw new Exception("No User in Attendee, NDS creator have to be in the attendee list.");
        }

        private string[] _flow; private string[] Flow
        {
            get => _flow;
            set => _flow = value.Length < 1 && value[0] != null ? value : throw new ArgumentException(nameof(value));
        }
        
        private string[] _instructions; private string[] Instructions
        {
            get => _instructions;
            set => _instructions = value.Length < 1 && value[0] != null ? value : throw new ArgumentException(nameof(value));
        }
        
        private string[] _divers; private string[] Divers
        {
            get => _divers;
            set => _divers = value.Length < 1 && value[0] != null ? value : throw new ArgumentException(nameof(value));
        }
        
        private string[] _authorizedPersonnel; private string[] AuthorizedPersonnel
        {
            get => _authorizedPersonnel;
            set => _authorizedPersonnel = value.Length < 1 && value[0] != null ? value : throw new ArgumentException(nameof(value));
        }

        //CONSTRUCTOR WITH EXISTING NDS
        public Nds(string filePath)
        {
            //HEAD
            //TODO: parse for user data
            User1 = new User("", "", "");
            //TODO: parse for brief
            Brief = "";
            //TODO: parse for starting date time
            Start = new DateTime(0,0,0,0,0,0);
            //TODO: parse for starting date time
            End = new DateTime(0,0,0,0,0,0);
            FilePath = filePath;
            
            //BODY
            //TODO: parse for Flow
            Flow = new[] {"RAS"};
            Instructions = new[] {"RAS"};
            Divers = new[] {"RAS"};
            AuthorizedPersonnel = new[] {"RAS"};
        }

        //CONSTRUCTOR WHEN CREATING NDS
        public Nds(string filePath, User creator, string brief, DateTime start, DateTime end, User[] attendee, string[] flow, string[] instructions, string[] divers, string[] authorizedPersonnel)
        {
            // HEAD
            User1 = creator;
            Brief = brief;
            FilePath = filePath;
            Start = start;
            End = end;
            
            //BODY
            Attendee = attendee;
            Flow = flow;
            Instructions = instructions;
            Divers = divers;
            AuthorizedPersonnel = authorizedPersonnel;
        }

        
    }
}