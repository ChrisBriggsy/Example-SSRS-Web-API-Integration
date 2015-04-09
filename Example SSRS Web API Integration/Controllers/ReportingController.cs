using System;
using System.IO;
using System.Web;
using System.Web.Http;
using Microsoft.Reporting.WebForms;

namespace Example_SSRS_Web_API_Integration.Controllers
{
    public class ReportingController : ApiController
    {
        public byte[] SaveReport(string ReportResourcePath, ReportDataSource[] DataSources, ReportParameter[] ReportParameters)
        {
            byte[] bytes;
            using (var reportViewer = new ReportViewer())
            {
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportEmbeddedResource = ReportResourcePath;

                foreach (var dataSource in DataSources) { 
                    reportViewer.LocalReport.DataSources.Add(dataSource);
                }

                reportViewer.LocalReport.SetParameters(ReportParameters);


                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                bytes = reportViewer.LocalReport.Render("Pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            }

            return bytes;
        }

    }
}