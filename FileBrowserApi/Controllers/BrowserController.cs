using FileHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FileBrowserApi.Controllers
{
    [EnableCors(origins: "http://localhost:62101", headers: "*", methods: "*")]
    public class BrowserController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string[] info = FileBrowser.GetFixedDrives();
            if (info != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, info);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }
        public FilesData Get(string id)
        {
            if (id != null)
            {
                return FileBrowser.ReturnData(id);
            }
            else
            {
                return new object() as FilesData;
            }
        }
    }
}
