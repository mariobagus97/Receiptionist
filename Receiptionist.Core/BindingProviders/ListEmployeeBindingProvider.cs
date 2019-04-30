using Intersoft.Crosslight;
using Receiptionist.Core.ViewModels;
using Receiptionist.ViewModels;

namespace Receiptionist
{
    public class ListEmployeeBindingProvider : BindingProvider
    {
        #region Constructors

        public ListEmployeeBindingProvider()
        {

            ItemBindingDescription itemBinding = new ItemBindingDescription()
            {
                DisplayMemberPath = "Name",
                DetailMemberPath = "Company",
                ImageMemberPath = "ResolvedThumbnailImage",
                ImagePlaceholder = "orang.jpg"
            };

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.SelectedItemsProperty, "SelectedItems", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(SearchEmployeeViewModel)), true);
            
        }
    }

        #endregion
    }
