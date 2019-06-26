using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TC3EF6.Data;
using TC3EF6.Data.Services;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Stash;
using TC3EF6.WebForms.Models.Books;

namespace TC3EF6.WebForms.Books
{
    public partial class BooksList : BasePage
    {
        public const string DetailURL = "/Books/BooksDetail.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>    
        /// GET: Default.aspx/GetData    
        /// </summary>    
        /// <returns>Return data</returns>    
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.    
            DataTables result = new DataTables();
            try
            {
                string search = ((string)HttpContext.Current.Request.Params["search[value]"]).Trim();
                string draw = HttpContext.Current.Request.Params["draw"];
                string order = HttpContext.Current.Request.Params["order[0][column]"];
                string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
                int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
                int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
                // Loading.    
                LogMessage("BooksList.aspx/GetData", "Reading Books data...");
                var context = new TCContext();
                IQueryable<Book> query = context.Books.AsNoTracking();
                int totalRecords = query.Count();   // Total record count.
                // Verification.    
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {   // Apply search    
                    query = query.Where(b => b.AlphaSort.Contains(search)
                                            || b.Title.Contains(search)
                                            || b.Author.Contains(search)
                                            || b.MediaFormat.Contains(search)
                                            || b.ISBN.Contains(search)
                                            || b.Location.Name.Contains(search)
                                        );
                }
                query = query.OrderBy(b => b.AlphaSort);
                // Sorting.    
                //query = SortByColumnWithOrder(order, orderDir, query);
                // Filter record count.    
                int filteredRecords = query.Count();
                // Apply pagination.    
                int page = (startRec + pageSize) / pageSize;
                result.Data = query.Skip(startRec).Take(pageSize).ToList();
                LogMessage("BooksList.aspx/GetData", $"Read {result.Data.Count:#,##0} (page #{page:#,##0}) of {(filteredRecords == totalRecords ? $"{totalRecords:#,##0}" : $"{filteredRecords:#,##0} filtered ({totalRecords:#,##0} total)")} Books.");
                // Loading drop down lists.   (??? )
                result.Draw = Convert.ToInt32(draw);
                result.RecordsTotal = totalRecords;
                result.RecordsFiltered = filteredRecords;
            }
            catch (Exception ex)
            {
                LogMessage("BooksList.aspx/GetData", ex.Message);
            }
            // Return info.    
            return result;
        }
        /// <summary>    
        /// Sort by column with order method.    
        /// </summary>    
        /// <param name="order">Order parameter</param>    
        /// <param name="orderDir">Order direction parameter</param>    
        /// <param name="data">Data parameter</param>    
        /// <returns>Returns - Data</returns>    
        private IQueryable<Book> SortByColumnWithOrder(string order, string orderDir, IQueryable<Book> query)
        {
            // Initialization.    
            try
            {
                // Sorting    
                query = query.OrderBy(b => b.AlphaSort);
                //switch (order)
                //{
                //    case "0":
                //        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.Sr) : query.OrderBy(p => p.Sr);
                //        break;
                //    case "1":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.OrderTrackNumber) : query.OrderBy(p => p.OrderTrackNumber);
                //        break;
                //    case "2":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.Quantity) : query.OrderBy(p => p.Quantity);
                //        break;
                //    case "3":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName);
                //        break;
                //    case "4":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.SpecialOffer) : query.OrderBy(p => p.SpecialOffer);
                //        break;
                //    case "5":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.UnitPrice) : query.OrderBy(p => p.UnitPrice);
                //        break;
                //    case "6":
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.UnitPriceDiscount) : query.OrderBy(p => p.UnitPriceDiscount);
                //        break;
                //    default:
                //        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(p => p.Sr) : query.OrderBy(p => p.Sr);
                //        break;
                //}
            }
            catch (Exception ex)
            {
                LogMessage("BooksList.aspx/GetData", ex.Message);
            }
            return query;
        }
        //private IQueryable<Book> Filter(IDataTablesRequest requestModel, FilterViewModel filterViewModel, IQueryable<Book> query, out int count)
        //{
        //    #region Filtering
        //    if (!string.IsNullOrEmpty(requestModel.Search.Value))
        //    {
        //        //We were triggered from the Search box...
        //        var value = requestModel.Search.Value.Trim();
        //        query = query.Where(b => b.AlphaSort.Contains(value)
        //                               || b.Title.Contains(value)
        //                               || b.Author.Contains(value)
        //                               || b.MediaFormat.Contains(value)
        //                               || b.ISBN.Contains(value)
        //                               || b.Location.Name.Contains(value)
        //                            );
        //    }
        //    #region AdvancedSearch
        //    //If we are coming from our frmFilter dialog, filterViewModel may be populated...
        //    if (!string.IsNullOrEmpty(filterViewModel.AlphaSort))
        //        query = query.Where(b => b.AlphaSort.Contains(filterViewModel.AlphaSort));
        //    if (!string.IsNullOrEmpty(filterViewModel.Title))
        //        query = query.Where(b => b.Title.Contains(filterViewModel.Title));
        //    if (!string.IsNullOrEmpty(filterViewModel.Author))
        //        query = query.Where(b => b.Author.Contains(filterViewModel.Author));
        //    if (!string.IsNullOrEmpty(filterViewModel.MediaFormat))
        //        query = query.Where(b => b.MediaFormat.Contains(filterViewModel.MediaFormat));
        //    if (!string.IsNullOrEmpty(filterViewModel.ISBN))
        //        query = query.Where(b => b.ISBN.Contains(filterViewModel.ISBN));
        //    if (!string.IsNullOrEmpty(filterViewModel.Location))
        //        query = query.Where(b => b.Location.Name.Contains(filterViewModel.Location));
        //    #endregion
        //    count = query.Count();
        //    #endregion Filtering
        //    #region Sorting
        //    var sortedColumns = requestModel.Columns.GetSortedColumns();
        //    var orderByString = String.Empty;

        //    foreach (var column in sortedColumns)
        //    {
        //        orderByString += orderByString != String.Empty ? "," : "";
        //        orderByString += (column.Data) +
        //          (column.SortDirection ==
        //          Column.OrderDirection.Ascendant ? " asc" : " desc");
        //    }
        //    query = query.OrderBy(orderByString == string.Empty ? "AlphaSort asc" : orderByString);
        //    //query = Repository.OrderBy(query, orderByString == string.Empty ? "AlphaSort asc" : orderByString);
        //    #endregion Sorting
        //    return query;
        //}
    }
}