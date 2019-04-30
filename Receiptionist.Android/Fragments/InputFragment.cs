using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(InputBindingProvider))]
    public class InputFragment : Fragment<InputViewModel>
    {
        #region Constructors
        public InputFragment()
        {
        }
        #endregion
        
        #region Properties
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.input; }
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