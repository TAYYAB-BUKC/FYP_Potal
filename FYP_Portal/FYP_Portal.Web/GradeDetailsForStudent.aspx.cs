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
	public partial class GradeDetailsForStudent : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private List<object> logBookCLOs = new List<object>(20);
        private List<object> reportCLOs = new List<object>(20);
        private List<object> evaluationCLOs = new List<object>(20);
        private double logBookMidMarks = 0.0;
        private double logBookFinalMarks = 0.0;
        private double reportMidMarks = 0.0;
        private double reportFinalMarks = 0.0;
        private double evaluationMidMarks = 0.0;
        private double evaluationFinalMarks = 0.0;
        private int groupID = 0;
        private string errorString = "";
        private string error = "All CLO(s) are not marked yet";
        private bool isSkipTrue = false;
        string E;
        string i;
        string n;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                n = Session["name"].ToString();
                i = Session["image"].ToString();
                E = Session["enroll"].ToString();
                groupID = FetchGroup(E);
                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;

                sname.InnerText = n;
                sname1.InnerText = n;
            }
            CheckForGrades();
        }

        private int FetchGroup(string Enrollment)
        {
            int s = 0;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select GroupID from RegisterStudent where Enrollment = @Enrollment", con);

            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = Enrollment;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    s = reader.GetInt32(0);
                }
                return s;
            }
            else
            {
                return s;
            }
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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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

        private void ReportMarks(string marksFor, string errorMessage)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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

        private void LogBookMarks(string marksFor, string errorMessage)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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

    }
}