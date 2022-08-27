using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMExtension.Xamarin
{
    public class ValuePropertyChangedEventArgs : PropertyChangedEventArgs
    {
        public ValuePropertyChangedEventArgs(string PropertyName, object OldValue, object NewValue) : base(PropertyName)
        {
            _oldValue = OldValue;
            _newValue = NewValue;
        }

        private object _oldValue = null;
        public object OldValue 
        {
            get => _oldValue;
        }

        private object _newValue = null;
        public object NewValue 
        {
            get => _newValue;
        }
    }
}
