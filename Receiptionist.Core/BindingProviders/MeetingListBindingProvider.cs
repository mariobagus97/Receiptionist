using Intersoft.Crosslight;

namespace Receiptionist
{
    public class MeetingListBindingProvider : BindingProvider
    {
        #region Constructors

        public MeetingListBindingProvider()
        { 
        ItemBindingDescription itemBinding = new ItemBindingDescription()
        { 
            DisplayMemberPath = "MeetingPin",
            DetailMemberPath = "MeetingKey",

        };

            this.AddBinding("TableView", BindableProperties.ItemsSourceProperty, "Items");
            this.AddBinding("TableView", BindableProperties.ItemTemplateBindingProperty, itemBinding, true);
            this.AddBinding("TableView", BindableProperties.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
            this.AddBinding("TableView", BindableProperties.SelectedItemsProperty, "SelectedItems", BindingMode.TwoWay);
          //  this.AddBinding("TableView", BindableProperties.DetailNavigationTargetProperty, new NavigationTarget(typeof(PatientDetailViewModel)), true);

          //  this.AddBinding("SingleDeleteButton", BindableProperties.CommandProperty, "SingleDeleteCommand");
           // this.AddBinding("SingleDeleteButton", BindableProperties.CommandParameterProperty, "SelectedItem");
    }

    #endregion
}
}