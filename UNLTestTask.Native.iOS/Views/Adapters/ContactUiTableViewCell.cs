using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using UIKit;

namespace UNLTestTask.Native.iOS.Views
{
	internal sealed class ContactUiTableViewCell : UITableViewCell
	{
		private UILabel _nameLabel;
		private UILabel _phoneLabel;
		private UIImageView _photoView;

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

			_nameLabel = new UILabel();
			_phoneLabel = new UILabel();

			_photoView = new UIImageView();

			ContentView.AddSubviews(_photoView, _nameLabel, _phoneLabel);

			const int imageSize = 25;
			ContentView.AddConstraints(
				_photoView.AtTopOf(ContentView),
				_photoView.AtLeadingOf(ContentView),
				_photoView.Width().EqualTo(imageSize),
				_photoView.Height().EqualTo(imageSize),

				_nameLabel.AtTopOf(ContentView),
				_nameLabel.ToTrailingOf(_photoView),
				_nameLabel.AtTrailingOf(ContentView),

				_phoneLabel.Below(_nameLabel),
				_phoneLabel.ToTrailingOf(_photoView),
				_phoneLabel.AtTrailingOf(ContentView));

			ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
		}

		public UILabel Name
		{
			get => _nameLabel;
			set => _nameLabel = value;
		}

		public UILabel Phone
		{
			get => _phoneLabel;
			set => _phoneLabel = value;
		}

		public UIImageView Photo
		{
			get => _photoView;
			set => _photoView = value;
		}
	}
}