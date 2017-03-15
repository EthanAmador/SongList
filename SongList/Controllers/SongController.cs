using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.DataBase.Conexion;
using Core.DataBase.Entity; 

namespace SongList.Controllers
{
    public class SongController : ApiController
    {
        [HttpGet]
        [Route("artis/list")]
        public HttpResponseMessage GetArtis(string p_name= null)
        {

            try
            {
                var result = AccesDataBase.ExecuteProcedure<Artist>("Music.pr_Artist_List",
                                        new Dictionary<string, object>() { { "iVch_name", p_name } });

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {

                var result = AccesDataBase.ExecuteProcedure<Artist>("Music.pr_Artist_List",
                                        new Dictionary<string, object>() { { "iVch_name", p_name } });

                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            
        }
    }
}
