using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using System.IO;
namespace TryModuleFilterApp.Handlers
{
    public class ImageHandler : IHttpHandler
    {
        // This method processes the request and generates the response.
        public void ProcessRequest(HttpContext context)
        {
            // Extract the image ID from the URL
            
            string imageId = context.Request.QueryString["id"];

            // Generate the file path (you can use a database or filesystem)
            string filePath = context.Server.MapPath("~/Images/" + imageId + ".jpg");

            if (File.Exists(filePath))
            {
                // Read the image data and output it to the response stream
                context.Response.ContentType = "image/jpeg";  // Set the appropriate content type for the image
                context.Response.TransmitFile(filePath);      // Send the file to the client
            }
            else
            {
                // Handle the case where the image is not found
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "Image Not Found";
                context.Response.Write("Image not found.");
            }
        }

        // This property determines whether the handler can be reused.
        public bool IsReusable
        {
            get { return false; }  // In this case, the handler is not reusable
        }

    }
}