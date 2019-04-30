using Android.App;
using Intersoft.Crosslight.Android;

namespace Receiptionist.Android
{
    /// <summary>
    ///     The splash screen Activity. To change the launcher icon for the Android app, simply change the Icon property.
    /// </summary>
    /// <seealso cref="Intersoft.Crosslight.Android.StartActivity" />
    [Activity(Label = "Receiptionist.Android", MainLauncher = true, NoHistory = true, Icon = "@mipmap/icon", Theme = "@style/Theme.Splash")]
    public class LaunchActivity : StartActivity
    {
    }
}