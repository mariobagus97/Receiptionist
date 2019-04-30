using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(SearchEmployeeBindingProvider))]
    public class SearchEmployeeFragment : Fragment<SearchEmployeeViewModel>
    {
        #region Constructors
        public SearchEmployeeFragment()
        {
            
        }
        #endregion


        #region Properties
        protected override int ContentLayoutId
        {
            get { return Resource.Layout.EmployeeSearch; }
            
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