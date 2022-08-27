using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HMExtension.Xamarin
{
    public abstract class NotifyDataErrorInfo : INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private object _lock = new object();
        public bool HasErrors
        {
            get => _errors.Any(propErrors => propErrors.Value != null && propErrors.Value.Count > 0);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                return _errors.ContainsKey(propertyName) && (_errors[propertyName] != null) && _errors[propertyName].Count > 0
                    ? _errors[propertyName].ToList()
                    : null;
            }
            else
            {
                return _errors.SelectMany(err => err.Value.ToList());
            }
        }

        public string GetErrorMessage(string PropertyName)
        {
            if (_errors.ContainsKey(PropertyName) &&
                (_errors[PropertyName] != null) &&
                _errors[PropertyName].Count > 0)
            {
                var errors = GetErrors(PropertyName) as List<string>;
                if (errors.Count > 0)
                {
                    return errors[0].ToString();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                validationContext.MemberName = propertyName;
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateProperty(value, validationContext, validationResults);

                //clear previous _errors from tested property  
                if (_errors.ContainsKey(propertyName))
                    _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
                HandleValidationResults(validationResults);
            }
        }

        public void Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                //clear all previous _errors  
                var propNames = _errors.Keys.ToList();
                _errors.Clear();
                propNames.ForEach(pn => OnErrorsChanged(pn));
                HandleValidationResults(validationResults);
            }
        }

        private void HandleValidationResults(List<ValidationResult> validationResults)
        {
            //Group validation results by property names  
            var resultsByPropNames = from res in validationResults
                                     from mname in res.MemberNames
                                     group res by mname into g
                                     select g;
            //add _errors to dictionary and inform binding engine about _errors  
            foreach (var prop in resultsByPropNames)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();
                _errors.Add(prop.Key, messages);
                OnErrorsChanged(prop.Key);
            }
        }

        public string GetAllErrorsString()
        {
            Validate();
            var propNames = _errors.Keys.ToList();
            string Answer = null;
            foreach(var key in propNames)
            {
                foreach(var error in _errors[key])
                {
                    Answer += $"{error}{Environment.NewLine}"; 
                }
            }
            return Answer;
        }
    }
}
