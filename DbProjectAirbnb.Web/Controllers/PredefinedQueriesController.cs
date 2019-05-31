using System;
using System.Data;
using System.Linq;
using DbProjectAirbnb.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbProjectAirbnb.Web.Controllers
{
    [Route("predefined-queries")]
    public class PredefinedQueriesController : Controller
    {
        private readonly ModelContext _modelContext;

        public PredefinedQueriesController(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult PredefinedQueryDetails(int id)
        {
            var matchedPredefinedQuery = _modelContext.PredefinedQueries.SingleOrDefault(e => string.Equals(e.Deliverable + e.Order.ToString("00"), id.ToString(), StringComparison.OrdinalIgnoreCase));
            if (matchedPredefinedQuery is null)
                return NotFound();
            var dbConnection = _modelContext.Database.GetDbConnection();
            try
            {
                dbConnection.Open();
                using (var sqlCommand = dbConnection.CreateCommand())
                {
                    var formattedSql = matchedPredefinedQuery.Sql.Replace("\r", " ").Replace("\n", " ").Split(";").FirstOrDefault();
                    sqlCommand.CommandText = formattedSql;
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            matchedPredefinedQuery.DataTable = new DataTable();
                            matchedPredefinedQuery.DataTable.BeginLoadData();
                            matchedPredefinedQuery.DataTable.Load(dataReader);
                            matchedPredefinedQuery.DataTable.EndLoadData();
                        }
                        catch
                        {
                            try
                            {
                                // handle averages
                                matchedPredefinedQuery.DataTable = new DataTable();
                                matchedPredefinedQuery.DataTable.BeginLoadData();
                                matchedPredefinedQuery.DataTable.Columns.Add("Count");
                                matchedPredefinedQuery.DataTable.Rows.Add(dataReader.GetDecimal(0));
                                matchedPredefinedQuery.DataTable.EndLoadData();
                            }
                            catch
                            {
                                try
                                {
                                    // handle counts
                                    matchedPredefinedQuery.DataTable = new DataTable();
                                    matchedPredefinedQuery.DataTable.BeginLoadData();
                                    matchedPredefinedQuery.DataTable.Columns.Add("Count");
                                    matchedPredefinedQuery.DataTable.Rows.Add(dataReader.GetInt32(0));
                                    matchedPredefinedQuery.DataTable.EndLoadData();
                                }
                                catch
                                {
                                    ;
                                    // can't parse generically
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // do nothing, just continue
                ;
            }
            finally
            {
                dbConnection.Close();
            }

            return View(matchedPredefinedQuery);
        }
    }
}