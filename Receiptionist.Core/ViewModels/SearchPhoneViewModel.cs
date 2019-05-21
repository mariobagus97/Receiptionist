using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices.WebApi;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;

namespace Receiptionist.ViewModels
{
    public class SearchPhoneViewModel : EditorViewModelBase<Visitor>
    {
        #region Constructors

        public SearchPhoneViewModel()
        {
            this.PhoneCommand = new DelegateCommand(ExecutePhoneVisitor);
        }
        #endregion

        #region Properties
        
        public SskRestRepository RestRepository
        {
            get { return Container.Current.Resolve<SskRestRepository>(); }
        }

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }
        public DelegateCommand PhoneCommand { get; set; }
        public string SearchPhone { get; set; }
        public Visitor Visitor { get; set; }
        
        #endregion

        #region Method

        public async  void ExecutePhoneVisitor(object parameter)
        {
            try
            {
                this.ActivityPresenter.Show("Loading...", ActivityStyle.SmallIndicatorWithText);
                AppViewModel.Meeting.Visitors.Clear();
                if (string.IsNullOrEmpty(this.SearchPhone))
                    this.MessagePresenter.Show("Masukan nomor handphone");
                else
                {
                    this.Visitor = await RestRepository.GetVisitorAsync(this.SearchPhone);

                    if (string.IsNullOrEmpty(this.Visitor.Name))
                    {
                        this.NavigationService.Navigate<RegisterViewModel>(new NavigationParameter());
                        this.Visitor.VisitorID = Guid.NewGuid();
                        this.Visitor.Phone = this.SearchPhone;
                        
                        AppViewModel.Meeting.Visitors.Add(this.Visitor);
                    }
                    else
                    {
                        this.NavigationService.Navigate<PurposeViewModel>(new NavigationParameter());
                        AppViewModel.Meeting.Visitors.Add(this.Visitor);
                        AppViewModel.Meeting.NameVisitor = this.Visitor.Name;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                this.ToastPresenter.Show(ex.Message);
            }
            this.ActivityPresenter.Hide();
        }
        
        public  override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.Visitor = new Visitor();
        }

        #endregion

    }
}