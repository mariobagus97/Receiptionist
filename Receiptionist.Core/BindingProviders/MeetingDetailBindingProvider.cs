using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptionist.Core.BindingProviders
{
    public class MeetingDetailBindingProvider : BindingProvider
    {
        #region Constructors

        public MeetingDetailBindingProvider()
        {

            this.AddBinding("PurposeLabel", BindableProperties.TextProperty, "Item.Purpose");
            this.AddBinding("StartTimeLabel", BindableProperties.TextProperty, "Item.StartTime");
            this.AddBinding("EndTimeLabel", BindableProperties.TextProperty, "Item.EndTime");
            this.AddBinding("MeetingPinLabel", BindableProperties.TextProperty, "Item.MeetingPin");

            this.AddBinding("CloseBtn", BindableProperties.CommandProperty, "CloseCommand");
            this.AddBinding("CloseBtn", BindableProperties.TextProperty, "CloseText");
            //  this.AddBinding("CloseBtn", BindableProperties.ima
            this.AddBinding("BtnBindImage", BindableProperties.CommandProperty, "SelectImageCommand");
            this.AddBinding("ImgBindImage", BindableProperties.ImageProperty, "BoundImage");

            this.AddBinding("VisitorLabel", BindableProperties.TextProperty, "Item.NameVisitor");
            this.AddBinding("EmployeeLabel", BindableProperties.TextProperty, "Item.NameEmployee");
            
            

        }

        #endregion

    }
}
