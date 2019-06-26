using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationdbLearning.Models
{
    public class Semantic
    {
        private int _SemanticId;

        public int SemanticId
        {
            get { return _SemanticId; }
            set { _SemanticId = value; }
        }

        private int _Name;

        public int Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
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