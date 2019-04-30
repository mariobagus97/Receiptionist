using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;
using Receiptionist.Core.BindingProviders;
using Receiptionist.Core.ViewModels;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(MeetingDetailBindingProvider))]
    public class MeetingDetailFragment : Fragment<MeetingDetailViewModel>
    {
        #region Constructors
        public MeetingDetailFragment()
        {
        }

        public MeetingDetailFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.MeetingDetail; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.Title = "Meeting Detail";
            this.AddBarItem(new BarItem("ConfirmButton", CommandItemType.Done));

            this.ToolbarSettings.IsVisible = false;

        }

        #endregion
    }
}