using Intersoft.Crosslight.Data.ComponentModel;
using Receiptionist.Models;
using System;
using System.Runtime.Serialization;

namespace Receiptionist.Core.Models
{
    [DataContract]
    public class Setting : ModelBase
    {
        #region Fields
        
        private string _generalName;
        private bool _hasBarcode;
        private Guid _settingId;

        #endregion

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


