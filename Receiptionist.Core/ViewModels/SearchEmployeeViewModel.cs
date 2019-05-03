using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;
using System.Collections.Generic;
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

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public IMeetingRepository MeetingRepository
        {
            get { return Container.Current.Resolve<IMeetingRepository>(); }
        }

        #endregion

        public async void ExecuteDone(object parameter)
        {
            try
            {
                Meeting Meeting = new Meeting();
                Meeting = this.Item;
                
                if (Meeting.NameEmployee != null)
                {
                    await AppViewModel.CreateMeeting(Meeting);
                    this.Item = AppViewModel.Meeting;
                    this.NavigationService.Navigate<MeetingDetailViewModel>(new NavigationParameter() { Data = this.Item });
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


        public async void ExecuteSearchEmployee(object parameter)
        {
            //Meeting meeting = new Meeting();
            //meeting = this.Item;

           // meeting.Employees = new List<Employee>();
            Employee employee = new Employee();
            employee.Name = this.SearchEmployee;

            AppViewModel.Meeting.Employees.Add(employee);
            //meeting.Employees.Add(employee);

           if (string.IsNullOrEmpty(this.SearchEmployee))
            {
                this.MessagePresenter.Show("Masukan email karyawan");
            }
            else
            {
                try
                {
                    this.ToastPresenter.Show("Waiting...");

                    Meeting meetingin = await this.MeetingRepository.GetEmployeeAsync(AppViewModel.Meeting);
                    
                    if (meetingin.Employees.Count == 0)
                    {
                        this.MessagePresenter.Show("Karyawan tidak ditemukan");
                    }

                    else
                    {
                        var employeee = new StringBuilder();

                        foreach (var meetingins in meetingin.Employees)
                        {
                            employeee.Append(meetingins.Name);
                            employeee.AppendLine();
                        }

                        meetingin.NameEmployee = employeee.ToString();
                        
                        NavigationParameter parameters = new NavigationParameter();
                        parameters.Data = meetingin;

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
                                Employee employees = new Employee();
                                employees = viewModel.SelectedItem;

                                
                                    meetingin.Employees.Clear();
                                    meetingin.Employees.Add(employees);

                                    this.Item = meetingin;
                                    this.ExecuteDone(null);
                                }
                                else
                                {
                                    this.ToastPresenter.Show("Anda belum memilih karyawan");
                                }
                            }
                            else
                            {
                                meetingin = new Meeting();
                                this.Item = meetingin;
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

        public  override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            //Meeting meeting = parameter.Data as Meeting;
            //this.Item = meeting;
        }
        
    }
}