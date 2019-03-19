using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;
using TC3EF6.Domain.Interfaces;

namespace TC3EF6.Domain
{
    [DataContract]
    public abstract class EntityBase : ValidatableINPCBase, IEntity, IDisposable
    {
        #region "Locals"
        private byte[] mRowID = null;
        private Guid mID;
        #endregion

        [Key]
        [DataMember]
        [ColumnDescription("Unique system-generated identifier.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID
        {
            get => mID;
            set { SetProperty(ref mID, value); }
        }

        [DataMember]
        [ColumnDescription("System-managed concurrency control field.")]
        [ConcurrencyCheck]
        [Timestamp]
        public Byte[] RowID
        {
            get => mRowID;
            set { SetProperty(ref mRowID, value); }
        }

        #region "Validation Properties/Methods"
        private ValidationRuleMessages mValidationRuleMessages = new ValidationRuleMessages();

        public ValidationRuleMessages ValidationRuleMessages
        {
            get { return mValidationRuleMessages; }
        }
        public void AddValidationRuleMessage(string PropertyName, string Message)
        {
            mValidationRuleMessages.Add(new ValidationRuleMessage(PropertyName, Message));
        }
        public virtual bool Validate()
        {
            return true;
        }
        public void ClearValidationMessages()
        {
            mValidationRuleMessages.Clear();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EntityBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }
}
