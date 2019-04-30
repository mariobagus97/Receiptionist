using Intersoft.Crosslight;

namespace Receiptionist
{
    public class SearchEmployeeBindingProvider : BindingProvider
    {
        #region Constructors

        public SearchEmployeeBindingProvider()
        {
            this.AddBinding("SearchEmployeeBtn", BindableProperties.CommandProperty, "SearchEmployeeCommand");

           this.AddBinding("DoneBtn", BindableProperties.CommandProperty, "DoneCommand");

           // this.AddBinding("DoneBtn", BindableProperties.IsVisibleProperty, "DoneCommand");

            this.AddBinding("SearchEmployeeText", BindableProperties.TextProperty, "SearchEmployee", BindingMode.TwoWay);

            this.AddBinding("ResultEmployeeText", BindableProperties.TextProperty, "Item.NameEmployee", BindingMode.TwoWay);

            this.AddBinding("StartText", BindableProperties.TextProperty, "Item.StartTime", BindingMode.TwoWay);

            this.AddBinding("EndText", BindableProperties.TextProperty, "Item.EndTime", BindingMode.TwoWay);


            //  this.AddBinding("EmployeeLabel", BindableProperties.TextProperty, "Item.NameEmployee");


        }

        #endregion
    }
}