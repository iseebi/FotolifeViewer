using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using FotolifeViewer.Core.Models;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FotolifeViewer.Touch.Views
{
    public partial class FotolifeCell : MvxTableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("FotolifeCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("FotolifeCell");
        public static readonly float CellHeight = 101.0f;

        public FotolifeCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<FotolifeCell, HatenaFotolifeItem>();
                set.Bind(TitleLabel).To(item => item.Title);
                set.Bind(DateLabel).To(item => item.Date);
                set.Bind(ImageView).To(item => item.ImageUrlMedium);
                set.Apply();
            });
        }

        public static FotolifeCell Create()
        {
            return (FotolifeCell)Nib.Instantiate(null, null)[0];
        }
    }
}

