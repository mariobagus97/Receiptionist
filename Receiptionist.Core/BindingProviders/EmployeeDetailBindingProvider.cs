using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptionist.Core.BindingProviders
{
    public class EmployeeDetailBindingProvider : BindingProvider
    {
        #region Constructors

        public EmployeeDetailBindingProvider()
        {

            this.AddBinding("NameLabel", BindableProperties.TextProperty, "Item.Name");
            this.AddBinding("CompanyLabel", BindableProperties.TextProperty, "Item.Company");
            
            
            

        }

        #endregion

    }
}
