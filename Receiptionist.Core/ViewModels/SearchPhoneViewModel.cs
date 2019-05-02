using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;
using System.Collections.Generic;

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

        public IVisitorRepository VisitorRepository
        {
            get { return Container.Current.Resolve<IVisitorRepository>(); }
        }

        //public AppViewModel AppViewModel
        //{
        //    get { return Container.Current.Resolve<AppViewModel>(); }
        //}

        public DelegateCommand PhoneCommand { get; set; }

        public string SearchPhone { get; set; }

        #endregion

        #region Method

        public async  void ExecutePhoneVisitor(object parameter)
        {
            try
            {
                
                if (string.IsNullOrEmpty(this.SearchPhone))
                {
                    this.MessagePresenter.Show("Masukan nomor handphone");
                }

                else
                {

                    Visitor visitor = new Visitor
                    {
                        Phone = this.SearchPhone
                    };
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