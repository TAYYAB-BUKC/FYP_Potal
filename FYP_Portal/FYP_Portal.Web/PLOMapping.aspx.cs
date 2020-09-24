using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class PLOMapping : System.Web.UI.Page
	{
        StringBuilder htmlTable = new StringBuilder();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private List<int> id;
        private List<string> existingCloNames;
        private List<string> ploName;
        private List<string> description;
        private List<string> test;
        private List<string> toBeRemovedColumns = new List<string>(20);
        private List<bool> mappedCLO;
        private int counter = 1;
        string i;
        string n;
        string E;

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

            htmlTable.AppendLine("<table class='table table-bordered table-condensed info table-responsive tableCol4'> ");

            LoadHeaders();

            foreach (var plo in ploName)
            {
                LoadMapping(plo);
            }
            htmlTable.AppendLine("</table>");
            litTable.Text = htmlTable.ToString();


        }

        private void LoadHeaders()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("select Name from CLO order by CLONumber", sql);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                sql.Close();
            }
            catch (Exception ex)
            {

            }

            if (table.Rows.Count > 0)
            {
                id = new List<int>(table.Rows.Count);
                existingCloNames = new List<string>(table.Rows.Count);

                htmlTable.AppendLine("<tr>");
                htmlTable.AppendLine("<th>PLO(s)</th>");

                foreach (DataRow row in table.Rows)
                {
                    htmlTable.AppendLine("<td style='text-align: center'>" + row["Name"].ToString() + " </td>");
                    id.Add(counter);
                    existingCloNames.Add(row["Name"].ToString());
                    counter++;
                }

            }

            DataTable table1 = new DataTable();
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("select Name,Description from PLO order by PLONumber", sql);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table1);
                sql.Close();
            }
            catch (Exception ex)
            {

            }

            if (table1.Rows.Count > 0)
            {
                ploName = new List<string>(table1.Rows.Count);

                foreach (DataRow row in table1.Rows)
                {
                    ploName.Add(row["Name"].ToString() + ": " + row["Description"].ToString());
                    counter++;
                }
            }

            htmlTable.AppendLine("</tr>");
        }

        private void LoadMapping(string name)
        {
            int index = name.LastIndexOf(':');
            string plo = name.Substring(0, index);
            DataTable dataTable = GetData(plo);
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    var col = column.ColumnName;

                    if (col == "CLO 1")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);
                        }
                    }
                    else if (col == "CLO 2")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);
                        }
                    }
                    else if (col == "CLO 3")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 4")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 5")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 6")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 7")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 8")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 9")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 10")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 11")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);

                        }
                    }
                    else if (col == "CLO 12")
                    {
                        bool check = existingCloNames.Contains(col);
                        if (!check)
                        {
                            toBeRemovedColumns.Add(col);
                        }
                    }

                }
            }

            foreach (var c in toBeRemovedColumns)
            {
                dataTable.Columns.Remove(c);
            }

            if (dataTable.Rows.Count > 0)
            {
                htmlTable.AppendLine("<tr>");
                htmlTable.AppendLine("<th>" + name + "</th>");

                foreach (DataRow row in dataTable.Rows)
                {
                    DataColumnCollection columns = dataTable.Columns;
                    if (columns.Contains("CLO 1"))
                    {
                        if (Convert.ToInt32(row["CLO 1"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }

                    }
                    if (columns.Contains("CLO 2"))
                    {
                        if (Convert.ToInt32(row["CLO 2"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }

                    }
                    if (columns.Contains("CLO 3"))
                    {
                        if (Convert.ToInt32(row["CLO 3"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 4"))
                    {

                        if (Convert.ToInt32(row["CLO 4"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 5"))
                    {

                        if (Convert.ToInt32(row["CLO 5"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 6"))
                    {

                        if (Convert.ToInt32(row["CLO 6"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 7"))
                    {

                        if (Convert.ToInt32(row["CLO 7"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 8"))
                    {

                        if (Convert.ToInt32(row["CLO 8"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 9"))
                    {

                        if (Convert.ToInt32(row["CLO 9"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 10"))
                    {

                        if (Convert.ToInt32(row["CLO 10"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 11"))
                    {

                        if (Convert.ToInt32(row["CLO 11"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                    if (columns.Contains("CLO 12"))
                    {

                        if (Convert.ToInt32(row["CLO 12"]) == 0)
                        {
                            htmlTable.AppendLine("<td> </td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td style='text-align: center'> <span>&#10003;</span> </td>");
                        }
                    }
                }
                htmlTable.AppendLine("</tr>");
            }

            toBeRemovedColumns.Clear();
        }

        private DataTable GetData(string value)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                sql.Open();
                SqlCommand command = new SqlCommand("select * from CLOPLOMapping where PLO=@PLOId", sql);
                command.Parameters.AddWithValue("@PLOId", value);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                sql.Close();
            }
            catch (Exception ex)
            {

            }

            return table;
        }
    }
}