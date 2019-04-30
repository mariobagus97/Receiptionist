using Intersoft.Crosslight;

namespace Receiptionist
{
    public class SearchPhoneBindingProvider : BindingProvider
    {
        #region Constructors

        public SearchPhoneBindingProvider()
        {
            this.AddBinding("BtnPhone", BindableProperties.CommandProperty, "PhoneCommand");
            this.AddBinding("SearchPhoneText", BindableProperties.TextProperty, "SearchPhone", BindingMode.TwoWay);
            


        }

        #endregion
    }
}