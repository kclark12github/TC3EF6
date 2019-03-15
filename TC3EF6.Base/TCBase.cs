#define UseFileInfo
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TC3EF6.Base
{
    public class TCBase
    {
        #region "Properties"
        #region "Locals"
        private readonly TCBase mTCBase = null;
        private readonly Assembly mAssembly = null;
        private readonly string mApplicationPath = string.Empty;
        private readonly string mAppName = string.Empty;
        private readonly string mCompany = string.Empty;
        private readonly string mCopyright = string.Empty;
        private readonly string mDescription = string.Empty;
        private readonly string mProduct = string.Empty;
        private readonly string mTitle = string.Empty;
        private readonly string mTrademark = string.Empty;
        private readonly string mVersion = string.Empty;
        #endregion
        private Assembly Assembly { get => mAssembly; }
        public string ApplicationPath { get => mApplicationPath; }
        public string AppName { get => mAppName; }
        public string Company { get => mCompany; }
        public string Copyright { get => mCopyright; }
        public string Description { get => mDescription; }
        public string Product { get => mProduct; }
        public string Title { get => mTitle; }
        public string Trademark { get => mTrademark; }
        public string Version { get => mVersion; }
        #endregion
        public TCBase()
        {
            if (mTCBase != null) return;

            //Debug.WriteLine("initial TCBase.ID: {0}", mID);
            Assembly EntryAssembly = Assembly.GetEntryAssembly();
            Assembly CallingAssembly = Assembly.GetCallingAssembly();
            Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

            if (EntryAssembly != null)
                mAssembly = EntryAssembly;
            else if (CallingAssembly != null)
                mAssembly = CallingAssembly;
            else
                mAssembly = ExecutingAssembly;
            if (Assembly == null) return;

            mApplicationPath = GetApplicationPath(Assembly);
            mAppName = GetAppName(Assembly);
            mCompany = GetCompany(Assembly);
            mCopyright = GetCopyright(Assembly);
            mDescription = GetDescription(Assembly);
            mProduct = GetProduct(Assembly);
            mTitle = GetTitle(Assembly);
            mTrademark = GetTrademark(Assembly);
            mVersion = GetVersion(Assembly);
            mTCBase = this;
        }
        #region "Methods"
        #region "Assembly Stuff"
        private string GetApplicationPath(Assembly assembly)
        {
            string path = assembly.Location;
            //FileInfo: "URI formats are not supported."
            if (ParsePath(path, ParseParts.Protocol) == "file://") path = path.Substring("file:///".Length);
            return new FileInfo(path).DirectoryName;
        }
        private string GetAppName(Assembly assembly)
        {
            return assembly.GetName().Name;
        }
        private string GetCompany(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            AssemblyCompanyAttribute attr = (AssemblyCompanyAttribute)attributes[0];
            return attr.Company;
        }
        private string GetCopyright(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            AssemblyCopyrightAttribute attr = (AssemblyCopyrightAttribute)attributes[0];
            return attr.Copyright;
        }
        private string GetDescription(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            AssemblyDescriptionAttribute attr = (AssemblyDescriptionAttribute)attributes[0];
            return attr.Description;
        }
        private string GetProduct(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            AssemblyProductAttribute attr = (AssemblyProductAttribute)attributes[0];
            return attr.Product;
        }
        private string GetTitle(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            AssemblyTitleAttribute attr = (AssemblyTitleAttribute)attributes[0];
            return attr.Title;
        }
        private string GetTrademark(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
            AssemblyTrademarkAttribute attr = (AssemblyTrademarkAttribute)attributes[0];
            return attr.Trademark;
        }
        private string GetVersion(Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }
        #endregion
        #region "Obsolete String Stuff"
        /// <summary>Parses a given string by delimiter</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="Delimiter">Token delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "Delimiter" characters</param>
        /// <returns>Returns string array</returns>
        //public static string[] Parse(string Source, string Delimiter, string Encapsulator = "")
        //{
        //    char ctrlA = (char)1;
        //    string[] delim = new string[] { Delimiter };
        //    if (string.IsNullOrEmpty(Source))
        //        throw new ArgumentException("Work string must be specified.");
        //    if (string.IsNullOrEmpty(Delimiter))
        //        throw new ArgumentException("Delimiter must be specified.");
        //    if ((Encapsulator == null))
        //        Encapsulator = string.Empty;

        //    if (Delimiter.Length > 1 || (Encapsulator.Length > 0 && Source.IndexOf(Encapsulator) > -1))
        //    {
        //        //Strategy: Replace all occurrences of Delimiter (not encapsulated by Encapsulator) with a
        //        //          substitute delimiter which can be later used in a String.Split operation.
        //        int cntEncap = 0;
        //        delim = new string[] { ctrlA.ToString() };
        //        int sPos = 0;
        //        while (sPos < Source.Length)
        //        {
        //            if (sPos + Encapsulator.Length < Source.Length && Encapsulator.Length > 0 && Source.Substring(sPos, Encapsulator.Length) == Encapsulator) {
        //                cntEncap += 1;
        //                sPos += Encapsulator.Length;
        //            } else if (sPos + Delimiter.Length < Source.Length && Source.Substring(sPos, Delimiter.Length) == Delimiter && cntEncap % 2 == 0) {
        //                Source = string.Format("{0}{1}{2}", Source.Substring(0, sPos), delim[0], Source.Substring(sPos + Delimiter.Length));
        //                sPos += delim.Length;
        //            } else {
        //                sPos += 1;
        //            }
        //        }
        //    }
        //    return Source.Split(delim, StringSplitOptions.RemoveEmptyEntries);
        //}
        /// <summary>Retrieve specified token of string</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="TokenNum">Returns specified token in string</param>
        /// <param name="Delimiter">Token delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "Delimiter" characters</param>
        /// <param name="Preserve">Optional: Preserves encapsulating characters when token is encapsulated</param>
        /// <returns>Returns string token.  If none is found, will return ""</returns>
        //public string Parse(string Source, int TokenNum, string Delimiter, string Encapsulator = "", bool Preserve = false)
        //{
        //    string retval = string.Empty;
        //    if (TokenNum < 1)
        //        throw new ArgumentException("TokenNum must be greater than zero.");
        //    string[] Tokens = Source.Parse(Delimiter, Encapsulator);
        //    if (TokenNum <= Tokens.Length)
        //        retval = Tokens[TokenNum - 1];
        //    if (!Preserve && Encapsulator.Length > 0 && retval.StartsWith(Encapsulator) && retval.EndsWith(Encapsulator))
        //        retval = retval.Substring(1, retval.Length - 2);
        //    return retval;
        //}
        /// <summary>Counts number of tokens in a string</summary>
        /// <param name="Source">String to work on</param>
        /// <param name="Delimiter">String Delimiter</param>
        /// <param name="Encapsulator">Optional: Allows for tokens to return strings encapsulated with "strDelimiter" characters</param>
        /// <returns>Number of tokens found</returns>
        //public static int Tokens(string Source, string Delimiter, string Encapsulator = "")
        //{
        //    int retval = 0;
        //    if ((Source == null) || Source.Length == 0) return 0;
        //    if ((Delimiter == null) || Delimiter == string.Empty) return 0;
        //    if ((Encapsulator == null)) Encapsulator = string.Empty;

        //    string[] Tokens = Source.Parse(Delimiter, Encapsulator);
        //    retval = Tokens.Length;
        //    bool continueLoop = true;
        //    for (int i = Tokens.GetUpperBound(0); i >= 0 && continueLoop; i += -1)
        //    {
        //        if (Tokens[i].Length == 0)
        //            retval -= 1;
        //        else
        //            continueLoop = false;
        //    }
        //    return retval;
        //}
        #endregion
        #region "ParsePath Stuff"
        public enum ParseParts
        {
            DrvOnly = 1,
            DirOnly = 2,
            DirOnlyNoSlash = -2,
            DrvDir = 3,
            DrvDirNoSlash = -3,
            FileNameBase = 4,
            FileNameExt = 5,
            FileNameExtNoDot = -5,
            FileNameBaseExt = 6,
            DrvDirFileNameBase = 7,
            Protocol = 8,
            ServerOnly = 9,
            ServerShare = 10,
            ShareOnly = 11
        }
        public string ParsePath(string strPath, ParseParts intPart)
        {
            string functionReturnValue = null;
            functionReturnValue = string.Empty;
            if ((strPath == null)) strPath = string.Empty;
            if (strPath.Trim() == string.Empty) return functionReturnValue;
#if UseFileInfo
            FileInfo fi = null;
            string Protocol = string.Empty;
            string Drv = string.Empty;
            string ServerShare = string.Empty;
            string ServerOnly = string.Empty;
            string ShareOnly = string.Empty;
            bool WildCardFound = false;
            bool isPath = true;
            bool isUNC = false;
            //bool isURI = false;
            try {
                //First check for URI specification...
                if (strPath.ToLower().StartsWith("file://")) {
                    //isURI = true;
                    Protocol = "file://";
                    if (intPart == ParseParts.Protocol)
                        return Protocol;
                    //Path will be in any of the following formats:
                    //   file:///S:/FiRRe/... (note the extra "/" before the drive letter)...
                    //   file://\\WSRV08/SunGard/FiRRe/...
                    //   file://WWS004/SunGard/FiRRe/...
                    if (strPath.ToLower().StartsWith("file:///") && strPath.Substring(9, 1) == ":") {
                        strPath = strPath.Substring("file:///".Length).Replace("/", "\\");
                    } else if (strPath.ToLower().StartsWith("file://\\\\")) {
                        strPath = strPath.Substring("file://".Length).Replace("/", "\\");
                    } else if (strPath.ToLower().StartsWith("file://") && strPath.IndexOf(":", "file://".Length) == -1) {
                        strPath = strPath.Substring("file:".Length).Replace("/", "\\");
                    } else {
                        throw new NotSupportedException(string.Format("FILE protocol pattern ({0}) not recognized by ParsePath", strPath));
                    }
                } else if (strPath.ToLower().StartsWith("http://")) {
                    //isURI = true;
                    throw new NotSupportedException(string.Format("HTTP protocol pattern ({0}) not supported by ParsePath", strPath));
                } else if (strPath.ToLower().StartsWith("https://")) {
                    //isURI = true;
                    throw new NotSupportedException(string.Format("HTTPS protocol pattern ({0}) not supported by ParsePath", strPath));
                }

                //OK, not that any file:// has been stripped off, see if we have a UNC or traditional pathname provided...
                if (strPath.StartsWith("\\\\")) {
                    isUNC = true;
                    ServerShare = strPath.Substring(2, strPath.IndexOf("\\", strPath.IndexOf("\\", 2) + 1) - 2);
                    ServerOnly = ServerShare.Substring(0, ServerShare.IndexOf("\\"));
                    ShareOnly = ServerShare.Substring(ServerShare.IndexOf("\\") + 1);
                } else {
                    if (strPath.Length < "C:\\".Length)
                        throw new NotSupportedException(string.Format("Invalid path ({0})", strPath));
                    if (strPath.Substring(1, 1) == ":") {
                        Drv = strPath.Substring(0, 2);
                        //We weren't given a path at all, but a simple filename...
                    } else {
                        isPath = false;
                    }
                }
                //If our would-be path contains any wild-cards, FileInfo will throw an exception, so deal with that here...
                if (strPath.IndexOf("*") > -1) { WildCardFound = true; strPath = strPath.Replace("*", "XXXXXXXX"); }

                fi = new FileInfo(strPath);
                switch (intPart)
                {
                    case ParseParts.DrvOnly:
                        return Drv;
                    case ParseParts.ServerShare:
                        return ServerShare;
                    case ParseParts.ServerOnly:
                        return ServerOnly;
                    case ParseParts.ShareOnly:
                        return ShareOnly;
                    case ParseParts.DirOnly:
                        if (!isPath) return string.Empty;
                        if (isUNC) return string.Format("{0}\\", fi.DirectoryName.Substring("\\\\".Length + ServerShare.Length));
                        return string.Format("{0}\\", fi.DirectoryName.Substring(Drv.Length));
                    case ParseParts.DirOnlyNoSlash:
                        if (!isPath) return string.Empty;
                        if (isUNC) return fi.DirectoryName.Substring("\\\\".Length + ServerShare.Length);
                        return fi.DirectoryName.Substring(Drv.Length);
                    case ParseParts.DrvDir:
                        return isPath ? string.Format("{0}\\", fi.DirectoryName) : string.Empty;
                    case ParseParts.DrvDirNoSlash:
                        return isPath ? fi.DirectoryName : string.Empty;
                    case ParseParts.DrvDirFileNameBase:
                        return isPath ? fi.FullName.Substring(0, fi.FullName.Length - fi.Extension.Length) : string.Empty;
                    case ParseParts.FileNameBaseExt:
                        return fi.Name;
                    case ParseParts.FileNameBase:
                        return fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length);
                    case ParseParts.FileNameExt:
                        return fi.Extension;
                    case ParseParts.FileNameExtNoDot:
                        return fi.Extension.Substring(1);
                }
            } finally {
                if (WildCardFound) functionReturnValue = functionReturnValue.Replace("XXXXXXXX", "*");
                fi = null;
            }
#else
            short intCPos = 0;
            short intLPos = 0;
            short intTemp = 0;
            short intPathStart = 0;
            short intPathLen = 0;
            string strPart1 = string.Empty;
            string strPart2 = string.Empty;
            string strPart4 = string.Empty;
            string strPart5 = string.Empty;
            functionReturnValue = string.Empty;

            intPathLen = (short)strPath.Length;

            //Get the Protocol (if any)...
            intCPos = (short)strPath.IndexOf("://");
            if (intCPos > 0)
            {
                if (intPart == ParseParts.Protocol) { strPath = Strings.Left(strPath, intCPos + "://".Length); return functionReturnValue; }
                //If we don't want the Protocol, strip it off so it won't interfere with any logic below...
                switch (strPath.ToLower().Parse(1, "://"))
                {
                    case "file":
                        //Path will be in any of the following formats:
                        //   file:///S:/FiRRe/... (note the extra "/" before the drive letter)...
                        //   file://\\WSRV08/SunGard/FiRRe/...
                        //   file://WWS004/SunGard/FiRRe/...
                        if (strPath.ToLower().StartsWith("file:///") && strPath.Substring(9, 1) == ":")
                        {
                            strPath = strPath.Substring("file:///".Length).Replace("/", "\\");
                        }
                        else if (strPath.ToLower().StartsWith("file://\\\\"))
                        {
                            strPath = strPath.Substring("file://".Length).Replace("/", "\\");
                        }
                        else if (strPath.ToLower().StartsWith("file://") && strPath.IndexOf(":", "file://".Length) == -1)
                        {
                            strPath = strPath.Substring("file:".Length).Replace("/", "\\");
                        }
                        else
                        {
                            throw new NotSupportedException(string.Format("FILE protocol pattern ({0}) not not recognized by ParsePath", strPath));
                        }
                        intPathLen = strPath.Length;
                        break;
                    case "http":
                        throw new NotSupportedException("HTTP protocol not currently supported by ParsePath");
                }
            }

            //Get drive portion.
            intCPos = Strings.InStr(strPath, ":");
            if (intCPos)
                strPart1 = Strings.Left(strPath, intCPos);

            //Get path portion.
            intLPos = Strings.InStr(1, strPath, "\\");
            if (Strings.Right(strPath, 1) == "\\")
            {
                //strPath contains no filename.
                if (intPathLen > intLPos)
                {
                    if (intPart < 0)
                    {
                        strPart2 = Strings.Mid(strPath, intLPos, intPathLen - intLPos);
                    }
                    else
                    {
                        strPart2 = Strings.Mid(strPath, intLPos);
                    }
                }
                else
                {
                    strPart2 = "\\";
                }

            }
            else
            {
                if (intLPos)
                {
                    //strPath must contain a filename.
                    intPathStart = intLPos;
                    intLPos = intLPos + 1;

                    do
                    {
                        intCPos = Strings.InStr(intLPos, strPath, "\\");
                        if (intCPos)
                        {
                            intLPos = intCPos + 1;
                        }
                    } while (intCPos);

                    if (intPart < 0)
                    {
                        strPart2 = Strings.Mid(strPath, intPathStart, intLPos - intPathStart - 1);
                    }
                    else
                    {
                        strPart2 = Strings.Mid(strPath, intPathStart, intLPos - intPathStart);
                    }
                }
                else
                {
                    //No path was found.
                    if (Strings.Len(strPart1))
                    {
                        //If drive spec, start at position 3 when getting filename portion.
                        intLPos = 3;
                    }
                    else
                    {
                        intLPos = 1;
                    }
                }

                strPart4 = Strings.Mid(strPath, intLPos);

                //Check if filename base has extension.
                intCPos = 1;
                do
                {
                    intTemp = Strings.InStr(intCPos + 1, strPart4, ".");
                    if (intTemp)
                        intCPos = intTemp;
                } while (intTemp);

                if (intCPos > 1)
                {
                    //Get filename extension portion.
                    // Check if it's "negative".
                    if (Strings.InStr(Convert.ToString(intPart), "-"))
                    {
                        strPart5 = Strings.Mid(strPart4, intCPos + 1);
                    }
                    else
                    {
                        strPart5 = Strings.Mid(strPart4, intCPos);
                    }
                    strPart4 = Strings.Left(strPart4, intCPos - 1);
                    //Get filename base portion.
                }
            }

            switch (intPart)
            {
                case ParseParts.DrvOnly:
                    functionReturnValue = strPart1;
                    break;
                case ParseParts.DirOnly:
                case ParseParts.DirOnlyNoSlash:
                    functionReturnValue = strPart2;
                    break;
                case ParseParts.DrvDir:
                case ParseParts.DrvDirNoSlash:
                    functionReturnValue = strPart1 + strPart2;
                    break;
                case ParseParts.FileNameBase:
                    functionReturnValue = strPart4;
                    break;
                case ParseParts.FileNameExt:
                case ParseParts.FileNameExtNoDot:
                    functionReturnValue = strPart5;
                    break;
                case ParseParts.FileNameBaseExt:
                    functionReturnValue = strPart4 + strPart5;
                    break;
                case ParseParts.DrvDirFileNameBase:
                    functionReturnValue = strPart1 + strPart2 + strPart4;
                    break;
                case ParseParts.Protocol:
                    functionReturnValue = strPart1;
                    break;
            }
#endif
            return functionReturnValue;
        }
        #endregion
        #region "Registry Stuff"
        private void CreateRegistryKey(string subkeyPath)
        {
            string subKey = $@"Software\{Company}\{Product}\{subkeyPath}";
            string[] subKeys = subKey.Split('\\');
            string Key = subKeys[0];
            //Iterate through the path making sure each sub-key exists (create as necessary)...
            for (short i = 1; i <= subKeys.Length - 1; i++) {
                subKey = $@"{Key}\{subKeys[i]}";
                if (!RegistryKeyExists(subKey)) {
                    using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(Key, true)) {
                        if (regKey != null) regKey.CreateSubKey(subKeys[i]);
                    }
                }
                Key = subKey;
            }
        }
        public object GetRegistryKeyValue(string subkeyPath, string valueName, object defaultValue)
        {
            string subKey = $@"Software\{Company}\{Product}\{subkeyPath}";
            if (!RegistryKeyExists(subkeyPath)) CreateRegistryKey(subkeyPath);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey)) {
                if (key == null) throw new KeyNotFoundException($"{subKey} not found or is inaccessible!");
                //Debug.WriteLine($@"{subKey}\{valueName} := {key.GetValue(valueName, defaultValue)}");
                return key.GetValue(valueName, defaultValue);
            }
        }
        private bool RegistryKeyExists(string subkeyPath)
        {
            string subKey = $@"Software\{Company}\{Product}\{subkeyPath}";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey)) {
                return (key != null);
            }
        }
        public void SetRegistryKeyValue(string subkeyPath, string valueName, object Data)
        {
            if (!RegistryKeyExists(subkeyPath)) CreateRegistryKey(subkeyPath);
            string subKey = $@"Software\{Company}\{Product}\{subkeyPath}";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey, true)) {
                if (key == null) throw new KeyNotFoundException($"{subKey} not found or is inaccessible!");
                key.SetValue(valueName, Data);
            }
        }
        #endregion
        #endregion
    }
}
