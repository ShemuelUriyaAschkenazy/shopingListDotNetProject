using BE;
using DAL;
using System;
using System.Reflection;

namespace BLL
{
    public class AddingValues
    {
        private DbAdapter dbAdapter;

        public AddingValues()
        {
            dbAdapter = new DbAdapter();
        }

        public void Save(Category category)
        {
            
            dbAdapter.Save(category);
        }

        public void AddCategoty(Category obj)
        {
            dbAdapter.AddCategory(obj);
                
        }
    }
}
