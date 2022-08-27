using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace HMExtension.Xamarin
{
    public class ValuePropertyChangingEventArgs : PropertyChangingEventArgs
    {
        public ValuePropertyChangingEventArgs(string PropertyName, object OldValue, object NewValue) : base(PropertyName)
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

        public bool IsCancel { get; set; } = false;
    }
}
