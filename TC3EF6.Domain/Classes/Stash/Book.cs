using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TC3EF6.Base;
using TC3EF6.Domain.Annotations;

namespace TC3EF6.Domain.Classes.Stash
{
    [DataContract, Table("Books"), TableDescription("Library of Books, Magazines, and electronic media.")]
    public class Book : StashBase   //, IEditableObject
    {
        #region "Properties"
        const int MaxAlphaSortLength = 132;
        #region "Locals"
        private string mAlphaSort = string.Empty;
        private string mAuthor = string.Empty;
        private string mMediaFormat = string.Empty;
        private string mISBN = string.Empty;
        private string mMisc = string.Empty;
        private string mSubject = string.Empty;
        private string mTitle = string.Empty;

        private List<string> mDefaultAlphaSorts = new List<string>() { };
        #endregion

        [DataMember, Required, StringLength(MaxAlphaSortLength), ColumnDescription("Sort string."),
            MinLength(1)]
        public string AlphaSort
        {
            get => mAlphaSort;
            set { SetProperty(ref mAlphaSort, value); }
        }

        [DataMember, Required, StringLength(80), ColumnDescription("Author of the publication."),
            MinLength(1)]
        public string Author
        {
            get => mAuthor;
            set { SetProperty(ref mAuthor, value); }
        }

        [DataMember, StringLength(80), ColumnDescription("Media/Format of the publication (i.e. Hardcover, Paperback, etc)."),
            MinLength(1),
            SqlDefaultValue(DefaultValue = "'Unspecified'")]
        public string MediaFormat
        {
            get => mMediaFormat;
            set { SetProperty(ref mMediaFormat, value); }
        }

        [DataMember, StringLength(24), ColumnDescription("International Standard Book Number.")]
        public string ISBN
        {
            get => mISBN;
            set { SetProperty(ref mISBN, value); }
        }

        [DataMember, StringLength(132), ColumnDescription("Miscellaneous information.")]
        public string Misc
        {
            get => mMisc;
            set { SetProperty(ref mMisc, value); }
        }

        [DataMember, Required, StringLength(80), ColumnDescription("Subject of the publication."),
            MinLength(1)]
        public string Subject
        {
            get => mSubject;
            set { SetProperty(ref mSubject, value); }
        }

        [DataMember, Required, StringLength(132), ColumnDescription("Title of the publication."),
            MinLength(1)]
        public string Title
        {
            get => mTitle;
            set { SetProperty(ref mTitle, value); }
        }

        [DataMember, NotMapped]
        public List<string> DefaultAlphaSorts
        {
            get => mDefaultAlphaSorts;
            set { SetProperty(ref mDefaultAlphaSorts, value); }
        }
        #endregion

