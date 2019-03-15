using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [TableDescription("Collection of Model Kits.")]
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
        [ColumnDescription("Specific Decal included with or used by this Model Kit.")]
        public virtual Decal Decal
        {
            get => mDecal;
            set { SetProperty(ref mDecal, value); }
        }

        [ColumnDescription("Specific Detail Set included with or used by this Model Kit.")]
        public virtual DetailSet DetailSet
        {
            get => mDetailSet;
            set { SetProperty(ref mDetailSet, value); }
        }

        [ColumnDescription("Condition of the Model Kit (i.e. Built, Opened, etc.).")]
        [StringLength(132)]
        public string Condition
        {
            get => mCondition;
            set { SetProperty(ref mCondition, value); }
        }

        [ColumnDescription("Era the prototype of the Model Kit served (i.e. WWII, Vietnam, etc.).")]
        [StringLength(80)]
        public string Era
        {
            get => mEra;
            set { SetProperty(ref mEra, value); }
        }

        [ColumnDescription("Is the item out-of-production?")]
        public bool OutOfProduction
        {
            get => mOutOfProduction;
            set { SetProperty(ref mOutOfProduction, value); }
        }

        [ColumnDescription("Service the prototype of the Model Kit served (i.e. USN, USMC, USAAF, etc.).")]
        [StringLength(132)]
        public string Service
        {
            get => mService;
            set { SetProperty(ref mService, value); }
        }
    }
}
