using Intersoft.Crosslight;

namespace Receiptionist
{
    public class PurposeBindingProvider : BindingProvider
    {
        #region Constructors

        public PurposeBindingProvider()
        {
            this.AddBinding("BtnMeeting", BindableProperties.CommandProperty, "MeetingCommand");
            this.AddBinding("BtnDelivery", BindableProperties.CommandProperty, "DeliveryCommand");
            this.AddBinding("BtnVisiting", BindableProperties.CommandProperty, "VisitingCommand");

        }
        #endregion
    }
}