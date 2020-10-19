using GradingSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class GradeDetaisForSupervisor : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            var n = Session["supervisorname"].ToString();
            var i = Session["supervisorimage"].ToString();
            var E = Session["supervisoremail"].ToString();
            email.Text = E;
            email.Visible = false;
            profileImage.Src = i;
            p.Src = i;
            profileImage1.Src = i;
            p1.Src = i;
            spname.InnerText = n;
            spname1.InnerText = n;


            if (!IsPostBack)
            {
                FetchGroups(E);
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupNumber);
                groupNumber_SelectedIndexChanged(null, null);
            }
        }

        private void FetchGroups(string spID)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select distinct(GroupID) from RegisterStudent where SupervisorID= @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = spID;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    groupsToBeShown.Add(reader.GetInt32(0));
                }
            }
        }

        private void LoadData(string title, string query, DropDownList grp)
        {
            DataTable table = GetData(query);

            foreach (DataRow row in table.Rows)
            {
                int a = Convert.ToInt32(row["Id"]);
                bool check = groupsToBeShown.Contains(a);
                if (!check)
                {
                    toBeRemovedGroups.Add(row);
                }
            }
            foreach (var row in toBeRemovedGroups)
            {
                table.Rows.Remove(row);
            }

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
                //  MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LogBookMarks("Mid Year Evaluation", error);
            LogBookMarks("Final Year Evaluation", error);
            ReportMarks("Mid Year Evaluation", error);
            ReportMarks("Final Year Evaluation", error);
            EvaluationMarks("Mid Year Evaluation", error);
            EvaluationMarks("Final Year Evaluation", error);

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

            }
            else
            {
                CalculateGrade();
            }

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

        private void EvaluationMarks(string marksFor, string errorMessage)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from EvaluationMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupNumber.SelectedValue;
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

        private void ReportMarks(string marksFor, string errorMessage)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from ReportMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupNumber.SelectedValue;
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

        private void LogBookMarks(string marksFor, string errorMessage)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select CLO_Id,ISNULL(AVG(Marks),0) as Marks from LogBookMarks where MarksFor = @MarksFor and Group_Id = @Group_Id group by CLO_Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupNumber.SelectedValue;
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

    }
}