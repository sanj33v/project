using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entites;
using static App.DAL.Contract.DBContextBase;

namespace App.DAL.Entities
{
    public class Employee:Contract.DBContextBase
    {

        public Employee(string dataBaseName):base(dataBaseName)
        {


        }


        public int Save(App.Entites.Empolyee empolyee)
        {
            int returnId = -1;

            try
            {
                if (empolyee.Id > 0)
                {
                    return Update(empolyee);
                }
                else
                {
                    return Insert(empolyee);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return returnId;

        }
        public Entites.Empolyee GetById(int Id)
        {
            Entites.Empolyee empolyee = null;


            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }

            return empolyee;
            
        }
        private int Insert(Entites.Empolyee empolyee)
        {
            int Id = -1;
            try
            {
                 Id = DBHelper.DbHelper.ExceuteStoredPrcoReturnID("usp_Insert_Employee", GetInsertParameters(empolyee), this.DataBaseName);
               
            }
            catch (Exception)
            {

                throw;
            }

            return Id;

        }
        private int Update(Entites.Empolyee empolyee)
        {
            int Id = -1;
            try
            {
                Id = DBHelper.DbHelper.ExceuteStoredPrcoReturnID("usp_Update_Employee", GetUpdateParameters(empolyee), this.DataBaseName);
            }
            catch (Exception)
            {

                throw;
            }
            return Id;
        }
         private Entites.Empolyee ToObject(int Id)
         {
            DataSet ds = new DataSet();
            try
            {
                ds = DBHelper.DbHelper.GetStoredPrcoReturnbyDataSet("usp_GetEmployee", 
                    
                   new SqlParameter[]{
                       new SqlParameter("@EmpId",Id)
                   }, this.DataBaseName);
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        
        private SqlParameter[] GetInsertParameters(Entites.Empolyee empolyee)
        {

            return new SqlParameter[]
            {

                new SqlParameter("@Name",empolyee.Name),
                new SqlParameter("@Address",empolyee.Address),
                new SqlParameter("@Phone",empolyee.Phone),
                new SqlParameter("@Email",empolyee.Email)
            };
        }

        private SqlParameter[] GetUpdateParameters(Entites.Empolyee empolyee)
        {

            return new SqlParameter[]
            {
                new SqlParameter("@Id",empolyee.Id),
                new SqlParameter("@Name",empolyee.Name),
                new SqlParameter("@Address",empolyee.Address),
                new SqlParameter("@Phone",empolyee.Phone),
                new SqlParameter("@Email",empolyee.Email)
            };
        }
         private SqlParameter[] GetParameters(Entites.Empolyee empolyee)
         {

             return new SqlParameter[]
                {
                new SqlParameter("@Id",empolyee.Id),
               
                };
             }
    }
}
