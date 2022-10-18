using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Collections.Specialized;

namespace tubig
{
   public  class BindMape:Map
    {
		public static readonly BindableProperty MapPinsProperty = BindableProperty.Create(
			nameof(Pins),
			typeof(ObservableCollection<Pin>),
			typeof(BindMape),
			new ObservableCollection<Pin>(),
			propertyChanged: (b, o, n) =>
			{
				var bindable = (BindMape)b;
				bindable.Pins.Clear();

				var collection = (ObservableCollection<Pin>)n;
				foreach (var item in collection)
					bindable.Pins.Add(item);

				collection.CollectionChanged += (sender, e) =>
				{
					Device.BeginInvokeOnMainThread(() =>
					{
						switch (e.Action)
						{
							case NotifyCollectionChangedAction.Add:
							case NotifyCollectionChangedAction.Replace:
							case NotifyCollectionChangedAction.Remove:
								if (e.OldItems != null)
									foreach (var item in e.OldItems)
										bindable.Pins.Remove((Pin)item);

								if (e.NewItems != null)
									foreach (var item in e.NewItems)
										bindable.Pins.Add((Pin)item);
								break;
							case NotifyCollectionChangedAction.Reset:
								bindable.Pins.Clear();
								break;
						}
					});
				};



			});
		public IList<Pin> MapPins { get; set; }

		public static readonly BindableProperty MapPositionProperty = BindableProperty.Create(
				 nameof(MapPosition),
				 typeof(Position),
				 typeof(BindMape),
				 new Position(0, 0),
				 propertyChanged: (b, o, n) =>
				 {
					 ((BindMape)b).MoveToRegion(MapSpan.FromCenterAndRadius(
								 (Position)n, Distance.FromMiles(1)));

				 });
		public Position MapPosition { get; set; }
	}
}
