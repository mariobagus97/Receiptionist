using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Forms;
using System.Collections;

namespace Receiptionist.Core.FormMetaData
{
    public class VisitorFormMetaData
    {
        #region Sections

        [Section(Header = "Receiptionist")]
        public PertamaSection Pertama;
        #endregion


        public class PertamaSection
        {
            [Editor(EditorType.TextView)]
            [Layout(Style = LayoutStyle.RightDetail)]
            public string FirstName;

            [Editor(EditorType.TextView)]
            [Layout(Style = LayoutStyle.RightDetail)]
            public string LastName;
            
            [Editor(EditorType.Label)]
            [Display(Caption = "Health")]
            [Binding(Path = "Value", SourceType = BindingSourceType.Model)]
            public string CurrentValue;
            

        }

    }
}
