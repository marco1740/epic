// Copyright Epic Games, Inc. All Rights Reserved.

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Epic.OnlineServices.Samples.ViewModels
{
	public abstract class Bindable : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value))
			{
				return false;
			}

			storage = value;
			NotifyPropertyChanged(propertyName);

			return true;
		}
	}
}
