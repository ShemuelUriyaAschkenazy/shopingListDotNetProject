using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class ListToPdfCreator
    {
        public void createPdf<T>(List<T> list, string header)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("David", 15, XFontStyle.Regular);
            XFont font2 = new XFont("David", 20, XFontStyle.Bold);

            graph.DrawString(header, font2, XBrushes.Black,
                new XRect(0, font2.Size * 1.001, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            for (int i = 0; i < list.Count; i++)
            {
                graph.DrawString((i+1).ToString()+"."+list[i].ToString(), font, XBrushes.Black,
                new XRect(10, (font2.Size * 1.001 *2) + (i * font.Size*1.001), pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            }
            string FolderPath = new KnownFolder(KnownFolderType.Documents).Path;
            double millis = DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            string FileName = "shoping list " + millis+".pdf";
            string path= System.IO.Path.Combine(FolderPath, FileName);

            pdf.Save(path);
            Process.Start(path);
        }

    }
}
