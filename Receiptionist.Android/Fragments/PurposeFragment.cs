using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(PurposeBindingProvider))]
    public class PurposeFragment : Fragment<PurposeViewModel>
    {
        #region Constructors
        public PurposeFragment()
        {
        }
        #endregion
        
        #region Properties
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.purpose; }
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