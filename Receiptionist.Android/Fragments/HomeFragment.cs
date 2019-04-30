    using System;
    using Android.Runtime;
    using Intersoft.Crosslight;
    using Intersoft.Crosslight.Android.v7;
    using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(HomeBindingProvider))]
    public class HomeFragment : Fragment<HomeViewModel>
    {
        #region Constructors
        public HomeFragment()
        {
        }
        public HomeFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties
        
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.main; }
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