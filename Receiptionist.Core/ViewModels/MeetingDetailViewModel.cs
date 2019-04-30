using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
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
        public Timer Timer { get; set; }
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand NotifyCommand { get; set; }

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

            Meeting meetinggg = new Meeting();
            meetinggg = this.Item;

            try
            {
                base.Navigated(parameter);
                Meeting meeting = new Meeting();

                meeting = parameter.Data as Meeting;

                var employee = new StringBuilder();
                var visitor = new StringBuilder();

                foreach (var meetingin in meeting.Employees)
                {

                    employee.Append(meetingin.Name + " ");
                    employee.AppendLine();
                }

                meeting.NameEmployee = employee.ToString();
                foreach (var visitoring in meeting.Visitors)

                {
                    visitor.Append(visitoring.Name + "(");
                    visitor.Append(visitoring.Phone + ")");
                    visitor.AppendLine();
                }

                meeting.NameVisitor = visitor.ToString();
                this.Item = meeting;

                //  this.ExecuteNotify(null);
               // this.NotifyEmail(null);
            }

            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }

        public void ExecuteClose(object parameter)
        {
            this.NavigationService.Navigate<HomeViewModel>(new NavigationParameter());
            this.NavigationService.Close();
        }

        public async void ExecuteNotify(object parameter)
        {
            RepositoryBase<Meeting> repository = new RepositoryBase<Meeting>();

            Meeting meetingin = await repository.NotifyAsync(this.Item);


            foreach (var employee in meetingin.Employees)
            {
                this.ToastPresenter.Show(employee.Name + " already notified");
            }

        }

        public async void NotifyEmail(object parameter)
        {

            RepositoryBase<Meeting> repository = new RepositoryBase<Meeting>();
            Meeting meetingin = await repository.NotifyEmailAsync(this.Item);

            foreach (var employee in meetingin.Employees)
            {
                this.ToastPresenter.Show(employee.Name + " already notified");
            }

        }
        #endregion


      

    }
}
