using NavegaTIC_CTI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NavegaTIC.Models.Dao
{
    public class CargaDataClaroColNavegaTICDAO
    {
        public async static Task<List<CargaDataClaroColNavegaTIC>> getGestion(string telefono = null, string Id = null)
        {
            bool resp = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            List<CargaDataClaroColNavegaTIC> data = new List<CargaDataClaroColNavegaTIC>();
            try
            {
                SqlCommand cmd = new SqlCommand("CTI_SCRIPTER..spr_Sel_ClaroColNavegaTIC_por_Telefono", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Telefono", telefono);
                cmd.Parameters.AddWithValue("Id", Id);

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    data = (from dr in dt.Rows.Cast<DataRow>()
                            select new CargaDataClaroColNavegaTIC()
                            {
                                FASE = dr["Fase"].ToString(),
                                ID = dr["Id"].ToString(),
                                ES_MENOR = dr["ES_MENOR"].ToString(),
                                ID_REGISTRO = dr["Id_Registro"].ToString(),
                                ASESOR = dr["Asesor"].ToString(),
                                ESTADO = dr["Estado"].ToString(),
                                CATEGORIA = dr["Categoria"].ToString(),
                                BEN_PRIMER_NOMBRE = dr["Primer_Nombre"].ToString(),
                                BEN_SEGUNDO_NOMBRE = dr["Segundo_Nombre"].ToString(),
                                BEN_PRIMER_APELLIDO = dr["Primer_Apellido"].ToString(),
                                BEN_SEGUNDO_APELLIDO = dr["Segundo_Apellido"].ToString(),
                                BEN_TIPO_DOCUMENTO = dr["Tipo_Identificacion"].ToString(),
                                BEN_DOCUMENTO = dr["Identificacion"].ToString(),
                                BEN_FECHA_NACIMIENTO = dr["Fecha_nacimiento"].ToString(),
                                BEN_FECHA_EXPEDICION = dr["Fecha_Expedicion"].ToString(),
                                BEN_CORREO = dr["Correo"].ToString(),
                                BEN_TELEFONO1 = dr["No_Telefono_1"].ToString(),
                                BEN_TELEFONO2 = dr["No_Telefono_2"].ToString(),
                                BEN_TELEFONO3 = dr["No_Telefono_3"].ToString(),
                                BEN_DIRECCION = dr["Direccion"].ToString(),
                                BEN_DEPARTAMENTO = dr["Departamento"].ToString(),
                                BEN_CIUDAD = dr["Ciudad"].ToString(),
                                BEN_BARRIO_O_VEREDA = dr["Barrio"].ToString(),
                                BEN_CODIGO_DANE = dr["Cod_Dane"].ToString(),
                                BEN_ESTRATO = dr["Estrato"].ToString(),
                                BEN_EQUIPO4G = dr["Equipo4G"].ToString(),
                                BEN_SERVICIOS_ACTIVOS = dr["Tiene_Servicios"].ToString(),
                                BEN_PAGARIA_SIM = dr["Puede_Pagar_SIM"].ToString(),
                                BEN_CONFIRMA_PAGARIA_SIM = dr["Confirm_Pag_SIM"].ToString(),
                                BEN_INSTITUCION_EDUCATIVA = dr["Institucion_Educativa"].ToString(),
                                BEN_INST_DIRECCION = dr["Direccion_Institucion"].ToString(),
                                BEN_INST_DEPARTAMENTO = dr["Departamento_Institucion"].ToString(),
                                BEN_INST_CIUDAD = dr["Ciudad_Institucion"].ToString(),
                                BEN_INST_CODIGO_DANE = dr["Cod_Dane_Institucion"].ToString(),
                                BEN_NIVEL_ESCOLAR = dr["Nivel_Escolar"].ToString(),
                                BEN_TIEMPO_FALTANTE = dr["Tiempo_Faltante"].ToString(),
                                REPRE_PRIMER_NOMBRE = dr["Rep_Primer_Nombre"].ToString(),
                                REPRE_SEGUNDO_NOMBRE = dr["Rep_Segundo_Nombre"].ToString(),
                                REPRE_PRIMER_APELLIDO = dr["Rep_Primer_Apellido"].ToString(),
                                REPRE_SEGUNDO_APELLIDO = dr["Rep_Segundo_Apellido"].ToString(),
                                REPRE_TIPO_DOCUMENTO = dr["Rep_Tipo_Identificacion"].ToString(),
                                REPRE_DOCUMENTO = dr["Rep_Identificacion"].ToString(),
                                REPRE_PARENTESCO = dr["Rep_Parentesco"].ToString(),
                                REPRE_DIRECCION = dr["Rep_Direccion"].ToString(),
                                REPRE_DEPARTAMENTO = dr["Rep_Departamento"].ToString(),
                                REPRE_MUNICIPIO = dr["Rep_Municipio"].ToString(),
                                REPRE_COD_DANE = dr["Rep_Cod_Dane"].ToString(),
                                REPRE_BARRIO = dr["Rep_Barrio"].ToString(),
                                REPRE_CORREO = dr["Rep_Correo"].ToString(),
                                PERTENECE_MUJER_EMPRENDEDORA = dr["Prog_Bavaria"].ToString(),
                                PERTENECE_PROGRAMA_TIC = dr["Prog_TIC"].ToString(),
                                MARCA_EQUIPO = dr["Marca_Equipo"].ToString(),
                                FECHA_NACIMIENTO_MENOR = dr["Fecha_Nacimiento_Menor"].ToString(),
                                DANE_DEPARTAMENTO = dr["Gen_Cod_Dane_Dep"].ToString(),
                                DANE_MUNICPIO = dr["Gen_Cod_Dane_Municipio"].ToString(),
                                NombreArchivoData = dr["NombreArchivoData"].ToString(),
                                Tipificacion1 = dr["Tipificacion1"].ToString(),
                                Tipificacion2 = dr["Tipificacion2"].ToString(),
                                En_3DIAS = dr["Atiende3Dias"].ToString(),
                                FECHA_ATENCION = dr["DiaAtencion"].ToString(),
                                DIRECCION_ENTREGA = dr["DireccionEntrega"].ToString()

                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                resp = false;
            }

            return data;
        }


        public async static Task<bool> Guardar(CargaDataClaroColNavegaTIC data)
        {
            bool resp = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("CTI_SCRIPTER..spr_Upd_ClaroColNavegaTIC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", data.ID);

                if (data.IdAgente != null && data.IdAgente != "")
                {
                    //capturar el usuario en curso
                }
                cmd.Parameters.AddWithValue("AgenteId", data.IdAgente);
                cmd.Parameters.AddWithValue("Primer_Nombre", data.BEN_PRIMER_NOMBRE);
                cmd.Parameters.AddWithValue("Segundo_Nombre", data.BEN_SEGUNDO_NOMBRE);
                cmd.Parameters.AddWithValue("Primer_Apellido", data.BEN_PRIMER_APELLIDO);
                cmd.Parameters.AddWithValue("Segundo_Apellido", data.BEN_SEGUNDO_APELLIDO);
                cmd.Parameters.AddWithValue("Tipo_Identificacion", data.BEN_TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("Identificacion", data.BEN_DOCUMENTO);
                cmd.Parameters.AddWithValue("Fecha_Nacimiento", data.BEN_FECHA_NACIMIENTO);
                cmd.Parameters.AddWithValue("Fecha_Expedicion", data.BEN_FECHA_EXPEDICION);
                cmd.Parameters.AddWithValue("Correo", data.BEN_CORREO);
                cmd.Parameters.AddWithValue("No_Telefono_1", data.BEN_TELEFONO1);
                cmd.Parameters.AddWithValue("No_Telefono_2", data.BEN_TELEFONO2);
                cmd.Parameters.AddWithValue("No_Telefono_3", data.BEN_TELEFONO3);
                cmd.Parameters.AddWithValue("Direccion", data.BEN_DIRECCION);
                cmd.Parameters.AddWithValue("Departamento", data.BEN_DEPARTAMENTO);
                cmd.Parameters.AddWithValue("Ciudad", data.BEN_CIUDAD);
                cmd.Parameters.AddWithValue("Barrio", data.BEN_BARRIO_O_VEREDA);
                cmd.Parameters.AddWithValue("Cod_Dane", data.BEN_CODIGO_DANE);
                cmd.Parameters.AddWithValue("Estrato", data.BEN_ESTRATO);
                cmd.Parameters.AddWithValue("Equipo4G", data.BEN_EQUIPO4G);
                cmd.Parameters.AddWithValue("Tiene_Servicios", data.BEN_SERVICIOS_ACTIVOS);
                cmd.Parameters.AddWithValue("Puede_Pagar_SIM", data.BEN_PAGARIA_SIM);
                cmd.Parameters.AddWithValue("Confirm_Pag_SIM", data.BEN_CONFIRMA_PAGARIA_SIM);
                cmd.Parameters.AddWithValue("Institucion_Educativa", data.BEN_INSTITUCION_EDUCATIVA);
                cmd.Parameters.AddWithValue("Direccion_Institucion", data.BEN_INST_DIRECCION);
                cmd.Parameters.AddWithValue("Departamento_Institucion", data.BEN_INST_DEPARTAMENTO);
                cmd.Parameters.AddWithValue("Ciudad_Institucion", data.BEN_INST_CIUDAD);
                cmd.Parameters.AddWithValue("Cod_Dane_Institucion", data.BEN_INST_CODIGO_DANE);
                cmd.Parameters.AddWithValue("Nivel_Escolar", data.BEN_NIVEL_ESCOLAR);
                cmd.Parameters.AddWithValue("Tiempo_Faltante", data.BEN_TIEMPO_FALTANTE);
                cmd.Parameters.AddWithValue("Rep_Primer_Nombre", data.REPRE_PRIMER_NOMBRE);
                cmd.Parameters.AddWithValue("Rep_Segundo_Nombre", data.REPRE_SEGUNDO_NOMBRE);
                cmd.Parameters.AddWithValue("Rep_Primer_Apellido", data.REPRE_PRIMER_APELLIDO);
                cmd.Parameters.AddWithValue("Rep_Segundo_Apellido", data.REPRE_SEGUNDO_APELLIDO);
                cmd.Parameters.AddWithValue("Rep_Tipo_Identificacion", data.REPRE_TIPO_DOCUMENTO);
                cmd.Parameters.AddWithValue("Rep_Identificacion", data.REPRE_DOCUMENTO);
                cmd.Parameters.AddWithValue("Rep_Parentesco", data.REPRE_PARENTESCO);
                cmd.Parameters.AddWithValue("Rep_Direccion", data.REPRE_DIRECCION);
                cmd.Parameters.AddWithValue("Rep_Departamento", data.REPRE_DEPARTAMENTO);
                cmd.Parameters.AddWithValue("Rep_Municipio", data.REPRE_MUNICIPIO);
                cmd.Parameters.AddWithValue("Rep_Cod_Dane", data.REPRE_COD_DANE);
                cmd.Parameters.AddWithValue("Rep_Barrio", data.REPRE_BARRIO);
                cmd.Parameters.AddWithValue("Rep_Correo", data.REPRE_CORREO);
                cmd.Parameters.AddWithValue("Es_Menor", data.ES_MENOR);
                cmd.Parameters.AddWithValue("Tipificacion1", data.Tipificacion1);
                cmd.Parameters.AddWithValue("Tipificacion2", data.Tipificacion2);
                cmd.Parameters.AddWithValue("En_3DIAS", data.En_3DIAS);
                cmd.Parameters.AddWithValue("FECHA_ATENCION", data.FECHA_ATENCION);
                cmd.Parameters.AddWithValue("DIRECCION_ENTREGA", data.DIRECCION_ENTREGA);


                //cmd.Parameters.AddWithValue("Prog_Bavaria", data.PERTENECE_MUJER_EMPRENDEDORA);
                //cmd.Parameters.AddWithValue("Prog_TIC", data.PERTENECE_PROGRAMA_TIC);
                //cmd.Parameters.AddWithValue("Marca_Equipo", data.MARCA_EQUIPO);


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

        public async static Task<List<Departamentos>>  getDepartamentos()
        {
            List<Departamentos> departamentos = new List<Departamentos>();
           try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("CTI_SCRIPTER..spr_Sel_Departamentos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        departamentos.Add(new Departamentos() {
                            departamentoId = row["departamentoId"].ToString(),
                            nombreDepartamento = row["nombreDepartamento"].ToString()
                        });
                    }
                   
                }
            }
            catch(Exception)
            {
            }

            return departamentos;

        }

        public async static Task<List<Municipios>> getMunicipios()
        {
            List<Municipios> Municipios = new List<Municipios>();
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Camp_DataConnectionString"].ConnectionString);

                SqlCommand cmd = new SqlCommand("CTI_SCRIPTER..spr_Sel_Municipios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                sd.Fill(dt);
                con.Close();


                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Municipios.Add(new Municipios()
                        {
                            departamentoId = dr["departamentoId"].ToString(),
                            nombreCiudad = dr["nombreCiudad"].ToString(),
                            ciudadId = dr["ciudadId"].ToString()
                        });
                    }

                }
                                
            }
            catch (Exception)
            {
            }

            return Municipios;

        }


    }
}