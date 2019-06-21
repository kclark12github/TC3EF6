using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Reference
{
    [DataContract]
    public abstract class ShipClassBase : ImageEntityBase
    {
        #region "Locals"
        private string mAircraft = string.Empty;
        private string mASWWeapons = string.Empty;
        private string mBeam = string.Empty;
        private string mBoilers = string.Empty;
        private string mDescription = string.Empty;
        private string mDisplacement = string.Empty;
        private string mDraft = string.Empty;
        private string mEW = string.Empty;
        private string mFireControl = string.Empty;
        private string mGuns = string.Empty;
        private string mLength = string.Empty;
        private string mManning = string.Empty;
        private string mMissiles = string.Empty;
        private string mName = string.Empty;
        private string mNotes = string.Empty;
        private string mPropulsion = string.Empty;
        private string mRadars = string.Empty;
        private string mSpeed = string.Empty;
        private string mSonars = string.Empty;
        #endregion

        [DataMember, ColumnDescription("Aircraft typically deployed with this Ship/Class.")]
        public string Aircraft
        {
            get => mAircraft;
            set { SetProperty(ref mAircraft, value); }
        }

        [ColumnDescription("Anti-Submarine-Warfare (ASW) weapon capability of this Ship/Class.")]
        public string ASWWeapons
        {
            get => mASWWeapons;
            set { SetProperty(ref mASWWeapons, value); }
        }

        [DataMember, ColumnDescription("Beam (width) of this Ship/Class.")]
        public string Beam
        {
            get => mBeam;
            set { SetProperty(ref mBeam, value); }
        }

        [DataMember, ColumnDescription("Boilers typically outfitted for this Ship/Class.")]
        public string Boilers
        {
            get => mBoilers;
            set { SetProperty(ref mBoilers, value); }
        }

        //[DataMember, ColumnDescription("Classification of this Ship / Class.")]
        //public virtual ShipClassType ShipClassType { get; set; }

        [DataMember, ColumnDescription("General Description of this Ship/Class.")]
        public string Description
        {
            get => mDescription;
            set { SetProperty(ref mDescription, value); }
        }

        [DataMember, ColumnDescription("Displacement of this Ship/Class.")]
        public string Displacement
        {
            get => mDisplacement;
            set { SetProperty(ref mDisplacement, value); }
        }

        [DataMember, ColumnDescription("Draft of this Ship/Class.")]
        public string Draft
        {
            get => mDraft;
            set { SetProperty(ref mDraft, value); }
        }

        [DataMember, ColumnDescription("Electronic Warfare (EW) capability of this Ship/Class.")]
        public string EW
        {
            get => mEW;
            set { SetProperty(ref mEW, value); }
        }

        [DataMember, ColumnDescription("FireControl capability of this Ship/Class.")]
        public string FireControl
        {
            get => mFireControl;
            set { SetProperty(ref mFireControl, value); }
        }

        [DataMember, ColumnDescription("Gun armament of this Ship/Class.")]
        public string Guns
        {
            get => mGuns;
            set { SetProperty(ref mGuns, value); }
        }

        [DataMember, ColumnDescription("Length of this Ship/Class.")]
        public string Length
        {
            get => mLength;
            set { SetProperty(ref mLength, value); }
        }

        [DataMember, ColumnDescription("Crew compliment of this Ship/Class.")]
        public string Manning
        {
            get => mManning;
            set { SetProperty(ref mManning, value); }
        }

        [DataMember, ColumnDescription("Missile armament of this Ship/Class.")]
        public string Missiles
        {
            get => mMissiles;
            set { SetProperty(ref mMissiles, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Name of this Ship/Class.")]
        public string Name
        {
            get => mName;
            set { SetProperty(ref mName, value); }
        }

        [DataMember, ColumnDescription("Miscellaneous Notes.")]
        public string Notes
        {
            get => mNotes;
            set { SetProperty(ref mNotes, value); }
        }

        [DataMember, ColumnDescription("Propulsion system of this Ship/Class.")]
        public string Propulsion
        {
            get => mPropulsion;
            set { SetProperty(ref mPropulsion, value); }
        }

        [DataMember, ColumnDescription("RADAR capability of this Ship/Class.")]
        public string Radars
        {
            get => mRadars;
            set { SetProperty(ref mRadars, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Speed of this Ship/Class.")]
        public string Speed
        {
            get => mSpeed;
            set { SetProperty(ref mSpeed, value); }
        }

        [DataMember, ColumnDescription("SONAR capability of this Ship/Class.")]
        public string Sonars
        {
            get => mSonars;
            set { SetProperty(ref mSonars, value); }
        }
    }
}
