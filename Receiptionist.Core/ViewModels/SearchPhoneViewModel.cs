using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ViewModels;
using System;

namespace Receiptionist.ViewModels
{
    public class SearchPhoneViewModel : EditorViewModelBase<Visitor>
    {
        #region Constructors

        public SearchPhoneViewModel()
        {
            this.PhoneCommand = new DelegateCommand(ExecutePhoneVisitor);
            VisitorRepository = new VisitorRepository();
        }

        #endregion

        #region Properties

        public VisitorRepository VisitorRepository { get; set; }
        
        public DelegateCommand PhoneCommand { get; set; }

        public string SearchPhone { get; set; }

        #endregion

        #region Method

        public async  void ExecutePhoneVisitor(object parameter)
        {
            try
            {
                Visitor visitor = new Visitor();
                if (string.IsNullOrEmpty(this.SearchPhone))
                {
                    this.MessagePresenter.Show("Masukan nomor handphone");
                }

                else
                {
                    Meeting meeting = new Meeting();
                    AppViewModel app = new AppViewModel();
                    
                    visitor.Phone = this.SearchPhone;
                    Visitor visitors = await this.VisitorRepository.GetVisitorAsync(visitor);
                    
                    if (visitors.Name == null)
                    {
                        this.NavigationService.Navigate<RegisterViewModel>(new NavigationParameter() { Data = visitor });
                    }
                    else
                    {
                        this.NavigationService.Navigate<PurposeViewModel>(new NavigationParameter() { Data = visitors });
                    }
                }
            }
            catch (Exception ex)
            {
                this.ToastPresenter.Show(ex.Message);
            }
        }
        
        public  override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
        }

        #endregion

    }
}