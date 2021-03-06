﻿using GradingSystem;
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

    public partial class StudentProfileInfo : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private List<object> logBookCLOs = new List<object>(20);
        private List<object> reportCLOs = new List<object>(20);
        private List<object> evaluationCLOs = new List<object>(20);
        private double logBookMarks = 0.0;
        private double reportMarks = 0.0;
        private double evaluationMidMarks = 0.0;
        private double evaluationFinalMarks = 0.0;
        private int groupID;
        private string errorString = "";
        private string error = "All CLO(s) are not marked yet";
        private bool isSkipTrue = false;
        string n;
        string i;
        string E;

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
                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                sname.InnerText = n;
                sname1.InnerText = n;
            }


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterStudent inner join RegisterSupervisor on RegisterStudent.SupervisorID = RegisterSupervisor.Email inner join Groups on RegisterStudent.GroupID = Groups.Id where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    enroll.InnerText = reader.GetString(0);
                    stdname.InnerText = reader.GetString(1);
                    regnum.InnerText = reader.GetString(2);
                    fname.InnerText = reader.GetString(3);
                    inst.InnerText = reader.GetString(6);
                    class1.InnerText = reader.GetString(10);
                    mobnum.InnerText = reader.GetString(4);
                    pemail.InnerText = reader.GetString(5);
                    fyptitle.InnerText = reader.GetString(13);
                    supervisorname.InnerText = reader.GetString(15);
                }
            }
            reader.Close();
            con.Close();
            CheckForGrades();
        }

        private void FetchCLOs()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id,Name from CLO order by CLONumber", con);
            da.Fill(dt);
            con.Close();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow clo in dt.Rows)
                    {
                        if (clo["Name"].ToString() == "CLO 8")
                        {
                            reportCLOs.Add(clo["Id"]);
                        }
                        else if (clo["Name"].ToString() == "CLO 9")
                        {
                            logBookCLOs.Add(clo["Id"]);
                        }
                        else if (clo["Name"].ToString() == "CLO 10")
                        {
                            reportCLOs.Add(clo["Id"]);
                        }
                        else if (clo["Name"].ToString() == "CLO 11")
                        {
                            logBookCLOs.Add(clo["Id"]);
                        }
                        else
                        {
                            evaluationCLOs.Add(clo["Id"]);
                        }
                    }
                }
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
                grade.InnerText = errorString;
                CGPA.InnerText = errorString;
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

            double finalMarks = logBookMarks + reportMarks + finalMidEvaluationMarks + finalEvaluationMarks;

            string grade1 = Grades.CalculateGrade(finalMarks);
            double cgpa = Grades.CalculateCGPA(grade1);

            grade.InnerText = grade1;

            CGPA.InnerText = cgpa.ToString();
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
                    isSkipTrue = true;
                }
            }
            else
            {
                errorString = errorMessage;
                isSkipTrue = true;
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
                        reportMarks += Convert.ToDouble(clo["Marks"]);
                    }
                }
                else
                {
                    errorString = errorMessage;
                    isSkipTrue = true;
                }
            }
            else
            {
                errorString = errorMessage;
                isSkipTrue = true;
            }
            con.Close();
        }

        private void LogBookMarks(string marksFor, string errorMessage)
        {
            if (isSkipTrue)
            {
                return;
            }
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
                        logBookMarks += Convert.ToDouble(clo["Marks"]);
                    }
                }
                else
                {
                    errorString = errorMessage;
                    isSkipTrue = true;
                }
            }
            else
            {
                errorString = errorMessage;
                isSkipTrue = true;
            }
            con.Close();
        }

    }
}
