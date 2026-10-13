using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServices.ClientServices.RegistServices
{
    public interface IRegistService
    {
        public void SetValue(string name, object value);
        public object GetValue(string name, object defaultValue = null);
        public void UpdateValue(string name, object value);
        public void DeleteValue(string name);
        public void DeleteKey();
        public bool ValueExists(string name);
    }
}
