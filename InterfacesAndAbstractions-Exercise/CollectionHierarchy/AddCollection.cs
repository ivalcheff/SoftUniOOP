using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        protected List<string> collection;

        public AddCollection() 
        { 
            collection = new List<string>();
        }

        public virtual int Add(string input)
        {
            collection.Add(input);
            return collection.Count-1;
        }
    }
}
