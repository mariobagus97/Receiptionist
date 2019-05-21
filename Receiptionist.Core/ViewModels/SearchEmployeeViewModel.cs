using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices.WebApi;
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
        public Employee Employee { get; set; }

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public SskRestRepository RestRepository
        {
            get { return Container.Current.Resolve<SskRestRepository>(); }
        }
        #endregion
        
        public async void ExecuteSearchEmployee(object parameter)
        {
            AppViewModel.Meeting.Employees.Clear();
            if (string.IsNullOrEmpty(this.SearchEmployee))
                this.MessagePresenter.Show("Masukan email karyawan");
            else
            {
                try
                {
                    this.ToastPresenter.Show("Waiting...");
                    List<Employee> Employees = await RestRepository.GetEmployeeAsync(this.SearchEmployee);

                    if (Employees.Count == 0)
                        this.MessagePresenter.Show("Karyawan tidak ditemukan");
                    else
                    {
                        var employeee = new StringBuilder();
                        foreach (var employee in Employees)
                        {
                            employeee.Append(employee.Name);
                            employeee.AppendLine();
                        }
                        this.Item.NameEmployee = employeee.ToString();

                        NavigationParameter parameters = new NavigationParameter
                        {
                            Data = Employees
                        };

                        DialogOptions dialogOptions = new DialogOptions();

                        this.DialogPresenter.Show<ListEmployeeViewModel>(parameters,
                            new DialogOptions()
                            {

                                Title = "List Employee",
                                Buttons = (DialogButton.Negative | DialogButton.Positive),
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
                                        //this.Item.Employees = new List<Employee>();
                                        //this.Item.Employees.Add(this.Employee);
                                        AppViewModel.Meeting.Employees.Add(this.Employee);
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

                            });
                    }
                }
                catch (Exception ex)
                {
                    this.ToastPresenter.Show(ex.Message);
                }
            }
        }

        public async void ExecuteDone(object parameter)
        {
            try
            {
                this.ActivityPresenter.Show("Loading...", ActivityStyle.SmallIndicatorWithText);
                if (!string.IsNullOrEmpty(this.Item.NameEmployee))
                {
                    AppViewModel.Meeting.NameEmployee = this.Item.NameEmployee;
                    AppViewModel.Meeting = await AppViewModel.SaveMeeting(AppViewModel.Meeting);
                    this.NavigationService.Navigate<MeetingDetailViewModel>(new NavigationParameter());
                }
                else
                    this.MessagePresenter.Show("Cari dan pilih nama karyawan");
            }
            catch (Exception ex)
            {
                this.ToastPresenter.Show(ex.Message);
            }
            this.ActivityPresenter.Hide();
        }


        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.Employee = new Employee();
            this.Item = new Meeting();
        }

    }
}