using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using HMExtension.Xamarin.Component;

namespace HMExtension.Xamarin.Mvvm
{
    public abstract class ViewModelBase : ViewModelPrimary
    { 
        public ViewModelBase()
        {
            Application.Current.RequestedThemeChanged += (_, __) =>
            {
                OnThemeChanged();
            };
        }

        public override event PropertyChangedEventHandler PropertyChanged;
        public override event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public override event ValuePropertyChangedEventHandler ValuePropertyChanged;
        public override event ValuePropertyChangingEventHandler ValuePropertyChanging;

        /// <summary>
        /// Sets new property value
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="BackingStore">The parivate identifire that holds property value</param>
        /// <param name="Value">New value to set</param>
        /// <param name="PropertyName">Property to set</param>
        /// <param name="OnChanged">This method fires after the new value set</param>
        /// <returns>True: if prorty set; False: if property not set</returns>
        public bool SetProperty<T>(ref T BackingStore, T Value,
            [CallerMemberName] string PropertyName = "",
            Action OnChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(BackingStore, Value))
            {
                return false;
            }
            else
            {
                OnPropertyChanging(PropertyName);
                bool IsCancel = OnValuePropertyChanging(PropertyName, BackingStore, Value);
                if (IsCancel)
                {
                    return false;
                }
                var temp = BackingStore;
                BackingStore = Value;
                OnPropertyChanged(PropertyName);
                OnErrorsChanged(PropertyName);
                OnValuePropertyChanged(PropertyName, temp, Value);
                OnChanged?.Invoke();
                return true;
            }
        }

        /// <summary>
        /// Call this method when your property has changed in your view model
        /// </summary>
        /// <param name="PropertyName">Your property name; no need when called in property block</param>
        protected override void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                changed.Invoke(this, new ValuePropertyChangedEventArgs(PropertyName, null, null));
            }
        }

        /// <summary>
        /// Call this method when your property has changed in your view model
        /// </summary>
        /// <param name="PropertyName">Your property name; no need when called in property block</param>
        /// <param name="OldValue">Old value of property</param>
        /// <param name="NewValue">New value of property </param>
        protected override void OnValuePropertyChanged([CallerMemberName] string PropertyName = "", object OldValue = null, object NewValue = null)
        {
            var changed = ValuePropertyChanged;
            if (changed != null)
            {
                var e = new ValuePropertyChangedEventArgs(PropertyName, OldValue, NewValue);
                changed.Invoke(this, e);
            }
        }

        /*protected void NotifyPropertyChanged<T>(T Sender, [CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(Sender, new PropertyChangedEventArgs(propertyName));
        }*/

        protected override void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            var changing = PropertyChanging;
            if (changing != null)
            {
                changing.Invoke(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }

        protected override bool OnValuePropertyChanging([CallerMemberName] string PropertyName = "", object OldValue = null, object NewValue = null)
        {
            var changed = ValuePropertyChanging;
            if(changed != null)
            {
                var e = new ValuePropertyChangingEventArgs(PropertyName, OldValue, NewValue);
                changed.Invoke(this, ref e);
                return e.IsCancel;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the right value by current application theme
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="Dark">Dark theme value to return</param>
        /// <param name="Light">Light theme value to return</param>
        /// <returns></returns>
        public T GetBasedOnTheme<T>(T Dark, T Light)
        {
            return Application.Current.RequestedTheme == OSAppTheme.Dark ? Dark : Light;
        }

        /// <summary>
        /// Override this method for handling application theme changes in your view model
        /// </summary>
        protected virtual void OnThemeChanged() { }
    }
}
