using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using System;

namespace Receiptionist.ViewModels
{
    public class RegisterViewModel : EditorViewModelBase<Visitor>
    {
        #region Constructors
        public RegisterViewModel()
        {
            this.NextCommand = new DelegateCommand(ExecuteNext);

        }
        #endregion

        #region Private
        private string _phoneText;
        #endregion

        #region Properties
        public DelegateCommand NextCommand { get; set; }
        public string NameText { get; set; }
        public string EmailText { get; set; }
        public string PhoneText
        {
            get { return _phoneText; }
            set
            {
                if (_phoneText != value)
                {
                    _phoneText = value;
                    this.OnPropertyChanged("PhoneText");
                }
            }
        }
        public string CompanyText { get; set; }
        
        #endregion

        #region Methods
        
        public void ExecuteNext(object parameter)
        {
            try
            {
                EmailValidation email = new EmailValidation();
                var emailvalidate = email.ValidateEmail(this.EmailText);
                
                if (string.IsNullOrEmpty(this.NameText))
                {
                    this.MessagePresenter.Show("Nama tidak boleh kosong");
                }

                else if (string.IsNullOrEmpty(this.EmailText))
                {
                    this.MessagePresenter.Show("Email tidak boleh kosong");
                }

                else if (emailvalidate == false)
                {
                    this.MessagePresenter.Show("Email is Not Valid");

                }

                else if (string.IsNullOrEmpty(this.PhoneText))
                {
                    this.MessagePresenter.Show("Nomor telephone tidak boleh kosong");
                }

                else
                {
                    Visitor visitor = new Visitor
                    {
                        Name = this.NameText,
                        Email = this.EmailText,
                        Phone = this.PhoneText,
                        Company = this.CompanyText
                    };

                    this.NavigationService.Navigate<PurposeViewModel>(new NavigationParameter() { Data = visitor });
                    this.NavigationService.Close();
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
            Visitor visitor = parameter.Data as Visitor;
            if (visitor != null)
            {
                this.PhoneText = visitor.Phone;
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
                base.OnPropertyChanged(propertyName);
        }

        #endregion
    }
}