using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FYP_Portal.Web
{
    public partial class ReportSheet : Page
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
        string name, designation;
        int counter;
        string i;
        string n;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorname"] == null)
            {
                Response.Redirect("SupervisorLogin.aspx");
            }
            else
            {
                n = Session["supervisorname"].ToString();
                i = Session["supervisorimage"].ToString();
                E = Session["supervisoremail"].ToString();
                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                spname.InnerText = n;
                spname1.InnerText = n;
            }

            if (!IsPostBack)
            {
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupNumber);
                groupNumber_SelectedIndexChanged(null, null);
                studentName_SelectedIndexChanged(null, null);
                PopulateGridview();
                controls.Visible = false;
            }
            studentName.Visible = false;
            stdLabel.Visible = false;
            populateMarks();
        }

        private void PopulateGridview()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id,Name as perind,OutStanding as outs,Good as good, Average as avg, Satisfactory as satis,Poor as poor,Fail as fail from CLO order by CLONumber", con);
            da.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                if (row["perind"].ToString() == "CLO 8" || row["perind"].ToString() == "CLO 10")
                {

                }
                else
                {
                    toBeRemovedCLOs.Add(row);
                }
            }

            foreach (var row in toBeRemovedCLOs)
            {
                dt.Rows.Remove(row);
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    controls.Visible = true;
                    MessageLabel.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.FooterRow.Cells[5].Text = "Total (10 Marks)";
                }
                else
                {
                    controls.Visible = false;
                    MessageLabel.Visible = true;
                    MessageLabel.Text = "CLO(s) are not added yet for Assessment";
                    MessageLabel.ForeColor = Color.Red;
                }
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

        protected void studentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select FYPTitle from RegisterStudent where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = studentName.SelectedValue;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    fyptitle.Text = reader.GetString(0);
                }
            }
            populateMarks();

        }

        private void populateMarks()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                var rowIndex = row.RowIndex;

                var cloID = GridView1.DataKeys[row.RowIndex]["Id"].ToString();

                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("select isNull(avg(Marks),0) from ReportMarks where Group_Id = @Group_Id and CLO_Id = @CLO_Id and MarksFor = @MarksFor", con);

                cmd.Parameters.AddWithValue("@Group_Id", SqlDbType.Int).Value = groupNumber.SelectedValue;
                cmd.Parameters.AddWithValue("@CLO_Id", SqlDbType.Int).Value = cloID;
                cmd.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = reports.SelectedItem.ToString();

                SqlDataReader reader1 = cmd.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        marks.Add(Convert.ToInt32(reader1.GetDecimal(0)));
                        row.Cells[8].Text = reader1.GetDecimal(0).ToString();
                    }
                }
            }
        }

        protected void groupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select Enrollment as Id,Name from RegisterStudent where GroupID = @GroupID", con);
            cmd.Parameters.AddWithValue("@GroupID", SqlDbType.VarChar).Value = groupNumber.SelectedValue;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                studentName.DataSource = table;
                studentName.DataTextField = "Name";
                studentName.DataValueField = "Id";
                studentName.DataBind();
                studentName_SelectedIndexChanged(null, null);
            }
        }

        protected void GenerateReport_Click(object sender, EventArgs e)
        {

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

            graphics.DrawString("Department of Software Engineering", font, PdfBrushes.Black, new PointF(155, 15), format);
            graphics.DrawString("Final Year Project Rubrics", font, PdfBrushes.Black, new PointF(180, 30), format);
            graphics.DrawString("FYP Report Evaluation Sheet", font, PdfBrushes.Black, new PointF(165, 45), format);
            graphics.DrawString("Group Name: ", font1, PdfBrushes.Black, new PointF(10, 100), format);
            graphics.DrawString(groupNumber.SelectedItem.ToString(), fontForValues, PdfBrushes.Black, new PointF(75, 100), format);
            graphics.DrawString("FYP Title: ", font1, PdfBrushes.Black, new PointF(10, 120), format);
            graphics.DrawString(fyptitle.Text, fontForValues, PdfBrushes.Black, new PointF(60, 120), format);
            graphics.DrawString("GROUP MEMBERS INFORMATION", font1, PdfBrushes.Black, new PointF(300, 80), format);

            PdfLightTable studentsTable = new PdfLightTable();
            studentsTable.DataSourceType = PdfLightTableDataSourceType.External;
            studentsTable.DataSource = GetStudents();
            studentsTable.Style.ShowHeader = true;
            studentsTable.Style.CellPadding = 2;
            studentsTable.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            studentsTable.Draw(page, new PointF(250, 100));

            PdfLightTable table = new PdfLightTable();
            table.DataSourceType = PdfLightTableDataSourceType.External;
            table.DataSource = GetData();
            table.Style.ShowHeader = true;
            table.Style.CellPadding = 4;
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Draw(page, new PointF(0, 170));

            graphics.DrawString("___________________", font1, PdfBrushes.Black, new PointF(0, 350), format);
            graphics.DrawString(" Signature of Evaluator", font1, PdfBrushes.Black, new PointF(0, 363), format);

            graphics.DrawString("_________________________", font1, PdfBrushes.Black, new PointF(380, 350), format);
            graphics.DrawString(" Signature of FYP Coordinator", font1, PdfBrushes.Black, new PointF(380, 363), format);

            document.Save(groupNumber.SelectedItem.ToString() + ".pdf", HttpContext.Current.Response, HttpReadType.Save);
            document.Close(true);
            #endregion
        }

        private object GetStudents()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select Enrollment as 'Enrollment #',Name from RegisterStudent where GroupID = @GroupID", con);

            cmd.Parameters.AddWithValue("@GroupID", SqlDbType.VarChar).Value = groupNumber.SelectedValue;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return new DataTable();
            }
        }

        private DataTable GetData()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Name + ':                   (' +Description+')' as 'Performance Indicator',OutStanding,Good,Average,Satisfactory,Poor,Fail from CLO order by CLONumber", con);
            da.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                int index = row["Performance Indicator"].ToString().LastIndexOf(':');
                string clo = row["Performance Indicator"].ToString().Substring(0, index);

                if (clo == "CLO 8" || clo == "CLO 10")
                {

                }
                else
                {
                    toBeRemovedCLOs.Add(row);
                }
            }

            foreach (var row in toBeRemovedCLOs)
            {
                dt.Rows.Remove(row);
            }

            if (dt != null)
            {
                dt.Columns.Add("Points", typeof(decimal));
                foreach (DataRow row in dt.Rows)
                {
                    row["Points"] = marks[counter];
                    counter++;
                }
                return dt;
            }
            else
            {
                return new DataTable();
            }

        }

        private void FetchValues()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select Name,Designation from FYPCoordinatorLogin where PersonalEmail = @Email", con);
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    name = reader.GetString(0);
                    designation = reader.GetString(1);
                }
            }
        }

        protected void reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reports.SelectedIndex == 0)
            {
                controls.Visible = false;
                return;
            }
            controls.Visible = true;
        }
    }
}