using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Base;

namespace TC3EF6.Data.Services.SQL
{
    public class SQLUtilities
    {
        public enum ConnectionStringParts { 
            Database = 0,
            Server = 1,
            Driver = 2,
            UserID = 3,
            Password = 4
        }
        public enum SqlParts {
            Distinct = 1,
            Fields = 2,
            FromClause = 3,
            WhereClause = 4,
            HavingClause = 5,
            GroupByClause = 6,
            OrderByClause = 7,
            RowLimit = 8
        }
        public SQLUtilities()
        {
            Initialize(string.Empty);
        }
        #region "Locals"
        private string Source { get; set; }
        private string Fields { get; set; }
        private string FromClause { get; set; }
        private string WhereClause { get; set; }
        private string HavingClause { get; set; }
        private string GroupByClause { get; set; }
        private string OrderByClause { get; set; }
        private bool Distinct { get; set; }
        private int RowLimit { get; set; }
        #endregion

        private void Initialize(string SQLsource)
        {
            Source = SQLsource;
            Fields = string.Empty;
            FromClause = string.Empty;
            WhereClause = string.Empty;
            HavingClause = string.Empty;
            GroupByClause = string.Empty;
            OrderByClause = string.Empty;
            Distinct = false;
            RowLimit = 0;
        }
        private void NormalizeSQL(ref string SQLSource)
        {
            SQLSource = SQLSource.Replace("\r\n", " ").Trim();
            SQLSource = SQLSource.Replace("\r", " ").Trim();
            SQLSource = SQLSource.Replace("\n", " ").Trim();
            SQLSource = SQLSource.Replace("\t", " ").Trim();
            for (int i = 1; i <= 5; i++) SQLSource = SQLSource.Replace($"[Extent{i}].", string.Empty).Replace($" AS [Extent{i}]", string.Empty);
        }
        public string ParseConnectionString(string ConnectionString, ConnectionStringParts ItemType)
        {
            int iToken = 0;
            string Token = string.Empty;
            int iSearch = 0;
            List<string> SearchString = new List<string> { ConnectionString };
            string ExtendedProperties = string.Empty;

            //These connection strings change with one version of ADO to the next, so we must be flexible here...
            //The idea is to build a list of property strings, the first of which is the passed connection string itself.
            //Any property named "EXTENDED PROPERTIES" will be ignored, so we can treat them separately. Those extended properties
            //will be processed as their own string if the desired property isn't otherwise found...

            if (ConnectionString.ToUpper().Contains("EXTENDED PROPERTIES")) {
                ExtendedProperties = string.Empty;
                for (iToken = 1; iToken <= ConnectionString.Tokens(";"); iToken++) {
                    Token = ConnectionString.Parse(iToken, ";", "\"\"");
                    //Debug.Print "Token #" & iToken & ": " & Token
                    if (Token.Substring(0, "EXTENDED PROPERTIES".Length) == "EXTENDED PROPERTIES") break;
                }
                if (Token.Substring(0, "EXTENDED PROPERTIES".Length) != "EXTENDED PROPERTIES") return string.Empty;
                ExtendedProperties = Token.Substring("EXTENDED PROPERTIES=".Length + 1);
                SearchString.Add(ExtendedProperties);
            }

            for (iSearch = SearchString.Count; iSearch >= 0; iSearch--) {
                iToken = 1;
                Token = SearchString[iSearch - 1];
                while (Token != string.Empty) {
                    Token = SearchString[iSearch - 1].Parse(iToken, ";", "\"\"");
                    if (Token != string.Empty) {
                        switch (Token.ToUpper().Substring(0, Token.IndexOf("="))) {
                            case "DRIVER":
                            case "PROVIDER":
                                if (ItemType == ConnectionStringParts.Driver) {
                                    string temp = Token.Substring(Token.IndexOf("=") + 1);
                                    if (temp.Left(1) == "{") temp = temp.Substring(1, temp.Length - 2);
                                    return temp;
                                }
                                break;
                            case "UID":
                            case "USER ID":
                                if (ItemType == ConnectionStringParts.UserID) return Token.Substring(Token.IndexOf("=") + 1);
                                break;
                            case "PASSWORD":    //SQL Server
                                if (ItemType == ConnectionStringParts.Password) return Token.Substring(Token.IndexOf("=") + 1);
                                break;
                            case "SERVER":      //SQL Server
                                if (ItemType == ConnectionStringParts.Server) return Token.Substring(Token.IndexOf("=") + 1);
                                break;
                            case "DATABASE":    //SQL Server
                                if (ItemType == ConnectionStringParts.Database) return Token.Substring(Token.IndexOf("=") + 1);
                                break;
                            case "DATA SOURCE": //SQL Server
                                if (ItemType == ConnectionStringParts.Server) return Token.Substring(Token.IndexOf("=") + 1);
                                break;
                            default:
                                break;
                        }
                    }
                    iToken++;
                }
            }
            return string.Empty;
        }
        public object ParseSQLSelect(string SQL, SqlParts part)
        {
            //Expected sequence (1) Call ParseSQLSelect with source SQL and a given SqlPart.
            //Subsequent calls can then be made to return other parts without always passing 
            //return arguments as well as avoiding re-parsing on subsequent calls.
            if (SQL != Source)
            {
                ParseSQLSelect(SQL);
                //Tack-on HavingClause/GroupByClause data in WhereClause... if (the calling application needs these separate, it can call the other method...
                if (!string.IsNullOrEmpty(HavingClause)) WhereClause += $" Having {HavingClause}";
                if (!string.IsNullOrEmpty(GroupByClause)) WhereClause += $" Group By {GroupByClause}";
            }
            switch (part)
            {
                case SqlParts.Distinct: return Distinct;
                case SqlParts.Fields: return Fields;
                case SqlParts.FromClause: return FromClause;
                case SqlParts.WhereClause: return WhereClause;
                case SqlParts.HavingClause: return HavingClause;
                case SqlParts.GroupByClause: return GroupByClause;
                case SqlParts.OrderByClause: return OrderByClause;
                case SqlParts.RowLimit: return RowLimit;
                default:
                    throw new NotSupportedException($"Unexpected SqlParts value ({part})encountered.");
            }
        }
        private void ParseSQLSelect(string SQLSource)
        {
            Initialize(SQLSource);  //Source represents our original SQL...
            NormalizeSQL(ref SQLSource);
            //Gotta have a SELECT and a FROM...
            if (SQLSource.EndsWith(";")) SQLSource = SQLSource.Substring(0, SQLSource.Length - 1);
            if (!SQLSource.ToUpper().StartsWith("SELECT")) throw new NotSupportedException($"Only SQL Select statements are supported.\n SQL: {SQLSource}");

            if (SQLSource.ToUpper().StartsWith("SELECT DISTINCT"))
            {
                SQLSource = SQLSource.Substring("SELECT DISTINCT ".Length).Trim();
                Distinct = true;
            }
            else
            {
                SQLSource = SQLSource.Substring("SELECT ".Length).Trim();
            }
            if (SQLSource.ToUpper().StartsWith("TOP "))
            {
                SQLSource = SQLSource.Substring("TOP ".Length).Trim();
                RowLimit = int.Parse(SQLSource.Substring(0, SQLSource.IndexOf(" ")));
                SQLSource = SQLSource.Substring(RowLimit.ToString().Length).Trim();
            }

            string Token = string.Empty;    //This will be our ColumnExpression...
            string ColumnAlias = string.Empty;
            while (!SQLSource.ToUpper().StartsWith("FROM "))
            {
                SQLParseColumn(ref SQLSource, ref Token, ref ColumnAlias);
                if (!string.IsNullOrEmpty(Token)) Fields += $"{(string.IsNullOrEmpty(Fields) ? string.Empty : ",")}{Token}";
                if (string.IsNullOrEmpty(SQLSource)) break;
            }
            if (string.IsNullOrEmpty(SQLSource)) throw new NotSupportedException($"Problem parsing SQL (\"{Source}\")");
            //Now our SQLSource should begin with "From ..."
            SQLSource = SQLSource.Substring("FROM ".Length).Trim();
            //Now we need to find our Where clause for the main SQL statement. Note that there may be embedded sub-queries in the From clause...
            FromClause = string.Empty;

            bool ExitFor = false;
            for (int i = 0; i <= SQLSource.Length - 1 && !ExitFor; i++)
            {
                switch (SQLSource.Substring(i, 1))
                {
                    case " ":
                        //Since we've skipped forward through any paren-pairs, (assuming sub - queries need to be surrounded by parens) 
                        //if we now encounter a " WHERE ", it should be the main SQL's Where clause...
                        string temp = SQLSource.Substring(i + 1).Trim();
                        if (temp.ToUpper().StartsWith("WHERE ")) { FromClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                        if (temp.ToUpper().StartsWith("HAVING ")) { FromClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                        if (temp.ToUpper().StartsWith("GROUP BY ")) { FromClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                        if (temp.ToUpper().StartsWith("ORDER BY ")) { FromClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                        break;
                    case "(":
                        //Skip forward through the end of this expression...
                        short openParenCount = 1;
                        bool ExitFor2 = false;
                        for (int iParen = i + 1; iParen <= SQLSource.Length - 1 && !ExitFor2; iParen++)
                        {
                            switch (SQLSource.Substring(iParen, 1))
                            {
                                case "(": openParenCount += 1; break;
                                case ")": openParenCount -= 1; break;
                                default: break;
                            }
                            if (openParenCount == 0) { i = iParen; ExitFor2 = true; }
                        }
                        break;
                    default: break;
                }
            }
            //if (we leave the loop without finding anything else then the rest must be From clause...
            if (string.IsNullOrEmpty(FromClause)) { FromClause = SQLSource; return; }
            SQLSource = SQLSource.Trim();

            //Now our SQLSource may begin with "Where ..."
            if (SQLSource.Trim().ToUpper().StartsWith("WHERE "))
            {
                SQLSource = SQLSource.Substring("WHERE ".Length).Trim();
                //Now we need to find our Order By clause for the main SQL statement. Note that there may be embedded sub-queries in the Where clause...
                WhereClause = string.Empty;
                ExitFor = false;
                for (int i = 0; i <= SQLSource.Length - 1 && !ExitFor; i++)
                {
                    switch (SQLSource.Substring(i, 1))
                    {
                        case " ":
                            //Since we've skipped forward through any paren - pairs, (assuming sub - queries need to be surrounded by parens)
                            //if we now encounter an " ORDER BY ", it should be the main SQL's Group/ Order By clause...
                            string temp = SQLSource.Substring(i + 1).Trim();
                            if (temp.ToUpper().StartsWith("HAVING ")) { WhereClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                            if (temp.ToUpper().StartsWith("GROUP BY ")) { WhereClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                            if (temp.ToUpper().StartsWith("ORDER BY ")) { WhereClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                            break;
                        case "(":
                            //Skip forward through the end of this expression...
                            bool ExitFor2 = false;
                            short openParenCount = 1;
                            for (int iParen = i + 1; iParen <= SQLSource.Length - 1 && !ExitFor2; iParen++)
                            {
                                switch (SQLSource.Substring(iParen, 1))
                                {
                                    case "(": openParenCount += 1; break;
                                    case ")": openParenCount -= 1; break;
                                    default: break;
                                }
                                if (openParenCount == 0) { i = iParen; ExitFor2 = true; break; }
                            }
                            break;
                        default: break;
                    }
                }
                //if (we leave the loop without finding another grouping or order clause then the rest must be Where clause...
                if (string.IsNullOrEmpty(WhereClause)) { WhereClause = SQLSource; return; }
                SQLSource = SQLSource.Trim();

                //Now our SQLSource may begin with "Having ..."
                if (SQLSource.Trim().ToUpper().StartsWith("HAVING "))
                {
                    SQLSource = SQLSource.Substring("HAVING ".Length).Trim();
                    //We're currently not returning a HavingClause, so spin through to see what's next...
                    ExitFor = false;
                    for (int i = 0; i <= SQLSource.Length - 1 && !ExitFor; i++)
                    {
                        switch (SQLSource.Substring(i, 1))
                        {
                            case " ":
                                string temp = SQLSource.Substring(i + 1).Trim();
                                if (temp.ToUpper().StartsWith("GROUP BY ")) { HavingClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                                if (temp.ToUpper().StartsWith("ORDER BY ")) { HavingClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                                break;
                            case "(":
                                //Skip forward through the end of this expression...
                                bool ExitFor2 = false;
                                short openParenCount = 1;
                                for (int iParen = i + 1; iParen <= SQLSource.Length - 1 && !ExitFor2; iParen++)
                                {
                                    switch (SQLSource.Substring(iParen, 1))
                                    {
                                        case "(": openParenCount += 1; break;
                                        case ")": openParenCount -= 1; break;
                                        default: break;
                                    }
                                    if (openParenCount == 0) { i = iParen; ExitFor2 = true; break; }
                                }
                                break;
                            default: break;
                        }
                    }
                    //if (we leave the loop without finding another grouping or order clause then the rest must be Having clause...
                    if (string.IsNullOrEmpty(HavingClause)) { HavingClause = SQLSource; return; }
                    SQLSource = SQLSource.Trim();
                }

                //Now our SQLSource may begin with "Group By ..."
                if (SQLSource.Trim().ToUpper().StartsWith("GROUP BY "))
                {
                    SQLSource = SQLSource.Substring("GROUP BY ".Length).Trim();
                    //We're currently not returning a GroupByClause, so spin through to see what's next...
                    ExitFor = false;
                    for (int i = 0; i <= SQLSource.Length - 1 && !ExitFor; i++)
                    {
                        switch (SQLSource.Substring(i, 1))
                        {
                            case " ":
                                //Since we've skipped forward through any paren-pairs, (assuming sub - queries need to be surrounded by parens) 
                                //if we now encounter an " ORDER BY ", it should be the main SQL's Group/ Order By clause...
                                string temp = SQLSource.Substring(i + 1).Trim();
                                if (temp.ToUpper().StartsWith("ORDER BY ")) { GroupByClause = SQLSource.Substring(0, i); SQLSource = SQLSource.Substring(i + 1); ExitFor = true; break; }
                                break;
                            case "(":
                                //Skip forward through the end of this expression...
                                bool ExitFor2 = false;
                                short openParenCount = 1;
                                for (int iParen = i + 1; iParen <= SQLSource.Length - 1 && !ExitFor2; iParen++)
                                {
                                    switch (SQLSource.Substring(iParen, 1))
                                    {
                                        case "(": openParenCount += 1; break;
                                        case ")": openParenCount -= 1; break;
                                        default: break;
                                    }
                                    if (openParenCount == 0) { i = iParen; ExitFor2 = true; break; }
                                }
                                break;
                            default: break;
                        }
                    }
                    //if (we leave the loop without finding another grouping or order clause then the rest must be Group By clause...
                    if (string.IsNullOrEmpty(GroupByClause)) { GroupByClause = SQLSource; return; }
                    SQLSource = SQLSource.Trim();
                }
            }

            //Now our SQLSource may begin with "Order By ..."
            if (SQLSource.Trim().ToUpper().StartsWith("ORDER BY "))
            {
                //We expect the Order By clause to be last...
                OrderByClause = SQLSource.Substring("ORDER BY ".Length).Trim();
            }
        }
        private void SQLParseColumn(ref string Fields, ref string ColumnExpression, ref string ColumnAlias)
        {
            if (string.IsNullOrEmpty(Fields)) Fields = string.Empty;
            if (string.IsNullOrEmpty(ColumnExpression)) ColumnExpression = string.Empty;
            if (string.IsNullOrEmpty(ColumnAlias)) ColumnAlias = string.Empty;
            Fields = Fields.Trim();
            ColumnExpression = string.Empty;
            ColumnAlias = string.Empty;
            bool ExitFor = false;
            for (int i = 0; i <= Fields.Length - 1 && !ExitFor; i++)
            {
                switch (Fields.Substring(i, 1))
                {
                    case " ":
                        //Since we've skipped forward through any paren-pairs, if we now encounter a " FROM ", it should be the main SQL's From clause...
                        string temp = Fields.Substring(i + 1).Trim();
                        if (temp.ToUpper().StartsWith("FROM ")) { ColumnExpression = Fields.Substring(0, i); ExitFor = true; break; }
                        break;
                    case ",":
                        ColumnExpression = Fields.Substring(0, i);
                        ExitFor = true;
                        break;
                    case "(":
                        //Skip forward through the end of this expression...
                        bool ExitFor2 = false;
                        short openParenCount = 1;
                        for (int iParen = i + 1; iParen <= Fields.Length - 1 && !ExitFor2; iParen++)
                        {
                            switch (Fields.Substring(iParen, 1))
                            {
                                case "(": openParenCount += 1; break;
                                case ")": openParenCount -= 1; break;
                            }
                            if (openParenCount == 0) { i = iParen; ExitFor2 = true; break; }
                        }
                        break;
                    default: break;
                }
            }
            if (string.IsNullOrEmpty(ColumnExpression))
            {
                ColumnExpression = Fields;
                ColumnAlias = ColumnExpression;
                Fields = string.Empty;
            }
            if (ColumnExpression.IndexOf(")") != -1 && !ColumnExpression.EndsWith(")"))
            {
                if (string.IsNullOrEmpty(Fields)) { Fields = Fields.Substring(ColumnExpression.Length).Trim(); } //...before we change our ColumneExpression...
                string tempColumn = ColumnExpression.ToUpper().Parse(1, " AS ", "\"");
                string tempAlias = ColumnExpression.ToUpper().Parse(2, " AS ", "\"");
                if (string.IsNullOrEmpty(tempColumn) || string.IsNullOrEmpty(tempAlias))
                {
                    //An Alias may be present but not delimited with at space between the column expression and the alias, "auto-correct" such occurrences...
                    for (int i = ColumnExpression.Length - 1; i >= 0; i--)
                    {
                        if (ColumnExpression.Substring(i, 1) == ")")
                        {
                            ColumnExpression = $"{ColumnExpression.Substring(0, i + 1)} As [{ColumnExpression.Substring(i + 1)}]";
                            ColumnAlias = string.Empty;   //This causes the calling routine to take ColumnExpression as (i.e. already has the 'As "Alias"')...
                            break;
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(tempAlias))
                {
                    ColumnAlias = string.Empty;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Fields)) { Fields = Fields.Substring(ColumnExpression.Length).Trim(); } //...before we change our ColumneExpression...
                int iPos = ColumnExpression.ToUpper().IndexOf(" AS ");
                if (iPos > -1)
                {
                    string delim = ColumnExpression.Substring(iPos + " AS ".Length, 1);
                    //Check for an acceptable delimiter (assume the statement is syntactically correct and the delimiters match)...
                    if (delim == "\"" || delim == "'" || delim == "[")
                    {
                        ColumnAlias = string.Empty;   //This causes the calling routine to take ColumnExpression as (i.e. already has the 'As "Alias"')...
                    }
                    else
                    {
                        //Reconstruct the ColumnExpression and its Alias (which will be delimited with double-quotes below)...
                        ColumnExpression = $"{ColumnExpression.Substring(0, iPos)} As [{ColumnExpression.Substring(iPos + " AS ".Length).Trim()}]";
                        ColumnAlias = string.Empty;   //This causes the calling routine to take ColumnExpression as (i.e. already has the 'As "Alias"')...
                    }
                }
                else
                {
                    ColumnAlias = ColumnExpression;
                }
            }
            if (!string.IsNullOrEmpty(ColumnAlias)) ColumnAlias = $"\"{ColumnAlias}\"";
            if (Fields.StartsWith(",")) Fields = Fields.Substring(1).Trim();
        }
    }
}
