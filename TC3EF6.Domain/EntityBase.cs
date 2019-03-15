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
    public abstract class EntityBase : ValidatableINPCBase, IEntity
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
        #endregion
    }
}
