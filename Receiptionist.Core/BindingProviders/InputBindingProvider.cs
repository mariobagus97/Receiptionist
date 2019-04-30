using Intersoft.Crosslight;

namespace Receiptionist
{
    public class InputBindingProvider : BindingProvider
    {
        #region Constructors

        public InputBindingProvider()
        {
            this.AddBinding("ButtonScan", BindableProperties.CommandProperty, "SearchCommand");
            this.AddBinding("TxtScan", BindableProperties.TextProperty, "SearchPin", BindingMode.TwoWay);
            this.AddBinding("TxtScanID", BindableProperties.TextProperty, "SearchKey", BindingMode.TwoWay);
        }

        #endregion
    }
}