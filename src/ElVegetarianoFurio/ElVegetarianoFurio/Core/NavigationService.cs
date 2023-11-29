using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Core
{
    public class NavigationService : INavigationService
    {
        public Task GoToAsync(string location)
        {
            return Shell.Current.GoToAsync(location);
        }

        public Task GoToAsync(string location, bool animate)
        {
            return Shell.Current.GoToAsync(location, animate);
        }

        public Task GoToAsync(string location, Dictionary<string, object> paramters)
        {
            return Shell.Current.GoToAsync(location, paramters);
        }

        public Task GoToAsync(string location, bool animate, Dictionary<string, object> paramters)
        {
            return Shell.Current.GoToAsync(location, animate, paramters);
        }
    }
}
