using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;
using TC3EF6.Domain.Classes.Stash;

namespace TC3EF6.WebForms
{
    [DataContract]
    public class DataTables<T>
    {
        [DataMember]
        public int Draw { get; set; }
        [DataMember]
        public int RecordsTotal { get; set; }
        [DataMember]
        public int RecordsFiltered { get; set; }
        [DataMember]
        public List<T> Data { get; set; }
    }
    public partial class ThemedBooksList : BasePage
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static object GetData()
        {
            // Initialization.    
            DataTables<Book> result = new DataTables<Book>();
            try
            {
                string search = ((string)HttpContext.Current.Request.Params["search[value]"]).Trim();
                string draw = HttpContext.Current.Request.Params["draw"];
                string order = HttpContext.Current.Request.Params["order[0][column]"];
                string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
                int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
                int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
                // Loading.    
                LogMessage($@"{PathInfo}/GetData", "Reading data...");
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}