using System;
using System.Collections.ObjectModel;
using Foundation;
using UIKit;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Native.iOS.Views
{
	public class TableSource : UITableViewSource
	{
		private readonly ObservableCollection<IContactViewModel> _collection;
		public const string CellIdentifier = "SampleID";

		public TableSource(ObservableCollection<IContactViewModel> collection)
		{
			_collection = collection;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _collection.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (ContactUiTableViewCell)tableView.DequeueReusableCell(CellIdentifier) ?? new ContactUiTableViewCell();

			var item = _collection[indexPath.Row];
			cell.Name.Text = item.Contact.Name;
			cell.Phone.Text = item.Contact.PhoneNumber;
			cell.Photo.Image = UIImage.FromBundle(item.Contact.PhoneType == ContactType.None ? "tom.png" : "jerry.png");
			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var item = _collection[indexPath.Row];

			UIAlertView alert = new UIAlertView("Selected Item", item.Contact.Name, null, "OK");
			alert.Show();
		}
	}
}