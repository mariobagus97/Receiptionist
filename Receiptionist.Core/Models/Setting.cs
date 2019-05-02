using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intersoft.Crosslight.Forms;
using Receiptionist.Models;
using Intersoft.Crosslight.Data.ComponentModel;
using System.Runtime.Serialization;

namespace Receiptionist.Core.Models
{
    [DataContract]
    public class Setting : ModelBase
    {
        private Guid _settingId;

         private string _generalName;

        private bool _hasBarcode;

        [PrimaryKey]
        public Guid SettingId
        {
            get { return _settingId; }
            set
            {
                if (_settingId != value)
                {
                    _settingId = value;
                    this.OnPropertyChanged("SettingId");
                }
            }
        }

        public string GeneralName
        {
            get { return _generalName; }
            set
            {
                if (_generalName != value)
                {
                    _generalName = value;
                    this.OnPropertyChanged("GeneralName");
                }
            }
        }
        

        public bool HasBarcode
        {
            get { return _hasBarcode; }
            set
            {
                if (_hasBarcode != value)
                {
                    _hasBarcode = value;
                    this.OnPropertyChanged("HasBarcode");
                }
            }
        }




    }
}


