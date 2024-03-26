using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] fieldsNames)
        {
            Type type = Type.GetType(investigatedClass);
            FieldInfo[] classFields = type.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(type, new object[] {});

                return null;
        }
        

       
    }
}
