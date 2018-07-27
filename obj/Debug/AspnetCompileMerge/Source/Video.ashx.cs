using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using FitnessCenter.DAL;
using FitnessCenter.BO;
using FitnessCenter.BAL;


namespace FitnessCenter
{
    /// <summary>
    /// Summary description for Video
    /// </summary>
    public class Video : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["Id"]);
            byte[] bytes = new byte[10];
            string contentType;
            string name;

            VirtualVideo objVideo = VirtualTourController.GetVirtualVideosById(id);
            // bytes = objVideo.data;
            contentType = objVideo.ContentType;
            name = objVideo.name;

            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
            context.Response.ContentType = contentType;
            context.Response.BinaryWrite(bytes);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}