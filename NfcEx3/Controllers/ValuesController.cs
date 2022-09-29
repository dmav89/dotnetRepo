using NPFEx3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace NPFEx3.Controllers
{
    public class ValuesController : ApiController
    {
        public ActionResult Get(string value)
        {
            JsonResult result = new JsonResult();
            MultipleModel model = new MultipleModel(value);
            result.Data = new { res = model.GetMultipleResult() };
            return result;
           // return Json(new { result = model.GetMultipleResult() });
        }

    }
}
