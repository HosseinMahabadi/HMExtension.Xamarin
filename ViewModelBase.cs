using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using HMExtension.Xamarin;
using System.Windows.Input;
using System.Diagnostics;
using System.Reflection;

namespace HMExtension.Xamarin
{
    public abstract class ViewModelBase : ViewModelPrimary, IDisposable
    { 
        public ViewModelBase()
        {
            Application.Current.RequestedThemeChanged += (_, __) =>
            {
                OnThemeChanged();
            };
        }

        ~ViewModelBase()
        {
            Dispose();
        }

        private List<string> propertyNames = new List<string>();

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
        /// <returns>True: if property set; False: if property not set</returns>
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            HandleCommandsAttribute(this, PropertyName);
        }

        private void HandleCommandsAttribute(object sender, string propertyName)
        {
            Type type = sender.GetType();
            var properties = type.GetProperties().ToList().Where(p => typeof(ICommand).IsAssignableFrom(p.PropertyType));
            //Debug.WriteLine($"Count of ICommands for {sender} = {properties.Count()}");
            foreach (var property in properties)
            {
                var attribute = Attribute.GetCustomAttribute(property, typeof(CanExecuteRelatedToPropertyAttribute)) as CanExecuteRelatedToPropertyAttribute;
                if (attribute != null)
                {
                    if (attribute.PropertyName != null && propertyName != attribute.PropertyName)
                    {
                        return;
                    }
                    
                    if(attribute.PropertyNames != null && !attribute.PropertyNames.Contains(propertyName))
                    {
                        return;
                    }

                    try
                    {
                        if (property.PropertyType == typeof(Command))
                        {
                            Command command = property.GetValue(sender) as Command;
                            command.ChangeCanExecute();
                        }
                        else if (property.PropertyType == typeof(RelayCommand))
                        {
                            RelayCommand relayCommand = property.GetValue(sender) as RelayCommand;
                            relayCommand.ChangeCanExecute();
                        }
                    }
                    catch
                    {
                        Debug.WriteLine($"CanExecuteRelatedToPropertyAttribute does not supprot this type => {property.PropertyType}");
                    }
                }
            }
        }

        /// <summary>
        /// Call this method when your property has changed in your view model
        /// </summary>
        /// <param name="PropertyName">Your property name; no need when called in property block</param>
        /// <param name="OldValue">Old value of property</param>
        /// <param name="NewValue">New value of property </param>
        private void OnValuePropertyChanged([CallerMemberName] string PropertyName = "", object OldValue = null, object NewValue = null)
        {
            var e = new ValuePropertyChangedEventArgs(PropertyName, OldValue, NewValue);
            ValuePropertyChanged?.Invoke(this, e);
        }

        protected override void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            PropertyChanging?.Invoke(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
        }

        private bool OnValuePropertyChanging([CallerMemberName] string propertyName = null, object oldValue = null, object newValue = null)
        {
            var changed = ValuePropertyChanging;
            if(changed != null)
            {
                var e = new ValuePropertyChangingEventArgs(propertyName, oldValue, newValue);
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
        public T GetBasedOnTheme<T>(T Dark, T Light, [CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (!propertyNames.Contains(propertyName))
                {
                    propertyNames.Add(propertyName);
                }
            }

            return Application.Current.RequestedTheme == OSAppTheme.Dark ? Dark : Light;
        }

        /// <summary>
        /// Override this method for handling application theme changes in your view model
        /// </summary>
        protected virtual void OnThemeChanged()
        {
            foreach(var property in propertyNames)
            {
                OnPropertyChanged(property);
            }
        }

        /// <summary>
        /// Override this method for disposing view model
        /// </summary>
        public virtual void Dispose()
        {
            propertyNames = null;
        }
    }
}
