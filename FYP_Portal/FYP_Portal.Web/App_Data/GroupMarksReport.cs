//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupMarksReport
/// </summary>
public class GroupMarksReport
{
    //#region Decalration
    //int totalColumns = 5;
    //Document document;
    //Font font;
    //PdfPTable table = new PdfPTable(5);
    //PdfPCell cell;
    //MemoryStream memoryStream = new MemoryStream();
    //private DataTable data;
    //#endregion

    //public byte[] PrepareReport(DataTable details)
    //{
    //    data = details;

    //    #region Initialization
    //    document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
    //    document.SetPageSize(PageSize.A4);
    //    document.SetMargins(20f, 20f, 20f, 20f);
    //    table.WidthPercentage = 100;
    //    table.HorizontalAlignment = Element.ALIGN_CENTER;
    //    font = FontFactory.GetFont("Times New Roman", 8f, 1);
    //    PdfWriter.GetInstance(document, memoryStream);
    //    document.Open();
    //    table.SetWidths(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f });
    //    #endregion

    //    ReportHeaders();
    //    ReportBody();
    //    table.HeaderRows = 2;
    //    document.Add(table);
    //    document.Close();
    //    return memoryStream.ToArray();
    //}

    //private void ReportHeaders()
    //{
    //    font = FontFactory.GetFont("Times New Roman", 30f, 1);
    //    cell = new PdfPCell(new Phrase("MID YEAR EVALUATION RESULT", font));
    //    cell.Colspan = totalColumns;
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.Border = 0;
    //    cell.BackgroundColor = BaseColor.WHITE;
    //    cell.ExtraParagraphSpace = 0;
    //    table.AddCell(cell);
    //    table.CompleteRow();

    //}
    //private void ReportBody()
    //{
    //    #region TableHeaders
    //    font = FontFactory.GetFont("Times New Roman", 9f, 1);
    //    cell = new PdfPCell(new Phrase("Enrollment #", font));
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
    //    table.AddCell(cell);

    //    cell = new PdfPCell(new Phrase("Name", font));
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
    //    table.AddCell(cell);

    //    cell = new PdfPCell(new Phrase("Supervisor Name", font));
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
    //    table.AddCell(cell);

    //    cell = new PdfPCell(new Phrase("Group Name", font));
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
    //    table.AddCell(cell);

    //    cell = new PdfPCell(new Phrase("Mid Marks %", font));
    //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
    //    table.AddCell(cell);

    //    table.CompleteRow();
    //    #endregion

    //    #region
    ////    font = FontFactory.GetFont("Times New Roman", 11f, 1);


    ////    foreach (var d in data.Rows)
    ////    {
    ////        cell = new PdfPCell(new Phrase(d.ProductName, font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.RimNo.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.ClientName, font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.LoanAmount.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);


    ////        cell = new PdfPCell(new Phrase(d.DisbursedDate.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.Duration.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.MaturityDate.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.OutstandingCapital.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);

    ////        cell = new PdfPCell(new Phrase(d.UnsatisfiedInterest.ToString(), font));
    ////        cell.HorizontalAlignment = Element.ALIGN_CENTER;
    ////        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
    ////        cell.BackgroundColor = BaseColor.WHITE;
    ////        table.AddCell(cell);
    ////        table.CompleteRow();
    ////    }

    //    #endregion
    //}
}
