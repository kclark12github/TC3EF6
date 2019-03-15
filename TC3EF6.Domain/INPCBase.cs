using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TC3EF6.Domain
{
    public class INPCBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(member, value)) return;
            member = value;
            OnPropertyChanged(propertyName);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
