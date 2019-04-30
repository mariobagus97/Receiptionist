using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(SearchPhoneBindingProvider))]
    public class SearchPhoneFragment : Fragment<SearchPhoneViewModel>
    {
        #region Constructors
        public SearchPhoneFragment()
        {
            
        }
        #endregion


        #region Properties
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.SearchPhone; }
            
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