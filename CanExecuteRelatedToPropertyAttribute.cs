using System;
using System.Collections.Generic;
using System.Text;

namespace HMExtension.Xamarin
{
    /// <summary>
    /// Check if a command can execute on view model when a property changed
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class CanExecuteRelatedToPropertyAttribute : Attribute
    {
        /// <summary>
        /// Check cammand execution for all property changed
        /// </summary>
        public CanExecuteRelatedToPropertyAttribute()
        {
            _propertyName = null;
            _propertyNames = null;
        }

        /// <summary>
        /// Check command can execute for specific property changed
        /// </summary>
        /// <param name="propertyName">property name to check on property changed</param>
        public CanExecuteRelatedToPropertyAttribute(string propertyName)
        {
            _propertyName = propertyName;
            _propertyNames = null;
        }

        /// <summary>
        /// Check command can execute for specific list of property changed
        /// </summary>
        /// <param name="propertyNames">property names to check on property changed</param>
        public CanExecuteRelatedToPropertyAttribute(List<string> propertyNames)
        {
            _propertyName = null;
            _propertyNames = propertyNames;
        }

        private string _propertyName = null;
        public virtual string PropertyName
        {
            get => _propertyName;
        }

        private List<string> _propertyNames = null;
        public virtual List<string> PropertyNames
        {
            get => _propertyNames;
        }
    }
}

