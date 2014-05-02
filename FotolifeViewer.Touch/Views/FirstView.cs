using System.Collections.Generic;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FotolifeViewer.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new TableViewSource(TableView);
            this.AddBindings( new Dictionary<object, string> {
                { TableView.Source, "ItemsSource Items" }
            });
        }

        public class TableViewSource : MvxTableViewSource 
        {
            public TableViewSource(UITableView tableView) : base(tableView) 
            {
                TableView.RegisterNibForCellReuse(FotolifeCell.Nib, FotolifeCell.Key);
            }

            public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return FotolifeCell.CellHeight;
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
            {
                return tableView.DequeueReusableCell(FotolifeCell.Key);
            }
        }
    }
}