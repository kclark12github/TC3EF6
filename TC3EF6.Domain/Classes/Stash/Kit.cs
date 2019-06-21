using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Kits"), TableDescription("Collection of Model Kits.")]
    public partial class Kit : KitBase
    {
        #region "Locals"
        private Decal mDecal = null;
        private DetailSet mDetailSet = null;
        private string mCondition = string.Empty;
        private string mEra = string.Empty;
        private bool mOutOfProduction = false;
        private string mService = string.Empty;
        #endregion
        [DataMember, ColumnDescription("Specific Decal included with or used by this Model Kit.")]
        public virtual Decal Decal
        {
            get => mDecal;
            set { SetProperty(ref mDecal, value); }
        }

        [DataMember, ColumnDescription("Specific Detail Set included with or used by this Model Kit.")]
        public virtual DetailSet DetailSet
        {
            get => mDetailSet;
            set { SetProperty(ref mDetailSet, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Condition of the Model Kit (i.e. Built, Opened, etc.).")]
        public string Condition
        {
            get => mCondition;
            set { SetProperty(ref mCondition, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Era the prototype of the Model Kit served (i.e. WWII, Vietnam, etc.).")]
        public string Era
        {
            get => mEra;
            set { SetProperty(ref mEra, value); }
        }

        [DataMember, ColumnDescription("Is the item out-of-production?")]
        public bool OutOfProduction
        {
            get => mOutOfProduction;
            set { SetProperty(ref mOutOfProduction, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Service the prototype of the Model Kit served (i.e. USN, USMC, USAAF, etc.).")]
        public string Service
        {
            get => mService;
            set { SetProperty(ref mService, value); }
        }
    }
}
