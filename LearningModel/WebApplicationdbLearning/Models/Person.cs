using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplicationdbLearning.Models
{
    public class Person:ModelConnection 
    {
        private int _PersonId;

        public int PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
        }


        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        

        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }


        private Role _Role;

        public Role Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        

        private DateTime _DateCreated;

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

        private Password _Password;

        public Password Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public Person(int PersonId, int personId, string FirstName, string firstName, string LastName, string lastName, string Phone, string phone, string Email, string email, bool IsActive, bool isActive, Role Role, Role role, string UserName, string userName, DateTime DateCreated, DateTime dateCreated, Password Password, Password password):base()
        {
            _PersonId = PersonId;
            this.PersonId = personId;
            _FirstName = FirstName;
            this.FirstName = firstName;
            _LastName = LastName;
            this.LastName = lastName;
            _Phone = Phone;
            this.Phone = phone;
            _Email = Email;
            this.Email = email;
            _IsActive = IsActive;
            this.IsActive = isActive;
            _Role = Role;
            this.Role = role;
            _UserName = UserName;
            this.UserName = userName;
            _DateCreated = DateCreated;
            this.DateCreated = dateCreated;
            _Password = Password;
            this.Password = password;
        }

        public Person() : base()
        {

        }

       

        public  List<Person> GetPeople()
        {
            var person = new List<Person>();
            string sMessage;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                var ds=ReadDataSet(this.GetType().Name,"GetPeople",out sMessage,dbParameters);

                person = ConvertDataTable<Person>(ds.Tables[0]);


            }
            catch (Exception ex)
            {

            }

            return person;

        }


        public bool Create()
        {
            bool bRespuesta = false;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                PropertyInfo[] propertyInfos;
                propertyInfos = this.GetType().GetProperties();                


                Array.Sort(propertyInfos,
                        delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

                
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    dbParameters.Add("@"+ propertyInfo.Name, "" );
                }

                string sMessage = string.Empty;

                CreateUpdateDelete(this.GetType().Name, "Create", out sMessage, dbParameters);

                if (sMessage == "OK")
                {
                    bRespuesta = false;
                }

            }
            catch (Exception)
            {

                bRespuesta = false;
            }
            return bRespuesta;
        }





    }
}