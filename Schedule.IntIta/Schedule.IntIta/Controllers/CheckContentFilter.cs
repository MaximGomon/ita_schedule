using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Schedule.IntIta.Controllers
{
    public class CheckContentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            using (var stream = new MemoryStream())
            {
                context.HttpContext.Request.Body.CopyTo(stream);
                stream.Position = 0;
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                var text = Encoding.Default.GetString(bytes);

            }
        }
    }
}