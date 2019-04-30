using Intersoft.Crosslight.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptionist.Core.FormMetaData
{
    public class SettingFormMetaData
    {
        #region Sections
        [Section(Header = "Setting")]
        public SettingSection setting;
        #endregion

        public class SettingSection
        {
            [Editor(EditorType.Switch)]
            [Display(Caption = "BarcodeScanner")]
            public bool HasBarcode;
        }
    }
}
