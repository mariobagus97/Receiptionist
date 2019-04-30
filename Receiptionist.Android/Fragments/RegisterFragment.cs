using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(RegisterBindingProvider))]
    public class RegisterFragment : Fragment<RegisterViewModel>
    {
        #region Constructors
        public RegisterFragment()
        {

        }
        #endregion
        
        #region Properties
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.register; }
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