        #region "Methods"
        #region "IEditableObject Support"
        //TODO: Fingure out how best to implement IEditableObject interface across all POCOs...
        public void BeginEdit()
        {
            throw new NotImplementedException();
        }
        public void CancelEdit()
        {
            throw new NotImplementedException();
        }
        public void EndEdit()
        {
            throw new NotImplementedException();
        }
        #endregion
        private List<string> AlphasortByISBN(string ISBN, string LastName, string Title)
        {
            List<string> Values = new List<string>() { };
            int CountryCode = Convert.ToInt32(ISBN.Parse(1, "-"));
            //If we begin to get dups on PublisherCode, we'll have to start using the CountryCode, but not until then...
            int PublisherCode = Convert.ToInt32(ISBN.Parse(2, "-"));
            //PublisherCode
            switch (PublisherCode)
            {
                case 880588:
                case 874023:
                case 86184:
                    //CountryCode: 1
                    Values.Add(FixAlphasort(string.Format("AIRTIME: {0}", Title)));
                    break;
                case 361:
                    //CountryCode: 962
                    Values.Add(FixAlphasort(string.Format("CONCORD: <SeriesName> #nnnn; {0}", Title)));
                    break;
                case 7603:
                case 87398:
                case 85045:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("MOTORBOOKS: {0}: {1}", LastName, Title)));
                    break;
                case 914845:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("MSPRESS: {0}: {1}", LastName, Title)));
                    break;
                case 57231:
                case 55615:
                    //CountryCode: 1
                    Values.Add(FixAlphasort(string.Format("MSPRESS: {0}: {1}", LastName, Title)));
                    break;
                case 896522:
                    //CountryCode: 1
                    Values.Add(FixAlphasort(string.Format("NASA MISSION REPORTS:{0}", Title)));
                    break;
                case 87938:
                case 89141:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("OSPREY: {0}", Title)));
                    break;
                case 85532:
                case 84176:
                    //CountryCode: 1
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("OSPREY: AIRCRAFT OF THE ACES #nn; {0}", Title)),
                        FixAlphasort(string.Format("OSPREY: CLASSIC BATTLES; {0}", Title)),
                        FixAlphasort(string.Format("OSPREY: COMBAT AIRCRAFT #nn; {0}", Title)),
                        FixAlphasort(string.Format("OSPREY: NEW VANGUARD #nn; {0}", Title)),
                        FixAlphasort(string.Format("OSPREY: <SeriesName> #nn; {0}", Title))
                    });
                    break;
                case 672:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("SAMS: {0}", Title)));
                    break;
                case 944055:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("SCALE MODELING: FLOATING DRYDOCK: {0}", Title)));
                    break;
                case 89024:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("SCALE MODELING: KALMBACH: {0}", Title)));
                    break;
                case 7643:
                case 88740:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("SCHIFFER MILITARY HISTORY: {0}: {1}", LastName, Title)));
                    break;
                case 8094:
                case 670:
                case 939526:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("TIMELIFE: <SeriesName>: BOOK ##; {0}", Title)));
                    break;
                case 85488:
                    //CountryCode: 1
                    Values.Add(FixAlphasort(string.Format("TRISERVICE: {0}", Title)));
                    break;
                case 935696:
                case 88038:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("TSR: #### {0}", Title)));
                    break;
                case 89747:
                    //CountryCode: 0
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: AIRCRAFT MINI NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: AIRCRAFT NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: ARMOR NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: C&M NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: COMBAT TROOPS NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: D&S NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: FIGHTING COLORS NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: MODERN MILITARY AIRCRAFT NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: ON DECK NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: SPECIALS NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: WALK AROUND (ARMOR) NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: WALK AROUND NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: WARSHIPS NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("SQUADRON/SIGNAL: <SeriesName> NO. ##; {0}", Title))
                    });
                    break;
                case 87021:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("USNI: {0}", Title)));
                    break;
                case 55750:
                    //CountryCode: 1
                    Values.Add(FixAlphasort(string.Format("USNI: {0}", Title)));
                    break;
                case 930607:
                    //CountryCode: 1
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("VERLINDEN: LOCK ON NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("VERLINDEN: WARMACHINES NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("VERLINDEN: <SeriesName> NO. ##; {0}", Title))
                    });
                    break;
                case 70932:
                    //CountryCode: 90
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("VERLINDEN: LOCK ON NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("VERLINDEN: WARMACHINES NO. ##; {0}", Title)),
                        FixAlphasort(string.Format("VERLINDEN: <SeriesName> NO. ##; {0}", Title))
                    });
                    break;
                case 9654829:
                case 9710687:
                case 9745687:
                    //CountryCode: 0
                    Values.Add(FixAlphasort(string.Format("WARSHIP PICTORIAL SERIES #nn; {0}", Title)));
                    break;
                case 933126:
                case 929521:
                    //CountryCode: 0
                    Values.Add(FixAlphasort("WARSHIP SERIES #n; <ShipDesignation>; U.S.S. <ShipName>"));
                    break;
                case 57510:
                    //CountryCode: 1
                    Values.Add(FixAlphasort("WARSHIP'S DATA #n; <ShipDesignation>; U.S.S. <ShipName>"));
                    break;
                default:
                    Values.Add(FixAlphasort(string.Format("{0}: {1}", LastName, Title)));
                    break;
            }
            return Values;
        }
        public List<string> GetDefaultAlphaSorts()
        {
            List<string> Values = new List<string>() { string.Empty };
            Values.Add(this.AlphaSort);   //Handle existing entry...

            string lTitle = this.Title.ToUpper();
            string lAuthor = this.Author.ToUpper();
            string lISBN = this.ISBN.ToUpper();
            string lSubject = this.Subject.ToUpper();

            //Start with the Author's last name...
            string LastName = lAuthor;
            int iAnd = lAuthor.IndexOf(" AND ") + 1;
            int iAmpersand = lAuthor.IndexOf(" & ") + 1;
            int iComma = lAuthor.IndexOf(",") + 1;
            int iSemiColon = lAuthor.IndexOf(";") + 1;
            int iSeparator = 0;
            int iWith = lAuthor.IndexOf(" WITH ") + 1;

            if (iComma > 0)
            {
                //Assume the comma separates authors, and...
                iSeparator = iComma;
            }
            else if (iSemiColon > 0)
            {
                //Assume the semicolon separates authors, and...
                iSeparator = iSemiColon;
            }
            else if (iAnd > 0)
            {
                //Assume the "AND" separates authors, and...
                iSeparator = iAnd;
            }
            else if (iAmpersand > 0)
            {
                //Assume the "&" separates authors, and...
                iSeparator = iAmpersand;
            }
            else if (iWith > 0)
            {
                //Assume the "WITH" separates authors, and...
                iSeparator = iWith;
            }

            //...take the first Author...
            if (iSeparator > 0)
                LastName = LastName.Substring(0, iSeparator - 1).Trim();

            //OK, we have a single person's name (theoretically)...
            //Grab the last word on the line and assume it's his last name (unless it's "(Editor)", etc)...
            if (LastName.IndexOf(" ") >= 0)
            {
                if (LastName.EndsWith("(ED.)"))
                {
                    LastName = LastName.Substring(0, LastName.Length - "(ED.)".Length).Trim();
                }
                else if (LastName.EndsWith("(EDITOR)"))
                {
                    LastName = LastName.Substring(0, LastName.Length - "(EDITOR)".Length).Trim();
                }
                else if (LastName.EndsWith("(EDITORS)"))
                {
                    LastName = LastName.Substring(0, LastName.Length - "(EDITORS)".Length).Trim();
                }
                iSeparator = LastName.LastIndexOf(" ") + 1;
                LastName = LastName.Substring(iSeparator);
            }

            //Check for "The" at the beginning of the title...
            if (lTitle.StartsWith("THE ")) lTitle = lTitle.Substring("THE ".Length) + ", THE";
            if (lTitle.StartsWith("A ")) lTitle = lTitle.Substring("A ".Length) + ", A";
            if (lTitle.StartsWith("AN ")) lTitle = lTitle.Substring("AN ".Length) + ", AN";

            //Check ISBN to detect publishers of special series that we'd rather sort by series name than author(s)...
            if (!string.IsNullOrEmpty(lISBN.Trim()) && lISBN.Length >= 9 && lISBN.Replace("-", string.Empty).Replace(" ", string.Empty).IsAllDigits())
                Values.AddRange(AlphasortByISBN(lISBN, LastName, lTitle));
            switch (lSubject)
            {
                case "SCIENCE FICTION; STAR TREK":
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("STAR TREK: {0}: {1}", LastName, lTitle)),
                        FixAlphasort("STAR TREK: <Series>: BOOK ##")
                    });
                    break;
                case "SCIENCE FICTION; STAR WARS":
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("STAR WARS: {0}: {1}", LastName, lTitle)),
                        FixAlphasort("STAR WARS: <Series>: BOOK ##")
                    });
                    break;
                default:
                    Values.AddRange(new string[] {
                        FixAlphasort(string.Format("{0}: {1}",LastName, lTitle)),
                        FixAlphasort(string.Format("{0}: <Series>: BOOK ##", LastName)),
                        FixAlphasort(string.Format("{0}(##): {1}", LastName, lTitle))
                    });
                    break;
            }
            if (!Values.Contains(this.AlphaSort)) throw new ApplicationException("Current AlphaSort is missing from defaulted list!");
            this.DefaultAlphaSorts = Values.OrderBy(s => s).Distinct().ToList();
            return this.DefaultAlphaSorts;
        }
        private string FixAlphasort(string Value)
        {
            Value = Value.ToUpper();
            if (Value.Length <= MaxAlphaSortLength) return Value;
            if (Value.Tokens(":") <= 1 && Value.Tokens(";") <= 1) return Value.Substring(0, MaxAlphaSortLength);
            while (Value.Length > MaxAlphaSortLength)
            {
                Value = Value.Substring(0, Math.Max(Value.LastIndexOf(":"), Value.LastIndexOf(";")));
            }
            return Value;
        }
        public override bool Validate()
        {
            var rules = new List<Rule<Book>>()
            {
                new Rule<Book> { Test = b => !string.IsNullOrEmpty(b.Title),
                                     Property = "Title",
                                     Message= "Title may not be empty" },
                new Rule<Book> { Test = b => !string.IsNullOrEmpty(b.Author),
                                     Property = "Author",
                                     Message= "Author may not be empty" },
                new Rule<Book> { Test = b => !string.IsNullOrEmpty(b.Subject),
                                     Property = "Subject",
                                     Message= "Subject may not be empty" },
                new Rule<Book> { Test = b => !string.IsNullOrEmpty(b.MediaFormat),
                                     Property = "MediaFormat",
                                     Message= "MediaFormat may not be empty" },
                new Rule<Book> { Test = b => b.ID == null,
                                     Property = "ID",
                                     Message = "ID is required"}
            };
            bool isValid = rules.All(r => r.Test(this));
            if (!isValid)
            {
                ClearValidationMessages();
                var failedRules = rules.Where(r => r.Test(this) == false);
                foreach (var m in failedRules)
                {
                    AddValidationRuleMessage(m.Property, m.Message);
                }
                //string errorMessage =
                //            failedRules.Aggregate(new StringBuilder(),
                //                        (sb, r) => sb.AppendLine(r.Message),
                //                        sb => sb.ToString());
                //Debug.WriteLine(errorMessage);
            }
            return isValid;
        }
        #endregion
    }
}
