using Android.App;
using Receiptionist.ViewModels;
using Intersoft.Crosslight.Android.v7;

namespace Receiptionist.Android.Activities
{
    /// <summary>
    ///     The main activity that acts as the host for SimpleFragment.
    /// </summary>
    /// <seealso cref="Intersoft.Crosslight.Android.v7.AppCompatActivity{Receiptionist.ViewModels.HomeViewModel}" />
    [Activity]
    public class SimpleActivity : AppCompatActivity<HomeViewModel>
    {
    }
}