using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using HMExtension.Xamarin.Component;

namespace HMExtension.Xamarin.Mvvm
{
    public abstract class ViewModelPrimary : NotifyDataErrorInfo, INotifyPropertyChanged, INotifyPropertyChanging
    {
        public abstract event PropertyChangedEventHandler PropertyChanged;
        public abstract event PropertyChangingEventHandler PropertyChanging;

        public delegate void ValuePropertyChangedEventHandler(object Sender, ValuePropertyChangedEventArgs e);
        public delegate void ValuePropertyChangingEventHandler(object Sender, ref ValuePropertyChangingEventArgs e);

        public abstract event ValuePropertyChangedEventHandler ValuePropertyChanged;
        public abstract event ValuePropertyChangingEventHandler ValuePropertyChanging;

        protected abstract void OnPropertyChanged([CallerMemberName] string PropertyName = "");
        protected abstract void OnPropertyChanging([CallerMemberName] string PropertyName = "");
        protected abstract void OnValuePropertyChanged([CallerMemberName] string PropertyName = "", object OldValue = null, object NewValue = null);
        protected abstract bool OnValuePropertyChanging([CallerMemberName] string PropertyName = "", object OldValue = null, object NewValue = null);
    }
}
