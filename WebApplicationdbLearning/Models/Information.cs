using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationdbLearning.Models
{
    public class Information
    {
        private int _InformationId;

        public int InformationId
        {
            get { return _InformationId; }
            set { _InformationId = value; }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        private int _ConceptId;

        public int ConceptId
        {
            get { return _ConceptId; }
            set { _ConceptId = value; }
        }

        private int _PersonId;

        public int PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
        }

        private DateTime _DateCreated;

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }       

    }
}