using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;
using Receiptionist.Core.BindingProviders;
using Receiptionist.Core.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(EmployeeDetailBindingProvider))]
    public class EmployeeDetailFragment : Fragment<EmployeeDetailViewModel>
    {
        #region Constructors

        public EmployeeDetailFragment()
        {
        }

        public EmployeeDetailFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.EmployeeDetail; }
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