using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Threading.Tasks;

namespace NavegaTIC_CTI.Models.Dao
{
    public class CargaDataCasoCE
    {
        public static List<InforMail> GetBody(string subject)
        {
            List<InforMail> inforMails = new List<InforMail>();
            string body = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado1"].ConnectionString);
            SqlCommand com = new SqlCommand("Select cuerpo_correo from CorreoSoporteTi_Escalados where asunto_correo like '%" + subject + "%'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            int i = 1;
            while (registros.Read())
            {
                InforMail mail = new InforMail();
                mail.ContenidoMsj = registros["cuerpo_correo"].ToString();
                //body += "Correo " + i + " " + registros["cuerpo_correo"];
                //i++;
                inforMails.Add(mail);
            }
            con.Close();


            return inforMails;
        }
        public static List<Caso> Getdataemployees(string identificacion)
        {
            List<Caso> Employes = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATLANTIC"].ConnectionString);


                SqlCommand cmd = new SqlCommand("ATLANTIC..SP_selectdetailsemployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", identificacion);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employes.Add(new Caso()
                        {
                            Identificacion = dr["identificacion"].ToString(),
                            CostoId = dr["centrodecosto"].ToString(),
                            CargoId = dr["cargo"].ToString(),
                            Usuario = dr["usuario"].ToString(),
                            Email = dr["Enterprise_Email"].ToString(),
                            Sede=dr["location"].ToString(),
                            Nombre= dr["nombre"].ToString(),
                        });
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Employes;

        }

        public static List<Caso> GetdataemployeesIVR(string pkmu)
        {
            List<Caso> EmployesIVR = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);

                SqlCommand cmd = new SqlCommand("SP_selectdetailsemployeesivr", con);

                //SqlCommand cmd = new SqlCommand("ATLANTIC..SP_selectdetailsemployees2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", pkmu);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        EmployesIVR.Add(new Caso()
                        {
                            Identificacion = dr["identificacion"].ToString(),
                            CostoId = dr["centrodecosto"].ToString(),
                            CargoId = dr["cargo"].ToString(),
                            Usuario = dr["usuario"].ToString(),
                            Email = dr["Enterprise_Email"].ToString(),
                            Nombre = dr["nombre"].ToString(),
                            Celular = dr["celular"].ToString(),
                            Sede = dr["location"].ToString()
                        });
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return EmployesIVR;

        }
        public static List<Caso> Getdataemployees2(string pkmu)
        {
            List<Caso> Employes = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);

                SqlCommand cmd = new SqlCommand("SP_selectdetailsemployees2", con);

