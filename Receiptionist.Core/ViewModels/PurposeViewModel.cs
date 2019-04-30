using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using System;
using System.Collections.Generic;

namespace Receiptionist.ViewModels
{
    public class PurposeViewModel : EditorViewModelBase<Meeting>
    {
        #region Constructors
        
        public PurposeViewModel()
        {
            this.VisitingCommand = new DelegateCommand(ExecuteVisiting);
            this.DeliveryCommand = new DelegateCommand(ExecuteDelivery);
            this.MeetingCommand = new DelegateCommand(ExecuteMeeting);
        }

        #endregion
        

        #region Properties
        public DelegateCommand VisitingCommand { get; set; }
        public DelegateCommand DeliveryCommand { get; set; }
        public DelegateCommand MeetingCommand { get; set; }
        public Meeting Meeting { get; set; }

        #endregion


        #region Methods
        
        public void ExecuteMeeting(object parameter)
        {
            Meeting.Purpose = "Meeting";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter() { Data = Meeting });
        }

        public void ExecuteDelivery(object parameter)
        {
            Meeting.Purpose = "Delivery";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter() { Data = Meeting });
        }

        public void ExecuteVisiting(object parameter)
        {
            Meeting.Purpose = "Visiting";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter() { Data = Meeting });
        }

        public  override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            Visitor visitor = parameter.Data as Visitor;
            Meeting = new Meeting
            {
                MeetingID = Guid.NewGuid(),
                Visitors = new List<Visitor>()
            };

            Meeting.Visitors.Add(visitor);
        }

        #endregion
    }
}