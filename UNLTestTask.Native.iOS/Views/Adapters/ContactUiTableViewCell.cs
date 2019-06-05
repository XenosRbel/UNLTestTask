using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace UNLTestTask.Native.iOS.Views
{
	internal sealed class ContactUiTableViewCell : UITableViewCell
	{
		public ContactUiTableViewCell()
		{
			BackgroundView = new UIView
			{
				BackgroundColor = UIColor.Orange
			};

			SelectedBackgroundView = new UIView
			{
				BackgroundColor = UIColor.Green
			};

			ContentView.BackgroundColor = UIColor.White;

			Name = new UILabel();
			Phone = new UILabel();

			Photo = new UIImageView();

			ContentView.AddSubviews(Photo, Name, Phone);

			const int imageSize = 25;
			ContentView.AddConstraints(
				Photo.AtTopOf(ContentView),
				Photo.AtLeadingOf(ContentView),
				Photo.Width().EqualTo(imageSize),
				Photo.Height().EqualTo(imageSize),

				Name.AtTopOf(ContentView),
				Name.ToTrailingOf(Photo),
				Name.AtTrailingOf(ContentView),

				Phone.Below(Name),
				Phone.ToTrailingOf(Photo),
				Phone.AtTrailingOf(ContentView));

			ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
		}

		public UILabel Name { get; }

		public UILabel Phone { get; }

		public UIImageView Photo { get; }
	}
}