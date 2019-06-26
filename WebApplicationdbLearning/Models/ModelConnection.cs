using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace WebApplicationdbLearning.Models
{
    public class ModelConnection
    {

        private string sConnection = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public System.Data.SqlClient.SqlConnection sqlConnection = null;

        public ModelConnection()
        {
            sqlConnection= new System.Data.SqlClient.SqlConnection(sConnection);
        }


        protected DataSet ReadDataSet(string sModel, string sMethod, out string sMessage, Dictionary<string,object> dParameters)
        {
            {
                

                DataSet Dst = new DataSet();

                string StrSQL;
                int id = 0;
                XmlDocument Schema;
                Schema = new XmlDocument();
                
                try
                {

                    Schema.Load(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\\Queries\\" + sModel + ".xml"));

                    StrSQL = Schema.GetElementsByTagName(sMethod).Count > 0 ? Schema.GetElementsByTagName(sMethod).Item(0).InnerText : string.Empty;


                    this.sqlConnection.Open();

                    SqlCommand Cmd = new SqlCommand();

                    Cmd.CommandText = StrSQL;

                    foreach (var item in dParameters)
                    {
                        string sOption = item.GetType().Name;
                        switch (sOption)
                        {
                            case "int":
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.Int).Value = item.Value;
                                break;
                            case "DateTime":
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.DateTime).Value = item.Value;
                                break;
                            case "Decimal":
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                                break;
                            case "Double":
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                                break;
                            case "string":
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                                break;
                            
                            default:
                                Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                                break;
                        }

                        

                    }


                    Cmd.Connection = this.sqlConnection;

                    SqlDataAdapter Adp = new SqlDataAdapter();
                    Adp.SelectCommand = Cmd;

                    
                    Adp.Fill(Dst);

                    StrSQL = "";
                    sMessage = "OK";

                }
                catch (Exception ex)
                {
                    sMessage = "ERROR";


                }
                finally
                {
                    this.sqlConnection.Close();
                }

                return Dst;
            }

        }

        protected Object ReadScalar(string sModel, string sMethod, out string sMessage, Dictionary<string, object> dParameters)
        {
            object oResponse = null;


            string StrSQL;
            int id = 0;
            XmlDocument Schema;
            Schema = new XmlDocument();
            
            
            try
            {
                Schema.Load(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\\Queries\\" + sModel + ".xml"));

                StrSQL = Schema.GetElementsByTagName(sMethod).Count > 0 ? Schema.GetElementsByTagName(sMethod).Item(0).InnerText : string.Empty;

                this.sqlConnection.Open();



                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = this.sqlConnection;

                Cmd.CommandText = StrSQL;

                foreach (var item in dParameters)
                {
                    string sOption = item.GetType().Name;
                    switch (sOption)
                    {
                        case "int":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Int).Value = item.Value;
                            break;
                        case "DateTime":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.DateTime).Value = item.Value;
                            break;
                        case "Decimal":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                            break;
                        case "Double":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                            break;
                        case "string":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                            break;

                        default:
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                            break;
                    }
                }




                oResponse = Cmd.ExecuteScalar();

                sMessage = "OK";

            }
            catch (Exception ex)
            {
                sMessage = "ERROR";


            }
            finally
            {
                this.sqlConnection.Close();
            }

            return oResponse;

        }

        protected void CreateUpdateDelete(string sModel, string sMethod, out string sMessage, Dictionary<string, object> dParameters)
        {
            string sResponse = string.Empty;


            string StrSQL;
            int id = 0;
            XmlDocument Schema;
            Schema = new XmlDocument();


            try
            {

                Schema.Load(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\\Queries\\" + sModel + ".xml"));
                StrSQL = Schema.GetElementsByTagName(sMethod).Count > 0 ? Schema.GetElementsByTagName(sMethod).Item(0).InnerText : string.Empty;

                this.sqlConnection.Open();



                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = this.sqlConnection;

                Cmd.CommandText = StrSQL;

                foreach (var item in dParameters)
                {
                    string sOption = item.Value.GetType().ToString();
                    switch (sOption)
                    {
                        case "System.Int":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Int).Value = item.Value;
                            break;
                        case "System.DateTime":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.DateTime).Value = item.Value;
                            break;
                        case "System.Decimal":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                            break;
                        case "System.Double":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                            break;
                        case "System.String":
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                            break;
                        default:
                            Cmd.Parameters.Add("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                            break;
                    }
                }




                 int nlogs= Cmd.ExecuteNonQuery();
                

                sMessage =nlogs>0?"OK":"ERROR";

            }
            catch (Exception ex)
            {
                sMessage = "ERROR";


            }
            finally
            {
                this.sqlConnection.Close();
            }

            

        }

        protected static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }


}