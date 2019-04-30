using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Receiptionist.ViewModels;
using Receiptionist.Core.BindingProviders;
using Receiptionist.Core.ViewModels;
using Intersoft.Crosslight.Android;
using System.Collections.Generic;

namespace Receiptionist.Android.Fragments
{
    [ImportBinding(typeof(ListEmployeeBindingProvider))]
    public class ListEmployeeFragment : RecyclerViewFragment<ListEmployeeViewModel>
    {
        #region Constructors

        public ListEmployeeFragment() 
        {
        }

        public ListEmployeeFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ItemLayoutId
        {
            get { return Resource.Layout.NewListEmployee; }
        }

        //protected override int ContentLayoutId
        //{
        //    get { return Resource.Layout.ListEmployee; }
        //}
        
        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.ImageLoaderSettings.AnimateOnLoad = true;

            this.InteractionMode = ListViewInteraction.ChoiceInput;
            this.ChoiceInputMode = ChoiceInputMode.Single;

            this.ToolbarSettings.IsVisible = false;
        }
        #endregion
    }
}