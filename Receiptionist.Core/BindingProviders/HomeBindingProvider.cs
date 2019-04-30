using Intersoft.Crosslight;

namespace Receiptionist
{
    public class HomeBindingProvider : BindingProvider
    {
        #region Constructors

        public HomeBindingProvider()
        {
            this.AddBinding("BtnMeeting", BindableProperties.CommandProperty, "MeetingCommand");
            this.AddBinding("BtnSetting", BindableProperties.CommandProperty, "SettingCommand");




        }

        #endregion
    }
}