﻿using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using System.Collections.Generic;

namespace Receiptionist.Core.ViewModels
{
    public class ListEmployeeViewModel : ListViewModelBase<Employee>
    {
        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.SourceItems = parameter.Data as ICollection<Employee>;
            
        }
    }
}
