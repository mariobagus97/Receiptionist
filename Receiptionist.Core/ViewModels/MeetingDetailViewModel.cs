using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Infrastructure;
using Receiptionist.ViewModels;
using System;
using System.Collections.Generic;
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
            {
                this.ExecuteClose(null);
            }
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

                foreach (var meetingin in Meeting.Employees)
                {

                    employee.Append(meetingin.Name + " ");
                    employee.AppendLine();
                }

                Meeting.NameEmployee = employee.ToString();
                foreach (var visitoring in Meeting.Visitors)

                {
                    visitor.Append(visitoring.Name + "(");
                    visitor.Append(visitoring.Phone + ")");
                    visitor.AppendLine();
                }

                Meeting.NameVisitor = visitor.ToString();
                this.Item = Meeting;
                
                this.NotifyEmail(null);
            }

            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }

        public void ExecuteClose(object parameter)
        {
            AppViewModel.Meeting = new Meeting
            {
                Employees = new List<Employee>(),
                Visitors = new List<Visitor>()
            };

            this.NavigationService.Navigate<HomeViewModel>(new NavigationParameter());
            this.NavigationService.Close();
        }

       
        public async void NotifyEmail(object parameter)
        {
            Meeting meetingin = await MeetingRepository.NotifyEmailAsync(this.Item);
            foreach (var employee in meetingin.Employees)
            {
                this.ToastPresenter.Show(employee.Name + " already notified");
            }
        }
        #endregion
    }
}
