using Intersoft.Crosslight;

namespace Receiptionist
{
    public class IntroBindingProvider : BindingProvider
    {
        #region Constructors

        public IntroBindingProvider()
        {
            this.AddBinding("BtnRegister", BindableProperties.CommandProperty, "RegisterCommand");
            this.AddBinding("BtnInput", BindableProperties.CommandProperty, "InputCommand");

        }

        #endregion
    }
}