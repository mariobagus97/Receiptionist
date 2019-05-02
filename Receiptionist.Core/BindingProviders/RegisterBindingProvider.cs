using Intersoft.Crosslight;

namespace Receiptionist
{
    public class RegisterBindingProvider : BindingProvider
    {
        #region Constructors

        public RegisterBindingProvider()
        {
            this.AddBinding("BtnNext", BindableProperties.CommandProperty, "NextCommand");

            this.AddBinding("TxtName", BindableProperties.TextProperty, "NameText", BindingMode.TwoWay);
            this.AddBinding("TxtEmail", BindableProperties.TextProperty, "EmailText", BindingMode.TwoWay); //item.EmailText
            this.AddBinding("TxtCompany", BindableProperties.TextProperty, "CompanyText", BindingMode.TwoWay);
            this.AddBinding("TxtPhone", BindableProperties.TextProperty, "PhoneText", BindingMode.TwoWay);
            
            this.AddBinding("EmailValid", BindableProperties.TextProperty, "item.EmailValid", BindingMode.TwoWay);

        }

        #endregion
    }
}