using System;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace DbProjectAirbnb.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            string connectionString = "User Id=C##DB2019_G30;Password=DB2019_G30;Data Source=cs322-db.epfl.ch:1521/ORCLCDB";

            using (var oracleConnection = new OracleConnection(connectionString))
            {
                using (var oracleCommand = oracleConnection.CreateCommand())
                {
                    try
                    {
                        oracleConnection.Open();
                        oracleCommand.CommandText = "SELECT COUNT(*) FROM RAW_LISTINGS";
                        var reader = oracleCommand.ExecuteReader();

                        var outputText = string.Empty;
                        while (reader.Read())
                        {
                            outputText += reader.GetInt32(0);
                        }

                        reader.Dispose();
                        oracleConnection.Close();
                        return Ok(outputText);
                    }
                    catch (Exception exception)
                    {
                        return BadRequest("Connection failure " + exception.Message);
                    }
                }
            }
        }
    }
}