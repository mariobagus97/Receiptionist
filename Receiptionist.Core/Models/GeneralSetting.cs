using Intersoft.Crosslight.Data.ComponentModel;
using Receiptionist.Models;
using System;

namespace Receiptionist.Core.Models
{
    public class GeneralSetting : ModelBase
    {
        #region Fields

        private string _generalName;
        private Guid _settingId;
        private string _generalNameJson;

        #endregion

        #region Properties

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

        public string GeneralNameJson
        {
            get { return _generalNameJson; }
            set
            {
                if (_generalNameJson != value)
                {
                    _generalNameJson = value;
                    this.OnPropertyChanged("GeneralNameJson");
                }
            }
        }

        #endregion

    }
}
