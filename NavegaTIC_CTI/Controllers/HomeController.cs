using NavegaTIC.Models.Dao;
using NavegaTIC.Models;
using NavegaTIC_CTI.Models.Dao;
using NavegaTIC_CTI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Security.Principal;

namespace NavegaTIC_CTI.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
           
           // GetCaso();
            
            return RedirectToAction("GetCaso/id/72212269");
        }
        public ActionResult Encuesta(int id=0)
        {
            Encuesta encuesta = new Encuesta();
            // GetCaso();
            if (id != 0)
            {

                List<Encuesta> encuestas = CargaDataCasoCE.GetEncuestaid(id);
                encuesta = encuestas.Find(z => z.IdCTiCE == id);
                if(encuesta == null)
                {
                    encuesta = new Encuesta();
                    encuesta.IdCTiCE = id;
                }
            }
            else
            {
                
                encuesta.IdCTiCE = id;
            }
            return View(encuesta);
        }
        [HttpPost]
        public ActionResult Encuesta(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Encuesta encuestas = new Encuesta();
                    //encuestas.IdCTiCE = Convert.ToInt32(collection["IdCTiCE"]);
                    encuestas.RespuestaEncuesta = collection["RespuestaEncuesta"];
                    encuestas.CometarioEncuesta = collection["CometarioEncuesta"];

                    _ = CargaDataCasoCE.guardarencuesta(id, encuestas.RespuestaEncuesta, encuestas.CometarioEncuesta);
                    // TODO: Add insert logic here
                }
                return RedirectToAction("Encuesta");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetSla(int category, int area)
        {
            int result = CargaDataCasoCE.GetAns(category, area);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        // [HttpGet]
        // GET: /GetCaso/Edit/5
        private string GetChatId(string id = "0")
        {

            string chatid = "";

            //consumo de servicio en wolkbox
            // string dateini = "20211104063511"; // DateTime.Now.AddMinutes(-1500).ToString("yyyyMMddHHmss");
            //string dateend = "20211104145512"; // DateTime.Now.ToString("yyyyMMddHHmmss");
            string dateini = DateTime.Now.AddMinutes(-60).ToString("yyyyMMddHHmss");
            string dateend = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string dateini = "20211215160000";
            //string dateend = "20211215163000";
            string token = ConfigurationManager.AppSettings["tokenChatId"].ToString(); //tokenChatId

            string report = "chat_8";
            string ipserver = "35.231.71.177";


            var url = $"http://{ipserver}/ipdialbox/api_reports_manager.php?" +
            $"token={token}&" +
            $"report={report}&date_ini={dateini}&date_end={dateend}";


            try
            {

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        //if (strReader == null) return;
                        using (
                            StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            dynamic responseApi = js.Deserialize<dynamic>(responseBody);
                            // Do something with responseBody
                            if (responseApi != null)
                            {

                                List<long> listId = new List<long>();
                                foreach (dynamic item in responseApi)
                                {
                                    if (item["PHONE CUSTOMER"] != "" && item["PHONE CUSTOMER"] == id)
                                    {
                                        listId.Add(long.Parse(item["CHAT ID"]));
                                    }
                                }

                                if (listId.Count > 0)
                                {
                                    listId.Sort();

                                    chatid = listId.LastOrDefault().ToString();
                                }
                                else
                                {
                                    chatid = "000";
                                }

                            }

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error

                chatid = "0000";
            }

            return chatid;
        }
        public ActionResult GetCaso(Int64 id, string phone,string channel, string chatid=null, string cat = null, string subcat = null, string ani = null, string canal = null, string ucid = null, string agentid= null)
        {
           
            string body = "";
            Caso casochat = new Caso();
            string identificacion = id.ToString();
            List<AsignadoA> asignadoas = CargaDataCasoCE.GetAsignadoA();            
            List<Detalle> detalles = CargaDataCasoCE.GetDetalles();            
                               
            
            List<Caso> employes = CargaDataCasoCE.Getdataemployees(identificacion);
            List<InforMail> body2 = new List<InforMail>();
            List<Caso> employes2 = CargaDataCasoCE.Getdataemployees2(identificacion);
            List<Transferencia> transferencias = CargaDataCasoCE.GetTrandferencia();
            

            string urlRepository = ConfigurationManager.AppSettings["urlRepository"];
            if (channel == "chat") {
                List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
                List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
                List<Sede> sedes = CargaDataCasoCE.GetSedes();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoa();
                List<Estado> estados = CargaDataCasoCE.GetEstados();

                //string chatid = GetChatId(phone);
                // _ = CargaDataCasoCE.GetSedes();
                //string dateini = "20211001160000";
                string dateini = DateTime.Now.AddDays(-2).ToString("yyyyMMdd000000");
                //string dateini = DateTime.Now.AddMinutes(-60).ToString("yyyyMMddHHmss");
                string dateend = DateTime.Now.ToString("yyyyMMdd235900");

                //string dateini = DateTime.Now.AddMinutes(-60).ToString("yyyyMMddHHmss");
                //string dateend = DateTime.Now.ToString("yyyyMMddHHmmss");

                //string dateini = "20211215160000";
                //string dateend = "20211215163000";

                //string token = "7b69645f6469737472697d2d3230323131303139313434363031";
                string token = ConfigurationManager.AppSettings["tokenChat"].ToString();
                string report = "chat_1";
                string ipserver = "wv0040.wolkvox.com";
                var url = $"http://{ipserver}/api/v2/reports_manager.php?" +
                          //$"token={token}&" +
                          $"api={report}&date_ini={dateini}&date_end={dateend}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["wolkvox-token"] = token;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                // List<Caso> agents = CargaDataCasoCE.GetNameAgent(casochat);
                string responseBody = "";
                using (var response = request.GetResponse())
                {
                    using (var strReader = response.GetResponseStream())
                    {
                        //if (strReader == null) return;
                        using (var objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();

                        }
                    }
                }
                int i = 0;


                JavaScriptSerializer js2 = new JavaScriptSerializer();
                dynamic CasoObject2 = js2.Deserialize<dynamic>(responseBody);
                //CasoObject2 = null;
                if (!(CasoObject2 is null))
                {
                    //while (CasoObject2.Length > i)
                    foreach (var item in CasoObject2)
                    {
                        if (item.Key == "data")
                        {
                            var values = item.Value;


                            while (values.Length > i)
                            {
                                if (values[i]["conn_id"] == chatid)
                                {
                                    body2 = CargaDataCasoCE.GetBody(values[i]["conn_id"]);

                                    string categoria = values[i]["description_cod_act"];
                                    categoria = categoria.Replace('_', ' ');
                                    //     if (CasoObject2[i]["customer email"] == employes[0].Email)
                                    //   {
                                    // body = CargaDataCasoCE.GetBody(CasoObject2[i]["chat-id"]);
                                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                                    string name = user.Name;
                                    casochat = new Caso();
                                    casochat.CasoId = values[i]["conn_id"];
                                    casochat.Nombre = employes[0].Nombre;
                                    casochat.Celular = values[i]["customer_phone"];
                                    casochat.FechaSolicitud = Convert.ToDateTime(values[i]["date"]);
                                    casochat.Canal = channel;
                                    casochat.Sede = employes[0].Sede;
                                    casochat.Email = employes[0].Email;
                                    casochat.Identificacion = identificacion;
                                    casochat.CargoId = employes[0].CargoId;
                                    casochat.CostoId = employes[0].CostoId;
                                    casochat.CategotyId = cat;
                                    casochat.SubCategoryyId = subcat;
                                    //casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                                    casochat.Usuario = name.Remove(0, 4).ToUpper();
                                    casochat.NombreAgente = values[i]["agent_name"];
                                    //Rescalamiento = body

                                }
                                i++;
                            }
                        }
                    }

                }
                else
                {
                    casochat = new Caso
                    {
                        CasoId = "",
                        Nombre = "",
                        Celular = "",
                        FechaSolicitud = DateTime.Now,
                        Canal = "",
                        Email = "",
                        Identificacion = "",
                        CargoId = "",
                        CostoId = "",
                        CategotyId = "",
                        SubCategoryyId = "",
                        Usuario = "",
                        NombreAgente = "",
                        Rescalamiento = ""


                    };
                }
                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.sedes = sedes;
                ViewBag.escaladoas = escaladoas;
                ViewBag.estados = estados;
            }
            if (channel == "CHAT-SAE")
            {
                

                List<Categoria> categorias = CargaDataCasoCE.GetCategoriaSAE();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaSAE();
                List<Solucion> soluciones = CargaDataCasoCE.GetSolucionesSAE();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoaSAE();
                List<Sede> sedes = CargaDataCasoCE.GetSedesSAE();
                List<Estado> estados = CargaDataCasoCE.GetEstadosSAE();

                //string chatid = GetChatId(phone);
                // _ = CargaDataCasoCE.GetSedes();
                //string dateini = "20211001160000";
                string dateini = DateTime.Now.AddDays(-2).ToString("yyyyMMdd000000");
                string dateend = DateTime.Now.ToString("yyyyMMdd235900");

                //string dateini = "20211215160000";
                //string dateend = "20211215163000";

                //string token = "7b69645f6469737472697d2d3230323131303139313434363031";
                string token = ConfigurationManager.AppSettings["tokenChatSAE"].ToString();
                string report = "chat_1";
                string ipserver = "wv0040.wolkvox.com";
                var url = $"http://{ipserver}/api/v2/reports_manager.php?" +
                          //$"token={token}&" +
                          $"api={report}&date_ini={dateini}&date_end={dateend}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["wolkvox-token"] = token;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                // List<Caso> agents = CargaDataCasoCE.GetNameAgent(casochat);
                string responseBody = "";
                using (var response = request.GetResponse())
                {
                    using (var strReader = response.GetResponseStream())
                    {
                        //if (strReader == null) return;
                        using (var objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();

                        }
                    }
                }
                int i = 0;


                JavaScriptSerializer js2 = new JavaScriptSerializer();
                dynamic CasoObject2 = js2.Deserialize<dynamic>(responseBody);
                //dynamic Casohijo = CasoObject2[3]["Value"];
                //CasoObject2 = null;
                if (!(CasoObject2 is null))
                {
                    //while (CasoObject2.Length > i)
                    foreach (var item in CasoObject2)
                    {
                        if (item.Key == "data")
                        {
                            var values = item.Value;

                            
                            while (values.Length > i)
                            {
                                if (values[i]["conn_id"] == chatid)
                                {
                                    body2 = CargaDataCasoCE.GetBody(values[i]["conn_id"]);

                                    string categoria = values[i]["description_cod_act"];
                                    categoria = categoria.Replace('_', ' ');
                                    //     if (CasoObject2[i]["customer email"] == employes[0].Email)
                                    //   {
                                    // body = CargaDataCasoCE.GetBody(CasoObject2[i]["chat-id"]);
                                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                                    string name = user.Name;
                                    casochat = new Caso();



                                    casochat.CasoId = values[i]["conn_id"];
                                    casochat.Nombre = employes[0].Nombre;
                                    casochat.Celular = values[i]["customer_phone"];
                                    casochat.FechaSolicitud = Convert.ToDateTime(values[i]["date"]);
                                    casochat.Canal = channel;
                                    casochat.Sede = employes[0].Sede;
                                    casochat.Email = employes[0].Email;
                                    casochat.Identificacion = identificacion;
                                    casochat.CargoId = employes[0].CargoId;
                                    casochat.CostoId = employes[0].CostoId;
                                    casochat.CategotyId = cat;
                                    casochat.SubCategoryyId = subcat;
                                    //casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                                    casochat.Usuario = name.Remove(0, 4).ToUpper();
                                    casochat.NombreAgente = values[i]["agent_name"];
                                    //Rescalamiento = body                                                                      
                                    
                                }
                                i++;
                            }
                        }
                    }

                }
                else
                {
                    casochat = new Caso
                    {
                        CasoId = "",
                        Nombre = "",
                        Celular = "",
                        FechaSolicitud = DateTime.Now,
                        Canal = "",
                        Email = "",
                        Identificacion = "",
                        CargoId = "",
                        CostoId = "",
                        CategotyId = "",
                        SubCategoryyId = "",
                        Usuario = "",
                        NombreAgente = "",
                        Rescalamiento = ""


                    };
                }
                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.sedes = sedes;
                ViewBag.escaladoas = escaladoas;
                ViewBag.estados = estados;
            }
            else if(channel=="form"){
                body2 = CargaDataCasoCE.GetBody(phone);
                List <Caso> workorder= CargaDataCasoCE.Getcasoform(phone);
                List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
                List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoa();
                List<Sede> sedes = CargaDataCasoCE.GetSedes();
                List<Estado> estados = CargaDataCasoCE.GetEstados();

                string categoria = workorder[0].CategotyId;
               
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                string name = user.Name;
                casochat = new Caso();

                casochat.CasoId = phone;
                casochat.Nombre = employes2[0].Nombre;
                casochat.Celular = employes2[0].Celular;
                casochat.FechaSolicitud = workorder[0].FechaSolicitud;
                casochat.Canal = channel;
                casochat.Email = employes2[0].Email;
                casochat.Sede = employes2[0].Sede;
                casochat.Identificacion = employes2[0].Identificacion; ;
                casochat.CargoId = employes2[0].CargoId;
                casochat.CostoId = employes2[0].CostoId;
                casochat.CategotyId = workorder[0].CategotyId;
                casochat.SubCategoryyId = workorder[0].SubCategoryyId;
                casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                //casochat.Usuario = name.Remove(0, 4).ToUpper();
                casochat.NombreAgente = workorder[0].NombreAgente;

                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.escaladoas = escaladoas;
                ViewBag.sedes = sedes;
                ViewBag.estados = estados;
            }
            else if (channel == "Correo")
            {
                body2 = CargaDataCasoCE.GetBody(phone);
                List<Caso> workorder = CargaDataCasoCE.Getcasoform(phone);
                string categoria = workorder[0].CategotyId;
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
                List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoa();
                List<Sede> sedes = CargaDataCasoCE.GetSedes();
                List<Estado> estados = CargaDataCasoCE.GetEstados();

                string name = user.Name;
                casochat = new Caso();
                casochat.CasoId = phone;
                casochat.Nombre = employes2[0].Nombre;
                casochat.Celular = employes2[0].Celular;
                casochat.FechaSolicitud = workorder[0].FechaSolicitud;
                casochat.Canal = channel;
                casochat.Email = employes2[0].Email;
                casochat.Sede = employes2[0].Sede;
                casochat.Identificacion = employes2[0].Identificacion; ;
                casochat.CargoId = employes2[0].CargoId;
                casochat.CostoId = employes2[0].CostoId;
                casochat.CategotyId = workorder[0].CategotyId;
                casochat.SubCategoryyId = workorder[0].SubCategoryyId;
                casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                //casochat.Usuario = name.Remove(0, 4).ToUpper();
                casochat.NombreAgente = workorder[0].NombreAgente;

                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.escaladoas = escaladoas;
                ViewBag.sedes = sedes;
                ViewBag.estados = estados;
            }
            if (canal == "IVR")
            {
                if (agentid == "80801" )
                {
                    agentid = "85802";
                }
                body2 = CargaDataCasoCE.GetBody(phone);
                List<Caso> workorder = CargaDataCasoCE.GetcasoIVR(ani);
                List<Caso> employesivr = CargaDataCasoCE.Getdataemployees(workorder[0].Identificacion);
                List<Caso> agenteIVR = CargaDataCasoCE.GetdataemployeesIVR(agentid);
                List<Categoria> categorias = CargaDataCasoCE.GetCategoria();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoria();
                List<Solucion> soluciones = CargaDataCasoCE.GetSoluciones();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoa();
                List<Sede> sedes = CargaDataCasoCE.GetSedes();
                List<Estado> estados = CargaDataCasoCE.GetEstados();

                string categoria = workorder[0].CategotyId;

                WindowsIdentity user = WindowsIdentity.GetCurrent();
                string name = user.Name;
                casochat = new Caso();

                casochat.CasoId = workorder[0].CasoId; //"1653581062.3521";// 
                casochat.Nombre = employesivr[0].Nombre; //"NICOLE PEREZ";//
                casochat.Celular = ani; //"3017252036";// 
                casochat.FechaSolicitud = Convert.ToDateTime(workorder[0].FechaSolicitud);
                casochat.Canal = canal; //"IVR"; //
                casochat.Email = employesivr[0].Email; //"nperez @aib.com.co";// 
                casochat.Sede = employesivr[0].Sede; //"CALLE 77";//   
                casochat.Identificacion = employesivr[0].Identificacion; //"1140893789";//
                casochat.CargoId = employesivr[0].CargoId; //"AGENTE DE CALL CENTER";// 
                casochat.CostoId = employesivr[0].CostoId; //"Software";// 
                casochat.CategotyId =  categoria.Split('-')[0];//"Software";
                if ((categoria.Contains("-")))
                {



                    casochat.SubCategoryyId = categoria.Split('-')[1]; ;// "Instalar VPN";// 
                }
                else
                {
                    casochat.SubCategoryyId = ""; //"Instalar VPN"; // 
                }
                casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                //casochat.Usuario = name.Remove(0, 4).ToUpper();
                if (agenteIVR.Count == 0)
                {
                    casochat.NombreAgente = "Anónimo";
                }
                else
                {
                    casochat.NombreAgente = "Anónimo"; //agenteIVR[0].Nombre;
                }
                casochat.Id_LlamadaIVR = ucid;//"00001135461653581237";// 

                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.escaladoas = escaladoas;
                ViewBag.sedes = sedes;
                ViewBag.estados = estados;

            } else if (canal == "IVR-SAE")
            {
                if (agentid == "80801")
                {
                    agentid = "85802";
                }
                body2 = CargaDataCasoCE.GetBody(phone);
                List<Caso> workorder = CargaDataCasoCE.GetcasoIVR(ani);
                List<Caso> employesivr = CargaDataCasoCE.Getdataemployees(workorder[0].Identificacion);
                List<Caso> agenteIVR = CargaDataCasoCE.GetdataemployeesIVR(agentid);
                List<Categoria> categorias = CargaDataCasoCE.GetCategoriaSAE();
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaSAE(); 
                List<Solucion> soluciones = CargaDataCasoCE.GetSolucionesSAE();
                List<EscaladoA> escaladoas = CargaDataCasoCE.GetEscaladoaSAE();
                List<Sede> sedes = CargaDataCasoCE.GetSedesSAE();
                List<Estado> estados = CargaDataCasoCE.GetEstadosSAE();

                string categoria = workorder[0].CategotyId;

                WindowsIdentity user = WindowsIdentity.GetCurrent();
                string name = user.Name;
                casochat = new Caso();

                casochat.CasoId = workorder[0].CasoId; //"1653581062.3521";// 
                casochat.Nombre = employesivr[0].Nombre; //"NICOLE PEREZ";//
                casochat.Celular = ani; //"3017252036";// 
                casochat.FechaSolicitud = Convert.ToDateTime(workorder[0].FechaSolicitud);
                casochat.Canal = canal; //"IVR"; //
                casochat.Email = employesivr[0].Email; //"nperez @aib.com.co";// 
                casochat.Sede = employesivr[0].Sede; //"CALLE 77";//   
                casochat.Identificacion = employesivr[0].Identificacion; //"1140893789";//
                casochat.CargoId = employesivr[0].CargoId; //"AGENTE DE CALL CENTER";// 
                casochat.CostoId = employesivr[0].CostoId; //"Software";// 
                casochat.CategotyId = categoria.Split('-')[0];//"Software";
                if ((categoria.Contains("-")))        {

                    casochat.SubCategoryyId = categoria.Split('-')[1]; ;// "Instalar VPN";// 
                }
                else
                {
                    casochat.SubCategoryyId = ""; //"Instalar VPN"; // 
                }
                casochat.Usuario = System.Web.HttpContext.Current.User.Identity.Name.ToString().Remove(0, 4).ToUpper();
                //casochat.Usuario = name.Remove(0, 4).ToUpper();
                if (agenteIVR.Count == 0)
                {
                    casochat.NombreAgente = "Anónimo";
                }
                else
                {
                    casochat.NombreAgente = "Anónimo"; //agenteIVR[0].Nombre;
                }
                casochat.Id_LlamadaIVR = ucid;//"00001135461653581237";// 

                ViewBag.categorias = categorias;
                ViewBag.subcategorias = subcategorias;
                ViewBag.soluciones = soluciones;
                ViewBag.escaladoas = escaladoas;
                ViewBag.sedes = sedes;
                ViewBag.estados = estados;
            }

            ViewBag.transferencias = transferencias;
            ViewBag.urlRepository = urlRepository;
                     
            ViewBag.asignadoas = asignadoas;  
            ViewBag.detalles = detalles;            
            
            
            
            ViewBag.body2 = body2;
            return View(casochat);
        }
        public async Task<ActionResult> GestionCTI(string telefono = null, string Id = null, string Agente = null)
        {
            ViewBag.Telefono = telefono;
            ViewBag.Id = Id;
            ViewBag.Agente = Agente;

            return View();
        }

        [HttpGet]
        public JsonResult Subcategoria(int clave)
        {
           
                List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaid(clave);
                return Json(subcategorias, JsonRequestBehavior.AllowGet);      
            
        }

        [HttpGet]
        public JsonResult SubcategoriaSAE(int clave)
        {

            List<Subcategoria> subcategorias = CargaDataCasoCE.GetSubCategoriaidSAE(clave);
            return Json(subcategorias, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Ubicacion(int clave)
        {
            List<Ubicacion> ubicaciones = CargaDataCasoCE.GetUbicacionid(clave);
            return Json(ubicaciones, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UbicacionSAE(int clave)
        {
            List<Ubicacion> ubicaciones = CargaDataCasoCE.GetUbicacionidSAE(clave);
            return Json(ubicaciones, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listcorreos(int clave)
        {
            List<EscaladoACorreo> escaladosacorreos = CargaDataCasoCE.GetEscaladoCorreoId(clave);
            return Json(escaladosacorreos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listcorreosSAE(int clave)
        {
            List<EscaladoACorreo> escaladosacorreos = CargaDataCasoCE.GetEscaladoCorreoIdSAE(clave);
            return Json(escaladosacorreos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Detalle(int clave)
        {
            List<Detalle> detalles = CargaDataCasoCE.GetDetallesid(clave);
            return Json(detalles, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Formulario(string Telefono = null, string Id = null, string Agente = null)
        {
            Dictionary<string, string> Departamentos = new Dictionary<string, string>();

            Departamentos.Add("SUCRE", "SUCRE");

            Dictionary<string, string> Municipios = new Dictionary<string, string>();

            Municipios.Add("SINCELEJO", "SINCELEJO");

            ViewBag.Departamentos = Departamentos;
            ViewBag.Municipios = Municipios;

            List<SelectListItem> Tipificacion1 = new List<SelectListItem>();

            Tipificacion1.Add(new SelectListItem { Text = "Efectivo", Value = "Efectivo" });
            Tipificacion1.Add(new SelectListItem { Text = "No Efectivo", Value = "No Efectivo" });
            Tipificacion1.Add(new SelectListItem { Text = "No Perfil", Value = "No Perfil" });

            ViewBag.Tipificacion1 = Tipificacion1;


            List<CargaDataClaroColNavegaTIC> data = new List<CargaDataClaroColNavegaTIC>();
            CargaDataClaroColNavegaTIC data1 = new CargaDataClaroColNavegaTIC();

            if (Id != null && Id != "")
            {
                data = await CargaDataClaroColNavegaTICDAO.getGestion(null, Id);

            }
            else if (Telefono != null && Telefono != "")
            {
                data = await CargaDataClaroColNavegaTICDAO.getGestion(Telefono, null);
            }

            if (data.Count > 0)
            {
                if (Agente != null && Agente != "")
                    data[0].IdAgente = Agente;

                return PartialView(data[0]);

            }
            else
            {
                if (Agente != null && Agente != "")
                    data1.IdAgente = Agente;

                return PartialView(data1);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult>   Guardar(Caso caso)
        {
            int status = 1;
            string Mensage = "";
            int result;
            int Group = 113;
            long IdUsuarioGestor = 0;
           WorkOrder Ticket = new WorkOrder();
            Users winuseractual = await CargaDataCasoCE.InforUserActual();
            if (caso.Escalamiento == "Si") { 
            IdUsuarioGestor = winuseractual.IdMasterUsers;
            //long IdUsuarioGestor = 1;
            Ticket.IdCategory = caso.Categoria; // Categoria; //1;// caso.Categoria;
            Ticket.IdSubCategory = caso.Subcategoria; //1; // 
            Ticket.Description = caso.CategotyId; //"Prueba SAE"; //caso.DescriptionId;
            Ticket.NameCategory = caso.CategotyId; // "Hardware"; // caso.Nombre;
            Ticket.NameSubCategory = caso.SubCategoryyId;
            }
            

            try
            {
                result= CargaDataCasoCE.Guardar(caso);
                

                if (caso.Escalamiento == "Si" && (caso.Escaladoa == "49" || caso.Escaladoa == "429" || caso.Escaladoa == "432" || caso.Escaladoa == "433" || caso.Escaladoa == "507") )
                {                   
                   CargaDataCasoCE.SaveCrearTicket(IdUsuarioGestor, Ticket, Group);
                }
                
                if (caso.Estados.Contains("Abierto"))
                {
                    status = 1;
                }
                else if(caso.Estados.Contains("Cerrado"))
                {
                    status = 2;
                }
                else if (caso.Estados.Contains("Escalado"))
                {
                    status = 599;
                }
                if (caso.Canal != "IVR")
                {
                    CargaDataCasoCE.Updatestatuswork(status, Convert.ToInt32(caso.CasoId));                   

                }
                List<string> ListDestCorreos = new List<string>();
                ListDestCorreos.Add(caso.Email);
                InforMail DataMail = new InforMail();
                DataMail.Asunto = $"FIN - {ConstProject.NameEnvio}";
                DataMail.ContenidoMsj = $"Sr(a) {caso.Nombre} Su caso {caso.CasoId} se encuentra en estado {caso.Estados} </p>" +
                    $" Por favor llene la siguiente encuesta <a href='http://cticentroexperienciainterna/Home/Encuesta?id=" + result + "'>Encuesta de satisfacción</a>.";
                DataMail.Destinatarios = ListDestCorreos;
                //DataMail.Destinatarios = DAOCommand.EmailUsersException();

                SendMail(DataMail);

            }
            catch (Exception ex)
            {
                Mensage = ex.Message;
            }

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject( new { Mensage = Mensage}));

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Enviarcorreo(Caso caso)
        {
            string Mensage = "";
            
            try
            {
                //result = CargaDataCasoCE.Guardar(caso);
                List<string> ListDestCorreos = new List<string>();
                string allWords = caso.Correos;
                string[] wordBag = allWords.Split(';',' ');
                foreach (string word in wordBag)
                {
                    if(word != "")
                        ListDestCorreos.Add(word);
                }
                InforMail DataMail = new InforMail();
                DataMail.Asunto = caso.asuntomail;
                DataMail.ContenidoMsj = caso.bodymail;
                DataMail.Destinatarios = ListDestCorreos;
                //DataMail.Destinatarios = DAOCommand.EmailUsersException();

                SendMail(DataMail);


            }
            catch (Exception ex)
            {
                Mensage = ex.Message;
            }

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(new { Mensage = Mensage }));

        }
        public static void SendMail(InforMail DataMail)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(ConstProject.SmtpMail, "Escalamiento de casos"),
                    Subject = DataMail.Asunto,
                    SubjectEncoding = Encoding.UTF8,
                    Body = $"{DataMail.ContenidoMsj}</br></br>",
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };
                foreach (string dest in DataMail.Destinatarios) mail.To.Add(dest);

                SmtpClient smtp = new SmtpClient
                {
                    EnableSsl = true,
                    Port = int.Parse(ConstProject.SmtpPort),
                    Host = ConstProject.SmtpHost,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(ConstProject.SmtpMail, ConstProject.SmtpPwd)
                };
                smtp.Send(mail);
                smtp.Dispose();
            }
            catch (Exception ex)
            {
                //throw new Exception($"Tools.SendMail({getLineErr(ex)}): {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Departamentos(CargaDataClaroColNavegaTIC caso)
        {
            List<Departamentos> departamentos = new List<Departamentos>();
            try
            {

                departamentos = await CargaDataClaroColNavegaTICDAO.getDepartamentos();
            }
            catch (Exception ex)
            {
            }

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(departamentos));

        }
        [HttpPost]
        public async Task<ActionResult> Municipios(CargaDataClaroColNavegaTIC caso)
        {
            List<Municipios> municipios = new List<Municipios>();

            try
            {
                municipios = await CargaDataClaroColNavegaTICDAO.getMunicipios();
            }
            catch (Exception ex)
            {
            }



            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(municipios));

        }
        public ViewResult ViewPartialException(string Message)
        {
            return View("~/Views/Home/ErrorPartial.cshtml", new 
            {
                TituloError = "HA OCURRIDO UN ERROR AL CARGAR PÁGINA",
                DetalleError = Message
            });
        }

        [HttpGet]
        public JsonResult ValidarCaso(string idCaso)
        {
            CargaDataCasoCE _casoDAO = new CargaDataCasoCE();
            bool esValido = _casoDAO.ValidarCaso(idCaso);
            return Json(esValido, JsonRequestBehavior.AllowGet);
        }

    }
}