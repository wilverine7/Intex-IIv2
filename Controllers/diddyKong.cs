using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Mummies.Models;
using Microsoft.AspNetCore.Authorization;

namespace Mummies.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("/score")]
    [AllowAnonymous]
    public class APIController : ControllerBase
    {
        private InferenceSession _session;

        public APIController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(MumsData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First()};
            result.Dispose();
            return new JsonResult(prediction);
            
        }
    }
}
