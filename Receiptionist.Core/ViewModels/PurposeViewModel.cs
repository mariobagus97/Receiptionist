using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;

namespace Receiptionist.ViewModels
{
    public class PurposeViewModel : ViewModelBase
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
        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }
        #endregion


        #region Methods

        public void ExecuteMeeting(object parameter)
        {
            AppViewModel.Meeting.Purpose = "Meeting";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter());
        }

        public void ExecuteDelivery(object parameter)
        {
            AppViewModel.Meeting.Purpose = "Delivery";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter());
        }

        public void ExecuteVisiting(object parameter)
        {
            AppViewModel.Meeting.Purpose = "Visiting";
            this.NavigationService.Navigate<SearchEmployeeViewModel>(new NavigationParameter());
        }

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            AppViewModel.Meeting.MeetingID = Guid.NewGuid();
        }
        #endregion
    }
}