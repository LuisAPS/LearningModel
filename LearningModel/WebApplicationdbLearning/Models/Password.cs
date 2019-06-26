using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationdbLearning.Models
{
    public class Password
    {
        private int _PasswordId;

        public int PasswordId
        {
            get { return _PasswordId; }
            set { _PasswordId = value; }
        }

        //private int _PersonId;

        //public int PersonId
        //{
        //    get { return PersonId; }
        //    set { PersonId = value; }
        //}

        private string _GUID;

        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        private DateTime _DateCreated;

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

    }
}