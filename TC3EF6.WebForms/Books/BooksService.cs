using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using TC3EF6.Data;
using TC3EF6.Domain.Classes.Stash;

namespace TC3EF6.WebForms.Books
{
    [ServiceContract]
    public interface IBooksService
    {
        [OperationContract]
        void DoWork();
        [OperationContract, WebGet(UriTemplate = "Books?pageSize={pageSize}&page={page}&search={search}", ResponseFormat=WebMessageFormat.Json)]
        DataTables<Book> GetData(int pageSize, int page, string search);
    }
    [DataContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BooksService : IBooksService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        // Add more operations here and mark them with [OperationContract]
        public static string PathInfo { get => (string)HttpContext.Current.Request.ServerVariables["PATH_INFO"]; }
        public void LogMessage(string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage((string)HttpContext.Current.Application["AppName"], Message);
            }
        }
        protected static void LogMessage(string Milestone, string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage(Milestone, Message);
            }
        }
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        public DataTables<Book> GetData(int pageSize, int page, string search)
        {
            DataTables<Book> result = new DataTables<Book>();
            try
            {
                //string search = ((string)HttpContext.Current.Request.Params["search[value]"]).Trim();
                //string draw = HttpContext.Current.Request.Params["draw"];
                //string order = HttpContext.Current.Request.Params["order[0][column]"];
                //string orderDir = HttpContext.Current.Request.Params["order[0][dir]"];
                //int startRec = Convert.ToInt32(HttpContext.Current.Request.Params["start"]);
                //int pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["length"]);
                // Loading.    
                LogMessage($@"{PathInfo}", "Reading data...");
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
                //int page = (startRec + pageSize) / pageSize;
                int startRec = page * pageSize;
                result.Data = query.Skip(startRec).Take(pageSize).ToList();
                LogMessage($@"{ PathInfo}", $"Read {result.Data.Count:#,##0} (page #{page:#,##0}) of {(filteredRecords == totalRecords ? $"{totalRecords:#,##0}" : $"{filteredRecords:#,##0} filtered ({totalRecords:#,##0} total)")} Books.");
                // Loading drop down lists.   (??? )
                //result.Draw = Convert.ToInt32(draw);
                result.RecordsTotal = totalRecords;
                result.RecordsFiltered = filteredRecords;
            }
            catch (Exception ex)
            {
                LogMessage($@"{ PathInfo}", ex.Message);
            }
            //WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return result;
        }
    }
}
