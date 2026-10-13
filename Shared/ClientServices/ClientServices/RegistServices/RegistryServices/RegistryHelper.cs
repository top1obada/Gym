using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace ClientServices.ClientServices.RegistServices.RegistryServices
{


    public class RegistryHelper : IRegistService
    {
        private readonly RegistryKey baseKey;
        private readonly string subKeyPath;

        public RegistryHelper(string subKeyPath, RegistryHive hive = RegistryHive.CurrentUser)
        {
            this.subKeyPath = subKeyPath;

            baseKey = hive switch
            {
                RegistryHive.LocalMachine => Registry.LocalMachine,
                RegistryHive.CurrentUser => Registry.CurrentUser,
                RegistryHive.ClassesRoot => Registry.ClassesRoot,
                RegistryHive.Users => Registry.Users,
                RegistryHive.CurrentConfig => Registry.CurrentConfig,
                _ => Registry.CurrentUser
            };
        }


        private RegistryKey? OpenKey(bool writable)
        {
            return writable
                ? baseKey.CreateSubKey(subKeyPath, true)
                : baseKey.OpenSubKey(subKeyPath, false);
        }


        public void SetValue(string name, object value)
        {
            using var key = OpenKey(true);
            key.SetValue(name, value);
        }

       
        public object GetValue(string name, object defaultValue = null)
        {
            using var key = OpenKey(false);
            return key?.GetValue(name, defaultValue);
        }

       
        public void UpdateValue(string name, object value)
        {
            SetValue(name, value);
        }

       
        public void DeleteValue(string name)
        {
            using var key = OpenKey(true);
            key?.DeleteValue(name, false);
        }

       
        public void DeleteKey()
        {
            baseKey.DeleteSubKeyTree(subKeyPath, false);
        }

       
        public bool ValueExists(string name)
        {
            using var key = OpenKey(false);
            return key?.GetValue(name) != null;
        }

        

    }
}
