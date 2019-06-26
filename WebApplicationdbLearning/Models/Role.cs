using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationdbLearning.Models
{
    public class Role:ModelConnection
    {
        public Role():base()
        {

        }





        private int _RoleId;

        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private string _RoleName;

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private DateTime _DateCreated;

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

        public List<Role> GetRoles()
        {
            var oRole = new List<Role>();
            string sMessage;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                var ds = ReadDataSet(this.GetType().Name, "Read", out sMessage, dbParameters);

                oRole = ConvertDataTable<Role>(ds.Tables[0]);


            }
            catch (Exception ex)
            {

            }

            return oRole;

        }

        public bool Create()
        {
            bool bRespuesta = false;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                dbParameters.Add("RoleName", this.RoleName);

                string sMessage = string.Empty;

                CreateUpdateDelete(this.GetType().Name, "Create", out sMessage, dbParameters);

                if (sMessage=="OK")
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

        public bool Update()
        {
            bool bRespuesta = false;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                dbParameters.Add("RoleName", this.RoleName);
                dbParameters.Add("RoleId", this.RoleId);

                string sMessage = string.Empty;

                CreateUpdateDelete(this.GetType().Name, "Update", out sMessage, dbParameters);

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

        public bool Delete()
        {
            bool bRespuesta = false;
            try
            {
                var dbParameters = new Dictionary<string, object>();

                
                dbParameters.Add("RoleId", this.RoleId);

                string sMessage = string.Empty;

                CreateUpdateDelete(this.GetType().Name, "Delete", out sMessage, dbParameters);

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