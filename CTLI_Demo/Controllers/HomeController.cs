using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CTLI_Demo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
           // ActionResult < IEnumerable<string> >
           return GetEmployees();
            //return new string[] { "Hello ", "Pradeep Kumar Oram" };


        }

        private string GetEmployees()
        {
            string connectionString =
           "Server=tcp:ctli-demo.database.windows.net,1433;Initial Catalog=CTLI_Demo;Persist Security Info=False;User ID=ctli_demo;Password=Viju029@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * from dbo.Employee_Details;";

            // Specify the parameter value.
            int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                string firstName = string.Empty;
                string lastName = string.Empty;
                try
                {
                    connection.Open();
                   
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        firstName = reader["First Name"].ToString();
                        lastName = reader["LastName"].ToString();
                        //Console.WriteLine("\t{0}\t{1}\t{2}",
                        //    reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return (firstName + " " + lastName);
            }
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
