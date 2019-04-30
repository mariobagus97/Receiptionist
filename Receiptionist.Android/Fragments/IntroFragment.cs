using Android.OS;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(IntroBindingProvider))]
    public class IntroFragment : Fragment<IntroViewModel>
    {
        #region Constructors

        public IntroFragment()
        {
        }

        #endregion

            #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.intro; }
        }
        
        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.ToolbarSettings.IsVisible = false;
        }
        
        #endregion
    }
}