using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Ceci est documentation de Employee.
    /// </summary>
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select EmployeeId , EmployeeName ,Departement , CONVERT(varchar(10),DateOfJoining,120) as DateOfJoining , PhotoFileName   from dbo.Employee";

            DataTable table = new DataTable();
            using (var connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MachaineConnexion"].ConnectionString))
            {
                using (var commande = new SqlCommand(query, connexion))
                {
                    using (var da = new SqlDataAdapter(commande))
                    {
                        commande.CommandType = CommandType.Text;
                        da.Fill(table);

                    }
                }
            }


            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                       insert into Employee values 
                       (
                       '" + emp.EmployeeName + @"'
                       ,'" + emp.Departement + @"'
                       ,'" + emp.DateOfJoining + @"'
                       ,'" + emp.PhotoFileName + @"'
                       )";

                DataTable table = new DataTable();
                using (var connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MachaineConnexion"].ConnectionString))
                {
                    using (var commande = new SqlCommand(query, connexion))
                    {
                        using (var da = new SqlDataAdapter(commande))
                        {
                            commande.CommandType = CommandType.Text;
                            da.Fill(table);
                            //connexion.Open();
                            //commande.ExecuteNonQuery();
                        }
                    }
                }
                return "Insertion employé réussite.";
            }
            catch (Exception)
            {
                return "Insertion employé échouée.";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"update employee
                        set 
                        EmployeeName = '" + emp.EmployeeName + @"',
                        Departement = '" + emp.Departement + @"',
                        DateOfJoining = '" + emp.DateOfJoining + @"',
                        PhotoFileName = '" + emp.PhotoFileName + @"'
                        where EmployeeId=" + emp.EmployeeId;

                DataTable table = new DataTable();
                using (var connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MachaineConnexion"].ConnectionString))
                {
                    using (var commande = new SqlCommand(query, connexion))
                    {
                        using (var da = new SqlDataAdapter(commande))
                        {
                            commande.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
                return "Modification employé réussite.";
            }
            catch (Exception)
            {
                return "Modification employé échouée.";
            }
        }

        /// <summary>
        /// ceci est une documentation pour la partie delete employe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from employee where EmployeeId=" + id;
                DataTable table = new DataTable();
                using (var connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MachaineConnexion"].ConnectionString))
                {
                    using (var commande = new SqlCommand(query, connexion))
                    {
                        using (var da = new SqlDataAdapter(commande))
                        {
                            commande.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }
                return "Suppression employé réussite.";
            }
            catch (Exception)
            {
                return "Suppression employé échouée.";
            }
        }

        [Route("api/Employee/GetAllDepartementNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartementNames()
        {
            string query = @"select DepartementName from Departement";
            DataTable table = new DataTable();
            using (var connexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MachaineConnexion"].ConnectionString))
            {
                using (var commande = new SqlCommand(query, connexion))
                {
                    using (var da = new SqlDataAdapter(commande))
                    {
                        commande.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        // methode pour le sauvegarde d'un fichier
        [Route("api/Employee/SaveFile")]
        [HttpPost]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];   //  if the httpRequest.files.count = 0 , uncheck the header Content-Type
                string fileName =  postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);
                postedFile.SaveAs(physicalPath);
                return fileName;
            }
            catch (Exception)
            {
                return "none.png";
            }
        }

    }
}