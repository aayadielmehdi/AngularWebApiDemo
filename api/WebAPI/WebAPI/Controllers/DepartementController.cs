using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartementController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT  [DepartementId]
      ,[DepartementName]
  FROM [EmployeDB].[dbo].[Departement]";

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

        public string Post(Departement dep)
        {
            try
            {
                string query = @"insert into Departement values ('" + dep.DepartementName + @"')";
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
                return "Insertion département réussite.";
            }
            catch (Exception)
            {
                return "Insertion département échouée.";
            }
        }

        public string Put(Departement dep)
        {
            try
            {
                string query = @"update Departement set DepartementName = '" + dep.DepartementName + @"' where DepartementId=" + dep.DepartementId;
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
                return "Modification département réussite.";
            }
            catch (Exception)
            {
                return "Modification département échouée.";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from Departement where DepartementId=" + id;
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
                return "Suppression département réussite.";
            }
            catch (Exception)
            {
                return "Suppression département échouée.";
            }
        }
    }
}