                //SqlCommand cmd = new SqlCommand("ATLANTIC..SP_selectdetailsemployees2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", pkmu);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employes.Add(new Caso()
                        {
                            Identificacion = dr["identificacion"].ToString(),
                            CostoId = dr["centrodecosto"].ToString(),
                            CargoId = dr["cargo"].ToString(),
                            Usuario = dr["usuario"].ToString(),
                            Email = dr["Enterprise_Email"].ToString(),
                            Nombre = dr["nombre"].ToString(),
                            Celular = dr["celular"].ToString(),
                            Sede = dr["location"].ToString()
                        }); 
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Employes;

        }

        public static List<Caso> GetcasoIVR(string casoid)
        {
            List<Caso> Employes = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MISCTISCRIPTER"].ConnectionString);


                SqlCommand cmd = new SqlCommand("sp_IVR_CentroExperienciaSelect", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Celular", casoid);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employes.Add(new Caso()
                        {
                            CategotyId = dr["Opcion_Presionada"].ToString(),
                            SubCategoryyId = dr["Opcion_Presionada"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                            Identificacion = dr["Documento"].ToString(),
                            NombreAgente = "",
                            CasoId = dr["Id_llamada"].ToString()

                        }); ;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Employes;

        }
        public static List<Caso> Getcasoform(string casoid)
        {
            List<Caso> Employes = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);


                SqlCommand cmd = new SqlCommand("Sp_WorkOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdWorkOrder", casoid);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employes.Add(new Caso()
                        {
                            CategotyId = dr["Category"].ToString(),
                            SubCategoryyId = dr["SubCategory"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(dr["DateLog"].ToString()),
                            NombreAgente = dr["agentname"].ToString()
                        }); ;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Employes;

        }
        /*public static List<Caso> GetNameAgent(string username)
        {
            List<Caso> Employes = new List<Caso>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ATLANTIC"].ConnectionString);


                SqlCommand cmd = new SqlCommand("ATLANTIC..SP_selectnameemployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("username", username);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Employes.Add(new Caso()
                        {
                            Identificacion = dr["IdEmployee"].ToString(),
                            NombreAgente = dr["usuario"].ToString()
                        });
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return Employes;

        }*/
        public static List<Sede> GetSedes()
        {
            List<Sede> sedes = new List<Sede>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Sede'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Sede sede = new Sede
                {
                    SedeId = int.Parse(registros["ID"].ToString()),
                    SedeName = registros["Disposition"].ToString()
                };
                sedes.Add(sede);
            }
            con.Close();
            return sedes;
        }

        public static List<Sede> GetSedesSAE()
        {
            List<Sede> sedes = new List<Sede>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='SedeSae'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Sede sede = new Sede
                {
                    SedeId = int.Parse(registros["ID"].ToString()),
                    SedeName = registros["Disposition"].ToString()
                };
                sedes.Add(sede);
            }
            con.Close();
            return sedes;
        }

        public static int GetAns(int categoryid, int areaid)
        {
            int sla = 0;
            List<Caso> slas = new List<Caso>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where finish="+ areaid+" and pri="+categoryid, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
              sla = int.Parse(registros["Disposition"].ToString());
         
            }
            con.Close();
            return sla;
        }
        public static List<Campana> GetCampana()
        {
            List<Campana> campanas = new List<Campana>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("select distinct Campaña from [Camp_Data].[dbo].[DispositionsCtiCe] where pri=33 and Area='Detalle'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Campana campana = new Campana
                {
                    //CampanaId = int.Parse(registros["ID"].ToString()),
                    CampanaName = registros["Campaña"].ToString()
                };
                campanas.Add(campana);
            }
            con.Close();
            return campanas;
        }
        public static List<AsignadoA> GetAsignadoA()
        {
            List<AsignadoA> asignadoas = new List<AsignadoA>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Asignado a'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                AsignadoA asignadoa = new AsignadoA
                {
                    AsignadoAId = int.Parse(registros["ID"].ToString()),
                    AsignadoAName = registros["Disposition"].ToString()
                };
                asignadoas.Add(asignadoa);
            }
            con.Close();
            return asignadoas;
        }
        public static List<Categoria> GetCategoria_aibt(int group)
        {
            List<Categoria> categorias = new List<Categoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);
            SqlCommand com = new SqlCommand("select IdCategory,NameCategory from CategoryDefinitions where IdMasterSites=22 and Parent_IdCategory is null and IdMasterGroupsAssigned ="+group, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Categoria categoria = new Categoria
                {
                    CategoriaId = int.Parse(registros["IdCategory"].ToString()),
                    CategoriaName = registros["NameCategory"].ToString()
                };
                categorias.Add(categoria);
            }
            con.Close();
            return categorias;
        }
        public static List<Categoria> GetCategoria()
        {
            
            List<Categoria> categorias = new List<Categoria>();
           
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Categoria'", con);
                con.Open();
                SqlDataReader registros = com.ExecuteReader();
                while (registros.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        CategoriaId = int.Parse(registros["ID"].ToString()),
                        CategoriaName = registros["Disposition"].ToString()
                    };
                    categorias.Add(categoria);
                }
                con.Close();
           
            return categorias;

        }

        public static List<Categoria> GetCategoriaSAE()
        {
           
                List<Categoria> categorias = new List<Categoria>();  
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='CategoriaSae'", con);
                con.Open();
                SqlDataReader registros = com.ExecuteReader();
                while (registros.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        CategoriaId = int.Parse(registros["ID"].ToString()),
                        CategoriaName = registros["Disposition"].ToString()
                    };
                    categorias.Add(categoria);
                }
                con.Close();
            
                return categorias;

        }

        public static List<Transferencia> GetTrandferencia()
        {

            List<Transferencia> transferencias = new List<Transferencia>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Transferencia'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Transferencia transferencia = new Transferencia
                {
                    TransferenciaId = int.Parse(registros["ID"].ToString()),
                    TransferenciaName = registros["Disposition"].ToString()
                };
                transferencias.Add(transferencia);
            }
            con.Close();

            return transferencias;

        }

        public static List<Detalle> GetDetalles()
        {
            List<Detalle> detalles = new List<Detalle>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri,Campaña FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Detalle'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Detalle detalle = new Detalle
                {
                    DetalleId = int.Parse(registros["ID"].ToString()),
                    DetalleName = registros["Disposition"].ToString(),
                    pri= int.Parse(registros["pri"].ToString()),
                    Campaña = registros["Campaña"].ToString(),
                };
                detalles.Add(detalle);
            }
            con.Close();
            return detalles;
        }
        public static List<Detalle> GetDetallesid(int id)
        {
            List<Detalle> detalles = new List<Detalle>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,Campaña FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Detalle' and pri =" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Detalle detalle = new Detalle
                {
                    DetalleId = int.Parse(registros["ID"].ToString()),
                    DetalleName = registros["Disposition"].ToString(),
                    Campaña = registros["Campaña"].ToString()
                };
                detalles.Add(detalle);
            }
            con.Close();
            return detalles;
        }
        public static List<EscaladoA> GetEscaladoa()
        {
            List<EscaladoA> escaladoAs = new List<EscaladoA>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Escalado A'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                EscaladoA escaladoa = new EscaladoA
                {
                    EscaladoAId = int.Parse(registros["ID"].ToString()),
                    EscaladoAName = registros["Disposition"].ToString()
                };
                escaladoAs.Add(escaladoa);
            }
            con.Close();
            return escaladoAs;
        }
        public static List<EscaladoA> GetEscaladoaSAE()
        {
            List<EscaladoA> escaladoAs = new List<EscaladoA>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Escalado Sae'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                EscaladoA escaladoa = new EscaladoA
                {
                    EscaladoAId = int.Parse(registros["ID"].ToString()),
                    EscaladoAName = registros["Disposition"].ToString()
                };
                escaladoAs.Add(escaladoa);
            }
            con.Close();
            return escaladoAs;
        }
        public static List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Estado'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Estado estado = new Estado
                {
                    EstadoId = int.Parse(registros["ID"].ToString()),
                    EstadoName = registros["Disposition"].ToString()
                };
                estados.Add(estado);
            }
            con.Close();
            return estados;
        }
        public static List<Estado> GetEstadosSAE()
        {
            List<Estado> estados = new List<Estado>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='EstadoSAE'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Estado estado = new Estado
                {
                    EstadoId = int.Parse(registros["ID"].ToString()),
                    EstadoName = registros["Disposition"].ToString()
                };
                estados.Add(estado);
            }
            con.Close();
            return estados;
        }

        public static List<Solucion> GetSoluciones()
        {
            List<Solucion> soluciones = new List<Solucion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Solucion'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Solucion solucion = new Solucion
                {
                    SolucionId = int.Parse(registros["ID"].ToString()),
                    SolucionName = registros["Disposition"].ToString()
                };
                soluciones.Add(solucion);
            }
            con.Close();
            return soluciones;
        }

        public static List<Solucion> GetSolucionesSAE()
        {
            List<Solucion> soluciones = new List<Solucion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Solucion Sae'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Solucion solucion = new Solucion
                {
                    SolucionId = int.Parse(registros["ID"].ToString()),
                    SolucionName = registros["Disposition"].ToString()
                };
                soluciones.Add(solucion);
            }
            con.Close();
            return soluciones;
        }

        public static List<Subcategoria> GetSubCategoria()
        {
            List<Subcategoria> subcategorias = new List<Subcategoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Subcategoria'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Subcategoria subcategoria = new Subcategoria
                {

                    SubcategoriaId = int.Parse(registros["ID"].ToString()),
                    SubcategoriaName = registros["Disposition"].ToString(),
                    pri = int.Parse(registros["pri"].ToString()),
                };
               
                    subcategorias.Add(subcategoria);
            }
            con.Close();
            return subcategorias;
        }
        public static List<Subcategoria> GetSubCategoriaSAE()
        {

            List<Subcategoria> subcategorias = new List<Subcategoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='SubcategoriaSae'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Subcategoria subcategoria = new Subcategoria
                {

                    SubcategoriaId = int.Parse(registros["ID"].ToString()),
                    SubcategoriaName = registros["Disposition"].ToString(),
                    pri = int.Parse(registros["pri"].ToString()),
                };

                subcategorias.Add(subcategoria);
            }
            con.Close();
            return subcategorias;
        }
        public static List<Ubicacion> GetUbicacion()
        {
            List<Ubicacion> Ubicaciones = new List<Ubicacion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Ubicacion'", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Ubicacion ubicacion = new Ubicacion
                {

                    UbicacionId= int.Parse(registros["ID"].ToString()),
                    UbicacionName = registros["Disposition"].ToString(),
                    pri = int.Parse(registros["pri"].ToString()),
                };

                Ubicaciones.Add(ubicacion);
            }
            con.Close();
            return Ubicaciones;
        }
        public static List<Ubicacion> GetUbicacionid(int id)
        {
            List<Ubicacion> Ubicaciones = new List<Ubicacion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Ubicacion'  and pri=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Ubicacion ubicacion = new Ubicacion
                {

                    UbicacionId = int.Parse(registros["ID"].ToString()),
                    UbicacionName = registros["Disposition"].ToString()
                    
                };

                Ubicaciones.Add(ubicacion);
            }
            con.Close();
            return Ubicaciones;
        }
        public static List<Ubicacion> GetUbicacionidSAE(int id)
        {
            List<Ubicacion> Ubicaciones = new List<Ubicacion>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Ubicacion'  and pri=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Ubicacion ubicacion = new Ubicacion
                {

                    UbicacionId = int.Parse(registros["ID"].ToString()),
                    UbicacionName = registros["Disposition"].ToString()

                };

                Ubicaciones.Add(ubicacion);
            }
            con.Close();
            return Ubicaciones;
        }
        public static List<Subcategoria> GetSubCategoriaid(int id)
        {
            List<Subcategoria> subcategorias = new List<Subcategoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='Subcategoria' and pri=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Subcategoria subcategoria = new Subcategoria
                {
                    SubcategoriaId = int.Parse(registros["ID"].ToString()),
                    SubcategoriaName = registros["Disposition"].ToString()
                };
                subcategorias.Add(subcategoria);
            }
            con.Close();
            return subcategorias;
        }

        public static List<Subcategoria> GetSubCategoriaidSAE(int id)
        {
            List<Subcategoria> subcategorias = new List<Subcategoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='SubcategoriaSae' and pri=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Subcategoria subcategoria = new Subcategoria
                {
                    SubcategoriaId = int.Parse(registros["ID"].ToString()),
                    SubcategoriaName = registros["Disposition"].ToString()
                };
                subcategorias.Add(subcategoria);
            }
            con.Close();
            return subcategorias;
        }



        public async static Task<Users> InforUserActual(bool? Profiles = null, bool? Sites = null, bool? Groups = null)
        {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            string name = user.Name;
            //string winuseractual = "jamendoza";
            string winuseractual= name.Remove(0, 4).ToUpper();
          //  string winuseractual= System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();

            List<Users> InforUser = await ListUsersBasic(null, winuseractual);
            if (InforUser.Count > 0)
            {
                
            }
            else
            {
                return null;
            }
            return InforUser[0];
        }
        public async static Task<List<Users>> ListUsersBasic(long? IdMasterUser = null, string Winuser = null)
        {
            List<Users> InforUser = new List<Users>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Sp_Users_Sel_ListUsersBasic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
               
                if (IdMasterUser != null) cmd.Parameters.AddWithValue("IdMasterUser", IdMasterUser);
                if (Winuser != null) cmd.Parameters.AddWithValue("Winuser", Winuser);

                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        InforUser.Add(new Users
                        {
                            IdMasterUsers = long.Parse(dr["IdMasterUsers"].ToString()),
                            PkEmpleado = long.Parse(dr["PkEmpleado"].ToString()),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            PrimerApellido = dr["PrimerApellido"].ToString(),
                            SegundoApellido = dr["SegundoApellido"].ToString(),
                            Winuser = dr["Winuser"].ToString(),
                            CentroCosto = dr["CentroCosto"].ToString(),
                            EmailCorporativo = dr["EmailCorporativo"].ToString(),
                            State = bool.Parse(dr["State"].ToString())
                        });
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
            return InforUser;
        }
        public static List<EscaladoACorreo> GetEscaladoCorreoId(int id)
        {
            List<EscaladoACorreo> escaladoacorreos = new List<EscaladoACorreo>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='EscaladoCorreo' and pri =" + id + "order by Pri", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                EscaladoACorreo escaldoacorreo = new EscaladoACorreo
                {

                    IdEscaladoACorreo = int.Parse(registros["ID"].ToString()),
                    NameEscaladoACorreo = registros["Disposition"].ToString(),
                    pri = int.Parse(registros["pri"].ToString()),
                };

                escaladoacorreos.Add(escaldoacorreo);
            }
            con.Close();
            return escaladoacorreos;
        }

        public static List<EscaladoACorreo> GetEscaladoCorreoIdSAE(int id)
        {
            List<EscaladoACorreo> escaladoacorreos = new List<EscaladoACorreo>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT ID,Disposition,pri FROM [Camp_Data].[dbo].[DispositionsCtiCe] where Area='EscaladoCorreoSae' and pri =" + id + "order by Pri", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                EscaladoACorreo escaldoacorreo = new EscaladoACorreo
                {

                    IdEscaladoACorreo = int.Parse(registros["ID"].ToString()),
                    NameEscaladoACorreo = registros["Disposition"].ToString(),
                    pri = int.Parse(registros["pri"].ToString()),
                };

                escaladoacorreos.Add(escaldoacorreo);
            }
            con.Close();
            return escaladoacorreos;
        }

        public async static Task<WorkOrder> SaveCrearTicket(long IdUserGestiona, WorkOrder Ticket, int group)
        {
                      
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);
                //string NameTransaction = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //cmd.Connection.Open();
                //cmd.Transaction = cmd.Connection.BeginTransaction("FinalizeImport" + NameTransaction);
               
             

                int IdGroupsAsign = group;
                int SLA_HOUR = 72;

                SqlCommand cmd = new SqlCommand("Sp_WorkOrder_Ins_SaveCrearTicket", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
               
                //cmd.CommandText = "Sp_WorkOrder_Ins_SaveCrearTicket";
                cmd.Parameters.AddWithValue("IdUserGestiona", IdUserGestiona);
                cmd.Parameters.AddWithValue("IdCategory", Ticket.IdCategory);
                if (Ticket.IdSubCategory != 0)
                {
                    cmd.Parameters.AddWithValue("IdSubCategory", Ticket.IdSubCategory);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IdSubCategory",null);
                }
                cmd.Parameters.AddWithValue("IdTemplates", 45);
                cmd.Parameters.AddWithValue("IdUsersAssigned", 17386);
                cmd.Parameters.AddWithValue("IdGroupsAssigned", IdGroupsAsign);
                cmd.Parameters.AddWithValue("SLA_HOUR", SLA_HOUR);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Ticket.IdWorkOrder = long.Parse(dr["IdWorkOrder"].ToString());
                        Ticket.DateSAP = dr["DateSAP"].ToString();
                    }
                }
                Ticket.IdWorkOrder = Ticket.IdWorkOrder;
                string QuerySQLFields = $@"INSERT INTO WorkOrder_Fields(IdWorkOrder,Title,Description,DateSAP,Category,SubCategory)
                VALUES(@IdWorkOrder,@Title,@Description,@DateSAP,@Category,@SubCategory);";
                if (Ticket.NameSubCategory == null)
                {
                    Ticket.NameSubCategory = "";
                }
                
                    //QuerySQLFields = QuerySQLFields.Replace(",)", ")").Replace(",@)", ")");
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = QuerySQLFields;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("IdWorkOrder", Ticket.IdWorkOrder);
                cmd.Parameters.AddWithValue("Title", Ticket.Description);
                cmd.Parameters.AddWithValue("Description", Ticket.Description);
                cmd.Parameters.AddWithValue("Category", Ticket.NameCategory);
                cmd.Parameters.AddWithValue("SubCategory", Ticket.NameSubCategory);
                cmd.Parameters.AddWithValue("DateSAP", Ticket.DateSAP);
                SqlDataReader registros = cmd.ExecuteReader();
                /*AGREGAR LOS ADJUNTOS*/
                con.Close();
            }
            catch (Exception ex)
            {
                
               
            }
            //finally
            //{
            //    cmd.Connection.Close();
            //}
            return Ticket;
        }

        public static List<Subcategoria> GetSubCategoriaid_aibt(int id)
        {
            List<Subcategoria> subcategorias = new List<Subcategoria>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);
            SqlCommand com = new SqlCommand("select IdCategory,NameCategory from CategoryDefinitions where IdMasterSites=22 and Parent_IdCategory=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Subcategoria subcategoria = new Subcategoria
                {
                    SubcategoriaId = int.Parse(registros["IdCategory"].ToString()),
                    SubcategoriaName = registros["NameCategory"].ToString()
                };
                subcategorias.Add(subcategoria);
            }
            con.Close();
            return subcategorias;
        }
        public  static bool Updatestatuswork(int status, int IdWorkOrder)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketsUnificado"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_updatestatuswork", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Status", status);
                cmd.Parameters.AddWithValue("IdWorkOrder", IdWorkOrder);


                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return resp;
        }
        public static List<Encuesta> GetEncuestaid(int id)
        {
            List<Encuesta> encuestas = new List<Encuesta>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("SELECT  respuestaencuesta,comentarioencuesta,idencuestacti FROM [Camp_Data].[dbo].[encuestaCTICE] where idencuestacti=" + id, con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Encuesta encuesta = new Encuesta();
                encuesta.CometarioEncuesta = registros["comentarioencuesta"].ToString();
                encuesta.RespuestaEncuesta = registros["respuestaencuesta"].ToString();
                encuesta.IdCTiCE = Convert.ToInt32(registros["idencuestacti"].ToString());                
                encuestas.Add(encuesta);
            }
            con.Close();
            return encuestas;
        }

        public static int Guardar(Caso data)
        {
                      
            
            
            int resp = 0;
            if (data.Fescalamiento.ToString() == "1/01/0001 12:00:00 a. m.")
            {
                data.Fescalamiento = null;
            }
            if (data.Fsolucion.ToString() == "1/01/0001 12:00:00 a. m.")
            {
                data.Fsolucion = null;
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Camp_Data..sp_CTICentroExperienciaInt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CasoId", data.CasoId);

                if (data.CasoId != null && data.CasoId != "")
                {
                    //capturar el usuario en curso
                }
                cmd.Parameters.AddWithValue("UsuarioAgent", data.Usuario);
                cmd.Parameters.AddWithValue("FechaSolicitud", data.FechaSolicitud);
                cmd.Parameters.AddWithValue("Canal", data.Canal);
                cmd.Parameters.AddWithValue("IdentificacionConsumer", data.Identificacion);
                //cmd.Parameters.AddWithValue("CasoId", data.CasoId);
                cmd.Parameters.AddWithValue("Nombre", data.Nombre);
                cmd.Parameters.AddWithValue("CargoId", data.CargoId);
                cmd.Parameters.AddWithValue("Celular", data.Celular);
                cmd.Parameters.AddWithValue("CostoId", data.CostoId);
                cmd.Parameters.AddWithValue("CategotyId", data.CategotyId);
                cmd.Parameters.AddWithValue("SubCategoryyId", data.SubCategoryyId);
                cmd.Parameters.AddWithValue("DescriptionId", data.DescriptionId);
                cmd.Parameters.AddWithValue("sedes", data.Sedes);
                cmd.Parameters.AddWithValue("asignadoa", data.Asignadoa);
                cmd.Parameters.AddWithValue("categoria", data.Categoria);
                cmd.Parameters.AddWithValue("subcategoria", data.Subcategoria);
                cmd.Parameters.AddWithValue("detalle", data.Detalle);
                cmd.Parameters.AddWithValue("detalle2", data.Detalle2);
                cmd.Parameters.AddWithValue("escalamiento", data.Escalamiento);            

                cmd.Parameters.AddWithValue("escaladoa", data.Escaladoa);
                cmd.Parameters.AddWithValue("fescalamiento", data.Fescalamiento);
                cmd.Parameters.AddWithValue("rescalamiento", data.Rescalamiento);
                cmd.Parameters.AddWithValue("soluciones", data.Soluciones);
                cmd.Parameters.AddWithValue("estados", data.Estados);
                if(data.Estados == "Cerrado")
                {
                    cmd.Parameters.AddWithValue("fsolucion", DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("fsolucion", data.Fsolucion);
                }
                
                cmd.Parameters.AddWithValue("ubicacion", data.ubicacion);
                cmd.Parameters.AddWithValue("clock", data.clock);
                cmd.Parameters.AddWithValue("Id_LlamadaIVR", data.Id_LlamadaIVR);
                cmd.Parameters.AddWithValue("Transferida", data.Transferida);
                cmd.Parameters.AddWithValue("Transferidade", data.Transferidade);
                
                // cmd.Parameters.AddWithValue("Departamento_Institucion", data.BEN_INST_DEPARTAMENTO);
                // cmd.Parameters.AddWithValue("Ciudad_Institucion", data.BEN_INST_CIUDAD);
                //cmd.Parameters.AddWithValue("Prog_Bavaria", data.PERTENECE_MUJER_EMPRENDEDORA);
                //cmd.Parameters.AddWithValue("Prog_TIC", data.PERTENECE_PROGRAMA_TIC);
                //cmd.Parameters.AddWithValue("Marca_Equipo", data.MARCA_EQUIPO);


                DataTable dt = new DataTable();
                resp = sd.Fill(dt);
                resp=Convert.ToInt32(dt.Rows[0]["a"]);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = 0;
            }

            return resp;
        }
        public async static Task<bool> GuardarDisposition(string area, string campana, string disposition,string pri=null)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Camp_Data..sp_Ins_Sede_Dispositions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Campana", campana);
                cmd.Parameters.AddWithValue("Disposition", disposition);
                cmd.Parameters.AddWithValue("Area", area);
                cmd.Parameters.AddWithValue("Pri", pri);

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return resp;
        }


        public async static Task<bool> guardarencuesta(int id, string respuesta = null, string comentario = null)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Camp_Data..[sp_Ins_ENCUESTA]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("respuesta", respuesta);
                cmd.Parameters.AddWithValue("comenatario", comentario);
                

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return resp;
        }
        public async static Task<bool> UpdateDisposition(string name, int id, string pri = null, string campana= null)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Camp_Data..sp_Upd_Dispositions_CTI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Campana", campana);
                cmd.Parameters.AddWithValue("Disposition", name);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Pri", pri);

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return resp;
        }
        public async static Task<bool> DeleteDisposition(int id)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Camp_Data..sp_Del_Dispositions_CTI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("Id", id);

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return resp;
        }

        public bool ValidarCaso(string idCaso)
        {
            bool esValido = false;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM [Camp_Data].[dbo].[CTICentroExperienciaInt] WHERE CasoId = @idCaso";
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.AddWithValue("@idCaso", idCaso);
                    int count = (int)com.ExecuteScalar();
                    esValido = count > 0;
                }
            }

            return esValido;
        }

    }

}