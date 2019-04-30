using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Receiptionist.Core.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Android.Runtime;

namespace Receiptionist.Android.Fragments
{
    public class SettingFragment : FormFragment<SettingViewModel>
    {
        #region Constructors

        public SettingFragment()
        {

        }

        public SettingFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("SaveButton", CommandItemType.Done));
        }

        #endregion
    }
}