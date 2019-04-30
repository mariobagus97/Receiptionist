using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;

namespace Receiptionist.ViewModels
{
    public class IntroViewModel : ViewModelBase
    {

        #region Constructors
        
        public IntroViewModel()
        {
            this.RegisterCommand = new DelegateCommand(ExecuteRegister);
            this.InputCommand = new DelegateCommand(ExecuteInput);
        }

        #endregion
        
        #region Properties
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand InputCommand { get; set; }
        #endregion

        #region Methods
        public void ExecuteRegister(object parameter)
        {
            this.NavigationService.Navigate<RegisterViewModel>(new NavigationParameter());
        }

        public void ExecuteInput(object parameter)
        {
            this.NavigationService.Navigate<InputViewModel>(new NavigationParameter());
        }
        #endregion
    }
}