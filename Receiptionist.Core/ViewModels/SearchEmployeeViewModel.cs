using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;
using System.Text;

namespace Receiptionist.ViewModels
{
    public class SearchEmployeeViewModel : EditorViewModelBase<Meeting>
    {
        #region Constructors

        public SearchEmployeeViewModel()
        {
            this.SearchEmployeeCommand = new DelegateCommand(ExecuteSearchEmployee);
            this.DoneCommand = new DelegateCommand(ExecuteDone);
        }

        #endregion

        #region Properties
        public DelegateCommand SearchEmployeeCommand { get; set; }
        public DelegateCommand DoneCommand { get; set; }
        public string SearchEmployee { get; set; }
        public Employee Employee { get; set; }

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }
        

        #endregion

        

        public async void ExecuteSearchEmployee(object parameter)
        {
           AppViewModel.Meeting.Employees.Clear();
           if (string.IsNullOrEmpty(this.SearchEmployee))
            {
                this.MessagePresenter.Show("Masukan email karyawan");
            }
            else
            {
                try
                {
                    this.Employee.Name = this.SearchEmployee;

                    AppViewModel.Meeting.Employees.Add(this.Employee);

                    this.ToastPresenter.Show("Waiting...");

                    RepositoryBase<Meeting> RepositoryMeeting = new RepositoryBase<Meeting>();

                    this.Item = await RepositoryMeeting.GetEmployeeAsync(AppViewModel.Meeting);
                    
                    if (this.Item.Employees.Count == 0)
                    {
                        this.MessagePresenter.Show("Karyawan tidak ditemukan");
                    }
                    else
                    {
                        var employeee = new StringBuilder();

                        foreach (var meetings in this.Item.Employees)
                        {
                            employeee.Append(meetings.Name);
                            employeee.AppendLine();
                        }

                        this.Item.NameEmployee = employeee.ToString();

                        NavigationParameter parameters = new NavigationParameter
                        {
                            Data = this.Item
                        };

                        DialogOptions dialogOptions = new DialogOptions();
                        
                        this.DialogPresenter.Show<ListEmployeeViewModel>(parameters, 
                            new DialogOptions() {

                            Title = "List Employee",
                            Buttons = (DialogButton.Negative | DialogButton.Positive ),
                            NegativeButtonText = "Cancel",
                            PositiveButtonText = "OK",

                            }, (dialogResult) =>
                        {
                            var viewModel = dialogResult.ViewModel as ListEmployeeViewModel; 

                            string button = dialogResult.Button.ToString();

                            if (button == "Positive")
                            {
                                if (viewModel.SelectedItem != null)
                                { 
                                    this.Employee = viewModel.SelectedItem;
                                    
                                    this.Item.Employees.Clear();
                                    this.Item.Employees.Add(this.Employee);
                                    this.ExecuteDone(null);
                                }
                                else
                                {
                                    this.ToastPresenter.Show("Anda belum memilih karyawan");
                                }
                            }
                            else
                            {
                                this.Item = new Meeting();
                                this.ToastPresenter.Show("Anda belum memilih karyawan");
                            }
                            
                        } );
                    }
                }
                catch (Exception ex)
                {
                    this.MessagePresenter.Show(ex.Message);
                }
            }
        }

        public async void ExecuteDone(object parameter)
        {
            try
            {
                if (this.Item.NameEmployee != null)
                {
                    AppViewModel.Meeting = await AppViewModel.SaveMeeting(this.Item);
                    //this.Item = 
                    this.NavigationService.Navigate<MeetingDetailViewModel>(new NavigationParameter());
                }
                else
                {
                    this.MessagePresenter.Show("Cari dan pilih nama karyawan");
                }
            }
            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }


        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.Employee = new Employee();
            this.Item = new Meeting();
        }
        
    }
}