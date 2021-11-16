using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Contract
{
   public class DBContextBase
    {
        string _dataBaseName = "";

        public enum ParameterType
        {
           
            Insert,
            Update,
            Delete,
            Get
        }
        public DBContextBase(string dataBaseName)
        {
            _dataBaseName = dataBaseName;

        }
        protected string DataBaseName { get { return _dataBaseName; } }
    }
}

