using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL.EntitiesHandler
{
   public class EmployeeHandler
    {

        public static int  Save(Entites.Empolyee empolyee,string dataBaseName)
        {

            App.DAL.Entities.Employee dbEmployee = new DAL.Entities.Employee(dataBaseName);
            return dbEmployee.Save(empolyee);
        }     

       
    }
}
