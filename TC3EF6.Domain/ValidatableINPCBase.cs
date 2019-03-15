using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Domain
{
    public class ValidatableINPCBase : INPCBase, INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };
        private Dictionary<string, List<string>> mErrors = new Dictionary<string, List<string>>();
        public bool HasErrors { get => mErrors.Count > 0; }
        public IEnumerable GetErrors(string propertyName)
        {
            if (mErrors.ContainsKey(propertyName)) return mErrors[propertyName];
            return null;
        }
        protected override void SetProperty<T>(ref T member, T value, [CallerMemberName] String propertyName = null)
        {
            base.SetProperty<T>(ref member, value, propertyName);
            ValidateProperty(propertyName, value);
        }
        private void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this) { MemberName = propertyName };
            Validator.TryValidateProperty(value, context, results);
            if (results.Any())
                mErrors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            else
                mErrors.Remove(propertyName);
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
