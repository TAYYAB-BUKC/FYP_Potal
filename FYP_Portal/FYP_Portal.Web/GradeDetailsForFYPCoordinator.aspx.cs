using GradingSystem;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class GradeDetailsForFYPCoordinator : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private List<DataRow> toBeRemovedCLOs = new List<DataRow>(20);
        private List<decimal> marks = new List<decimal>(20);
        private List<DataRow> toBeRemovedGroups = new List<DataRow>(20);
        private List<int> groupsToBeShown = new List<int>(20);
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string E;
        private List<object> logBookCLOs = new List<object>(20);
        private List<object> reportCLOs = new List<object>(20);
        private List<object> evaluationCLOs = new List<object>(20);
        private double logBookMidMarks = 0.0;
        private double logBookFinalMarks = 0.0;
        private double reportMidMarks = 0.0;
        private double reportFinalMarks = 0.0;
        private double evaluationMidMarks = 0.0;
        private double evaluationFinalMarks = 0.0;
        private string errorString = "";
        private string error = "All CLO(s) are not marked yet";
        private bool isSkipTrue = false;
        string i;
        string n;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fypname"] == null)
            {
                Response.Redirect("FYPCoordinatorLogin.aspx");
            }
            else
            {
                n = Session["fypname"].ToString();
                i = Session["fypimage"].ToString();
                E = Session["fypemail"].ToString();
                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                fname.InnerText = n;
                fname1.InnerText = n;
            }

            if (!IsPostBack)
            {
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupNumber);
                groupNumber_SelectedIndexChanged(null, null);
            }
        }

        private void LoadData(string title, string query, DropDownList grp)
        {
            DataTable table = GetData(query);

            grp.DataSource = table;
            grp.DataTextField = "Name";
            grp.DataValueField = "Id";
            grp.DataBind();
        }

        private DataTable GetData(string query)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                SqlCommand command = new SqlCommand(query, sql);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(table);
            }
            catch (Exception ex)
            {

            }

            return table;
        }

        protected void groupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            controls.Visible = true;
            CheckForGrades();
        }

        private void CheckForGrades()
        {
            LogBookMarks("Mid Year Evaluation", error, groupNumber.SelectedValue);
            LogBookMarks("Final Year Evaluation", error, groupNumber.SelectedValue);
            ReportMarks("Mid Year Evaluation", error, groupNumber.SelectedValue);
            ReportMarks("Final Year Evaluation", error, groupNumber.SelectedValue);
            EvaluationMarks("Mid Year Evaluation", error, groupNumber.SelectedValue);
            EvaluationMarks("Final Year Evaluation", error, groupNumber.SelectedValue);

            if (errorString != "")
            {
                if (logBookMidMarks > 0)
                {
                    midYearLBM.InnerText = logBookMidMarks.ToString();
                }
                else
                {
                    midYearLBM.InnerText = errorString;
                }
                if (logBookFinalMarks > 0)
                {
                    finalYearLBM.InnerText = logBookFinalMarks.ToString();
                }
                else
                {
                    finalYearLBM.InnerText = errorString;
                }
                if (reportMidMarks > 0)
                {
                    midYearRM.InnerText = reportMidMarks.ToString();
                }
                else
                {
                    midYearRM.InnerText = errorString;
                }
                if (reportFinalMarks > 0)
                {
                    finalYearRM.InnerText = reportFinalMarks.ToString();
                }
                else
                {
                    finalYearRM.InnerText = errorString;
                }

                if (evaluationMidMarks > 0)
                {
                    midYearEM.InnerText = evaluationMidMarks.ToString();
                }
                else
                {
                    midYearEM.InnerText = errorString;
                }
                if (evaluationFinalMarks > 0)
                {
                    finalYearEM.InnerText = evaluationFinalMarks.ToString();
                }
                else
                {
                    finalYearEM.InnerText = errorString;
                }

                grade.InnerText = errorString;
                CGPA.InnerText = errorString;
                totalMarks.InnerText = errorString;
                marksObtained.InnerText = errorString;
                midYearEvaluationMarks.InnerText = errorString;
                finalYearEvaluationMarks.InnerText = errorString;

                ClearVariables();
            }
            else
            {
                CalculateGrade();
                ClearVariables();
            }

        }

        private void ClearVariables()
        {
            logBookMidMarks = 0.0;
            logBookFinalMarks = 0.0;
            reportMidMarks = 0.0;
            reportFinalMarks = 0.0;
            evaluationMidMarks = 0.0;
            evaluationFinalMarks = 0.0;
            errorString = "";
        }

        private void CalculateGrade()
        {
            double scalingMarksForMid = evaluationMidMarks / 50;
            double finalMidEvaluationMarks = scalingMarksForMid * 30;

            double scalingMarksForFinal = evaluationFinalMarks / 50;
            double finalEvaluationMarks = scalingMarksForFinal * 30;

            double finalMarks = logBookMidMarks + logBookFinalMarks + reportMidMarks + reportFinalMarks + finalMidEvaluationMarks + finalEvaluationMarks;
            double midYearMarks = logBookMidMarks + reportMidMarks + finalMidEvaluationMarks;
            double finalYearMarks = logBookFinalMarks + reportFinalMarks + finalEvaluationMarks;
            string grade1 = Grades.CalculateGrade(finalMarks);
            double cgpa = Grades.CalculateCGPA(grade1);

            grade.InnerText = grade1;
            CGPA.InnerText = cgpa.ToString();

            midYearLBM.InnerText = logBookMidMarks.ToString();
            finalYearLBM.InnerText = logBookFinalMarks.ToString();
            midYearRM.InnerText = reportMidMarks.ToString();
            finalYearRM.InnerText = reportFinalMarks.ToString();
            midYearEM.InnerText = finalMidEvaluationMarks.ToString();
            finalYearEM.InnerText = finalEvaluationMarks.ToString();
            midYearEvaluationMarks.InnerText = midYearMarks.ToString();
            finalYearEvaluationMarks.InnerText = finalYearMarks.ToString();
            totalMarks.InnerText = "100";
            marksObtained.InnerText = finalMarks.ToString();

        }

        private void EvaluationMarks(string marksFor, string errorMessage, string groupID)
        {
            con = new SqlConnection(connectionString);
            con.Open();

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from EvaluationMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupID;
            da.SelectCommand.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = marksFor;
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count == 10)
                {
                    foreach (DataRow clo in dt.Rows)
                    {
                        if (marksFor == "Mid Year Evaluation")
                        {
                            evaluationMidMarks += Convert.ToDouble(clo["Marks"]);
                        }
                        else
                        {
                            evaluationFinalMarks += Convert.ToDouble(clo["Marks"]);
                        }
                    }
                }
                else
                {
                    errorString = errorMessage;
                }
            }
            else
            {
                errorString = errorMessage;
            }
            con.Close();

        }

        private void ReportMarks(string marksFor, string errorMessage, string groupID)
        {
            con = new SqlConnection(connectionString);
            con.Open();

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from ReportMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupID;
            da.SelectCommand.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = marksFor;
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count == 2)
                {
                    foreach (DataRow clo in dt.Rows)
                    {
                        if (marksFor == "Mid Year Evaluation")
                        {
                            reportMidMarks += Convert.ToDouble(clo["Marks"]);
                        }
                        else
                        {
                            reportFinalMarks += Convert.ToDouble(clo["Marks"]);
                        }
                    }
                }
                else
                {
                    errorString = errorMessage;
                }
            }
            else
            {
                errorString = errorMessage;
            }
            con.Close();
        }

        private void LogBookMarks(string marksFor, string errorMessage, string groupID)
        {
            con = new SqlConnection(connectionString);
            con.Open();

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from LogBookMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupID;
            da.SelectCommand.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = marksFor;
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count == 2)
                {
                    foreach (DataRow clo in dt.Rows)
                    {
                        if (marksFor == "Mid Year Evaluation")
                        {
                            logBookMidMarks += Convert.ToDouble(clo["Marks"]);
                        }
                        else
                        {
                            logBookFinalMarks += Convert.ToDouble(clo["Marks"]);
                        }
                    }
                }
                else
                {
                    errorString = errorMessage;
                }
            }
            else
            {
                errorString = errorMessage;
            }
            con.Close();
        }

        protected void GenerateMarks_Click(object sender, EventArgs e)
        {
            #region
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S#", typeof(int));
            dataTable.Columns["S#"].AutoIncrement = true;
            dataTable.Columns["S#"].AutoIncrementSeed = 1;
            dataTable.Columns.Add("StudentEnrollments", typeof(string));
            dataTable.Columns.Add("StudentNames", typeof(string));
            dataTable.Columns.Add("SupervisorName", typeof(string));
            dataTable.Columns.Add("GroupName", typeof(string));
            dataTable.Columns.Add("Marks %", typeof(string));

            foreach (ListItem group in groupNumber.Items)
            {
                DataRow newrow = dataTable.NewRow();

                string Enrollments = "", Names = "", SName = "";
                GetStudentsData(group.Value, ref Enrollments, ref Names, ref SName);
                if (Enrollments.Length > 0)
                {
                    int Place = Enrollments.LastIndexOf(',');
                    Enrollments = Enrollments.Substring(0, Place);
                }

                if (Names.Length > 0)
                {
                    int Place = Names.LastIndexOf(',');
                    Names = Names.Substring(0, Place);
                }
                newrow[1] = Enrollments;
                newrow[2] = Names;
                newrow[3] = SName;
                newrow[4] = group.Text;

                LogBookMarks("Mid Year Evaluation", error, group.Value);
                LogBookMarks("Final Year Evaluation", error, group.Value);
                ReportMarks("Mid Year Evaluation", error, group.Value);
                ReportMarks("Final Year Evaluation", error, group.Value);
                EvaluationMarks("Mid Year Evaluation", error, group.Value);
                EvaluationMarks("Final Year Evaluation", error, group.Value);

                if (errorString != "")
                {
                    ClearVariables();
                }
                else
                {
                    double scalingMarksForMid = evaluationMidMarks / 50;
                    double finalMidEvaluationMarks = scalingMarksForMid * 30;

                    double scalingMarksForFinal = evaluationFinalMarks / 50;
                    double finalEvaluationMarks = scalingMarksForFinal * 30;

                    double finalMarks = logBookMidMarks + logBookFinalMarks + reportMidMarks + reportFinalMarks + finalMidEvaluationMarks + finalEvaluationMarks;
                    double midYearMarks = logBookMidMarks + reportMidMarks + finalMidEvaluationMarks;
                    double finalYearMarks = logBookFinalMarks + reportFinalMarks + finalEvaluationMarks;

                    finalMarks = (finalMarks / 100) * 100;

                    newrow[5] = finalMarks.ToString() + "%";

                    ClearVariables();
                }
                dataTable.Rows.Add(newrow);

            }

            #region NewCode

            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            PdfFont fontForValues = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Underline);

            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Top;
            graphics.DrawString("Department of Software Engineering", font, PdfBrushes.Black, new PointF(150, 0), format);
            graphics.DrawString("FYP Overall Year Evaluation Marks", font, PdfBrushes.Black, new PointF(145, 26), format);

            PdfLightTable table = new PdfLightTable();
            table.DataSourceType = PdfLightTableDataSourceType.External;
            table.DataSource = dataTable;
            table.Style.ShowHeader = true;
            table.Style.CellPadding = 1;
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Columns[0].Width = 30;
            table.Columns[1].Width = 130;
            table.Columns[2].Width = 130;
            table.Columns[3].Width = 90;
            table.Columns[4].Width = 90;
            table.Columns[5].Width = 40;
            table.Draw(page, new PointF(0, 55));

            document.Save("OverAll Year Evaluation Report.pdf", HttpContext.Current.Response, HttpReadType.Save);
            document.Close(true);
            #endregion

            #endregion
        }

        private void GetStudentsData(string groupID, ref string enrollments, ref string names, ref string sName)
        {

            con = new SqlConnection(connectionString);
            con.Open();

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select RegisterStudent.Enrollment,RegisterStudent.Name,RegisterSupervisor.Name as SName  from RegisterStudent inner join RegisterSupervisor on RegisterStudent.SupervisorID = RegisterSupervisor.Email where GroupID = @GroupID", con);
            da.SelectCommand.Parameters.AddWithValue("@GroupID ", SqlDbType.VarChar).Value = groupID;
            da.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow student in dt.Rows)
                    {
                        if (sName == "")
                        {
                            sName = student["SName"].ToString();
                        }
                        enrollments += student["Enrollment"].ToString() + ",";
                        names += student["Name"].ToString() + ",";
                    }
                }
            }

            con.Close();
        }

        protected void MidYearMarks_Click(object sender, EventArgs e)
        {
            #region
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S#", typeof(int));
            dataTable.Columns["S#"].AutoIncrement = true;
            dataTable.Columns["S#"].AutoIncrementSeed = 1;
            dataTable.Columns.Add("StudentEnrollments", typeof(string));
            dataTable.Columns.Add("StudentNames", typeof(string));
            dataTable.Columns.Add("SupervisorName", typeof(string));
            dataTable.Columns.Add("GroupName", typeof(string));
            dataTable.Columns.Add("Marks %", typeof(string));

            foreach (ListItem group in groupNumber.Items)
            {
                DataRow newrow = dataTable.NewRow();

                string Enrollments = "", Names = "", SName = "";
                GetStudentsData(group.Value, ref Enrollments, ref Names, ref SName);
                if (Enrollments.Length > 0)
                {
                    int Place = Enrollments.LastIndexOf(',');
                    Enrollments = Enrollments.Substring(0, Place);
                }

                if (Names.Length > 0)
                {
                    int Place = Names.LastIndexOf(',');
                    Names = Names.Substring(0, Place);
                }
                newrow[1] = Enrollments;
                newrow[2] = Names;
                newrow[3] = SName;
                newrow[4] = group.Text;

                LogBookMarks("Mid Year Evaluation", error, group.Value);
                ReportMarks("Mid Year Evaluation", error, group.Value);
                EvaluationMarks("Mid Year Evaluation", error, group.Value);

                if (errorString != "")
                {


                    ClearVariables();
                }
                else
                {
                    double scalingMarksForMid = evaluationMidMarks / 50;
                    double finalMidEvaluationMarks = scalingMarksForMid * 30;


                    double midYearMarks = logBookMidMarks + reportMidMarks + finalMidEvaluationMarks;

                    midYearMarks = (midYearMarks / 50) * 100;

                    newrow[5] = midYearMarks.ToString() + "%";

                    ClearVariables();
                }
                dataTable.Rows.Add(newrow);
            }

            #region NewCode

            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            PdfFont fontForValues = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Underline);

            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Top;
            graphics.DrawString("Department of Software Engineering", font, PdfBrushes.Black, new PointF(150, 0), format);
            graphics.DrawString("FYP Mid Year Evaluation Marks", font, PdfBrushes.Black, new PointF(145, 26), format);

            PdfLightTable table = new PdfLightTable();
            table.DataSourceType = PdfLightTableDataSourceType.External;
            table.DataSource = dataTable;
            table.Style.ShowHeader = true;
            table.Style.CellPadding = 1;
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Columns[0].Width = 30;
            table.Columns[1].Width = 130;
            table.Columns[2].Width = 130;
            table.Columns[3].Width = 90;
            table.Columns[4].Width = 90;
            table.Columns[5].Width = 40;
            table.Draw(page, new PointF(0, 55));

            document.Save("Mid Year Evaluation Report.pdf", HttpContext.Current.Response, HttpReadType.Save);
            document.Close(true);
            #endregion

            #endregion

        }

        protected void FinalYearMarks_Click(object sender, EventArgs e)
        {
            #region
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("S#", typeof(int));
            dataTable.Columns["S#"].AutoIncrement = true;
            dataTable.Columns["S#"].AutoIncrementSeed = 1;
            dataTable.Columns.Add("StudentEnrollments", typeof(string));
            dataTable.Columns.Add("StudentNames", typeof(string));
            dataTable.Columns.Add("SupervisorName", typeof(string));
            dataTable.Columns.Add("GroupName", typeof(string));
            dataTable.Columns.Add("Marks %", typeof(string));

            foreach (ListItem group in groupNumber.Items)
            {
                DataRow newrow = dataTable.NewRow();

                string Enrollments = "", Names = "", SName = "";
                GetStudentsData(group.Value, ref Enrollments, ref Names, ref SName);
                if (Enrollments.Length > 0)
                {
                    int Place = Enrollments.LastIndexOf(',');
                    Enrollments = Enrollments.Substring(0, Place);
                }

                if (Names.Length > 0)
                {
                    int Place = Names.LastIndexOf(',');
                    Names = Names.Substring(0, Place);
                }
                newrow[1] = Enrollments;
                newrow[2] = Names;
                newrow[3] = SName;
                newrow[4] = group.Text;

                LogBookMarks("Final Year Evaluation", error, group.Value);
                ReportMarks("Final Year Evaluation", error, group.Value);
                EvaluationMarks("Final Year Evaluation", error, group.Value);

                if (errorString != "")
                {
                    ClearVariables();
                }
                else
                {

                    double scalingMarksForFinal = evaluationFinalMarks / 50;
                    double finalEvaluationMarks = scalingMarksForFinal * 30;

                    double finalYearMarks = logBookFinalMarks + reportFinalMarks + finalEvaluationMarks;

                    finalYearMarks = (finalYearMarks / 50) * 100;

                    newrow[5] = finalYearMarks.ToString() + "%";

                    ClearVariables();
                }
                dataTable.Rows.Add(newrow);
            }

            #region NewCode

            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.TimesRoman, 11);
            PdfFont fontForValues = new PdfStandardFont(PdfFontFamily.TimesRoman, 11, PdfFontStyle.Underline);

            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Top;
            graphics.DrawString("Department of Software Engineering", font, PdfBrushes.Black, new PointF(150, 0), format);
            graphics.DrawString("FYP Final Year Evaluation Marks", font, PdfBrushes.Black, new PointF(145, 26), format);

            PdfLightTable table = new PdfLightTable();
            table.DataSourceType = PdfLightTableDataSourceType.External;
            table.DataSource = dataTable;
            table.Style.ShowHeader = true;
            table.Style.CellPadding = 1;
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            table.Columns[0].Width = 30;
            table.Columns[1].Width = 130;
            table.Columns[2].Width = 130;
            table.Columns[3].Width = 90;
            table.Columns[4].Width = 90;
            table.Columns[5].Width = 40;
            table.Draw(page, new PointF(0, 55));

            document.Save("Final Year Evaluation Report.pdf", HttpContext.Current.Response, HttpReadType.Save);
            document.Close(true);
            #endregion

            #endregion

        }


    }
}