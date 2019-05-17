using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Infrastructure;
using Receiptionist.ViewModels;
using System;
using System.Text;

namespace Receiptionist.Core.ViewModels
{
    public class MeetingDetailViewModel : EditorViewModelBase<Meeting>
    {
        #region Constructors

        public MeetingDetailViewModel()
        {
            this.CloseCommand = new DelegateCommand(ExecuteClose);
            this.Timer = new Timer(this.CheckData, 0, 0, 1000);
            this.CountDown = 30;
            this.UpdateCountDownText();
            Meeting = new Meeting();
        }
        #endregion

        #region Fields
        private string _closeText;
        #endregion

        #region Properties
        public int CountDown { get; set; }
        public string CloseText
        {
            get { return _closeText; }
            set
            {
                if (_closeText != value)
                {
                    _closeText = value;
                    this.OnPropertyChanged("CloseText");
                }
            }
        }
        public Meeting Meeting { get; set; }
        public Timer Timer { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand NotifyCommand { get; set; }
        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public IMeetingRepository MeetingRepository
        {
            get { return Container.Current.Resolve<IMeetingRepository>(); }
        }

        #endregion

        #region Methods
        public void UpdateCountDownText()
        {
            this.CloseText = "Close (" + this.CountDown + ")";
        }

        public void CheckData(object parameter)
        {
            this.CountDown--;
            this.UpdateCountDownText();

            if (this.CountDown == 0)
                this.ExecuteClose(null);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            this.Timer.Dispose();
            this.Timer = null;
        }

        public override void Navigated(NavigatedParameter parameter)
        {
            try
            {
                base.Navigated(parameter);

                Meeting = AppViewModel.Meeting;

                var employee = new StringBuilder();
                var visitor = new StringBuilder();

                foreach (var meetings in Meeting.Employees)
                {
                    employee.Append(meetings.Name + " ");
                    employee.AppendLine();
                }

                Meeting.NameEmployee = employee.ToString();
                foreach (var visitors in Meeting.Visitors)
                {
                    visitor.Append(visitors.Name + "(");
                    visitor.Append(visitors.Phone + ")");
                    visitor.AppendLine();
                }

                Meeting.NameVisitor = visitor.ToString();
                this.Item = Meeting;
                
                this.NotifyEmail();
            }
            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }

        public void ExecuteClose(object parameter)
        {
            AppViewModel.NewMeeting();
            this.NavigationService.Navigate<HomeViewModel>(new NavigationParameter());
            this.NavigationService.Close();
            SearchEmployeeViewModel searchEmployee = new SearchEmployeeViewModel();
            searchEmployee.NavigationService.Close();
        }
        
        public async void NotifyEmail()
        {
            RestRepositoryBase<Meeting> repository = new RestRepositoryBase<Meeting>();
            Meeting meetings = await repository.NotifyEmailAsync(this.Item);
            if (meetings != null)
            {
                foreach (var employee in meetings.Employees)
                {
                    this.ToastPresenter.Show(employee.Name + " already notified");
                }
            }
            else
                this.ToastPresenter.Show("failed to notify employees");
        }
        #endregion
    }
}
