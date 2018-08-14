using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tkhmeanMVC.Data.Helpers
{
    public static class ModelHelpers
    {

        // Generate a random string ID
        public static string generateUniqueId()
        {
        

           return Guid.NewGuid().ToString("N")+ "t=" + DateTime.Now.ToShortTimeString().Replace(" ",string.Empty);
          
        }

    }
}
