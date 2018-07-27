using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using iTextSharp.text.html;

namespace FitnessCenter
{
    public partial class AttendanceHistory : System.Web.UI.Page
    {

        #region Properties

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }

        public string SortField
        {
            get
            {
                var obj = ViewState["SortField"];
                return obj == null ? "lastCheckInDate" : (string)obj;
            }
            set
            {
                ViewState["SortField"] = value;
            }
        }

        public string SortDir
        {
            get
            {
                var obj = ViewState["SortDir"];
                return obj == null ? "ASC" : (string)obj;
            }
            set
            {
                ViewState["SortDir"] = value;
            }
        }

        public long memberId
        {
            get
            {
                var obj = ViewState["memberId"];
                return obj == null ? 0 : (long)obj;
            }
            set
            {
                ViewState["memberId"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindGrid()
        {
            try
            {
                if (ddlUsr.SelectedValue == "2" && ddlOptions.SelectedValue == "1")
                {
                    grdPresentMembers.DataSource = MembersAttendanceHistoryController.GetPresentEmployee(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdPresentMembers.DataBind();
                }
                if (ddlUsr.SelectedValue == "2" && ddlOptions.SelectedValue == "2")
                {
                    grdAbsentMembers.DataSource = MembersAttendanceHistoryController.GetAbsentEmployee(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdAbsentMembers.DataBind();
                }
                if (ddlOptions.SelectedValue == "1" && ddlUsr.SelectedValue == "1")
                {
                    grdPresentMembers.DataSource = MembersAttendanceHistoryController.GetPresentMember(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdPresentMembers.DataBind();
                }
                if (ddlOptions.SelectedValue == "2" && ddlUsr.SelectedValue == "1")
                {
                    grdAbsentMembers.DataSource = MembersAttendanceHistoryController.GetAbsentMember(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text);
                    grdAbsentMembers.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            List<GetAbsentMembersByID_Result> Absentemployee = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);
            ExportToExcel(Absentemployee);
            //BindExcel();
            //var grid = new GridView();

            //grid.DataSource = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);

            //grid.DataBind();

            //Response.ClearContent();
            //Response.AddHeader("content-disposition", "attachment; filename=iDealConfig.xls");
            //Response.ContentType = "application/excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            //grid.RenderControl(htmlTextWriter);
            //Response.Write(sw.ToString());
            //Response.End();

            //DataTable dt = new DataTable();
            //for (int i = 0; i < grdAbsentbyId.Columns.Count; i++)
            //{
            //    //dt.Columns.Add("column" + i.ToString());
            //    dt.Columns.Add(grdAbsentbyId.Columns[i].HeaderText);
            //}
            //foreach (GridViewRow row in grdAbsentbyId.Rows)
            //{
            //    DataRow dr = dt.NewRow();
            //    for (int j = 1; j <= grdAbsentbyId.Columns.Count; j++)
            //    {
            //        dr["column" + j.ToString()] = row.Cells[j].Text;
            //    }

            //    dt.Rows.Add(dr);
            //    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
            //                      Select(column => column.ColumnName);

            //    StringBuilder sb = new StringBuilder();

            //    sb.AppendLine(string.Join(",", columnNames));
            //    foreach (DataRow row1 in dt.Rows)
            //    {
            //        string[] fields = row1.ItemArray.Select(field => field.ToString()).
            //                                        ToArray();
            //        sb.AppendLine(string.Join(",", fields));
            //    }

            //    File.WriteAllText("E:\\AbsentEmployee.csv", sb.ToString());
            //}



            ////IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
            ////                      Select(column => column.ColumnName);

            ////StringBuilder sb = new StringBuilder();

            ////sb.AppendLine(string.Join(",", columnNames));


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "succ_msg", "MessageBox('Success','Excel Saved Successfully in E drive');", true);
        }
        public void BindExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;

                Response.AddHeader("content-disposition",
                "attachment;filename=" + memberId + "AbsentMember.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                var grid = new GridView();

                grid.DataSource = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);

                grid.DataBind();
                grid.AllowPaging = false;

                //Change the Header Row back to white color
                grid.HeaderRow.Style.Add("background-color", "#FFFFFF");

                //Apply style to Individual Cells
                grid.HeaderRow.Cells[0].Style.Add("background-color", "green");
                grid.HeaderRow.Cells[1].Style.Add("background-color", "green");
                grid.HeaderRow.Cells[2].Style.Add("background-color", "green");
                grid.HeaderRow.Cells[3].Style.Add("background-color", "green");
                grid.HeaderRow.Cells[4].Style.Add("background-color", "green");

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    GridViewRow row = grid.Rows[i];

                    //Change Color back to white
                    row.BackColor = System.Drawing.Color.White;

                    //Apply text style to each Row
                    row.Attributes.Add("class", "textmode");

                    //Apply style to Individual Cells of Alternating Row
                    if (i % 2 != 0)
                    {
                        row.Cells[0].Style.Add("background-color", "#C2D69B");
                        row.Cells[1].Style.Add("background-color", "#C2D69B");
                        row.Cells[2].Style.Add("background-color", "#C2D69B");
                        row.Cells[3].Style.Add("background-color", "#C2D69B");
                        row.Cells[4].Style.Add("background-color", "#C2D69B");
                    }
                }
                grid.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindPresentMemberById()
        {
            try
            {
                if (ddlOptions.SelectedValue == "1")
                {
                    grdPresentById.DataSource = MembersAttendanceHistoryController.GetPresentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);
                    grdPresentById.DataBind();
                }
                if (ddlOptions.SelectedValue == "2")
                {
                    grdAbsentbyId.DataSource = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);
                    grdAbsentbyId.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFullSearch_Click(object sender, EventArgs e)
        {
            if (ddlOptions.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Select Option First');", true);
            }
            else
            {
                if (ddlOptions.SelectedValue == "1")
                {
                    pnlPresent.Visible = true;
                    pnlAbsent.Visible = false;
                }
                else if (ddlOptions.SelectedValue == "2")
                {
                    pnlPresent.Visible = false;
                    pnlAbsent.Visible = true;
                }
                else
                {
                    pnlPresent.Visible = false;
                    pnlAbsent.Visible = false;
                }
                BindGrid();
            }
        }

        protected void grdAbsentMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAbsentMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPresentMembers_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdPresentMembers.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPresentMembers_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                SortField = e.SortExpression;
                if (SortDir == "ASC")
                    SortDir = "DESC";
                else
                    SortDir = "ASC";
                BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdPresentMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailPresent")
            {
                memberId = Convert.ToInt32(e.CommandArgument);
                BindPresentMemberById();
                grdPresentById.Focus();
                pnlAbsent.Visible = false;
                pnlPresentById.Visible = true;
                pnlPresent.Visible = true;
                pnlAbsentById.Visible = false;
            }

        }

        protected void grdAbsentMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetailAbsent")
            {
                memberId = Convert.ToInt32(e.CommandArgument);
                BindPresentMemberById();
                grdAbsentbyId.Focus();
                pnlAbsent.Visible = true;
                pnlPresentById.Visible = false;
                pnlPresent.Visible = false;
                pnlAbsentById.Visible = true;
            }
            else if (e.CommandName == "ExcelAbsent")
            {
                memberId = Convert.ToInt32(e.CommandArgument);
                BindPresentMemberById();
                BindExcel();
                grdAbsentbyId.Focus();
                pnlAbsent.Visible = true;
                pnlPresentById.Visible = false;
                pnlPresent.Visible = false;
                pnlAbsentById.Visible = true;
            }
        }

        protected void grdPresentMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            if (Edit != null)
            {
                if (LoginUser.UserTypeId != 2)
                {
                    Edit.Visible = false;
                }
                else
                    Edit.Visible = true;
            }
        }

        protected void grdAbsentMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            if (Edit != null)
            {
                if (LoginUser.UserTypeId != 2)
                {
                    Edit.Visible = false;
                }
                else
                    Edit.Visible = true;
            }
        }

        protected void grdAbsentbyId_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAbsentbyId.PageIndex = e.NewPageIndex;
            BindPresentMemberById();
        }

        protected void grdAbsentbyId_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPresent")
            {
                memberId = Convert.ToInt64(e.CommandArgument);

            }
        }

        protected void grdAbsentbyId_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            if (Edit != null)
            {
                if (LoginUser.UserTypeId != 2)
                {
                    Edit.Visible = false;
                }
                else
                    Edit.Visible = true;
            }
        }

        protected void grdPresentById_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPresentById.PageIndex = e.NewPageIndex;
            BindPresentMemberById();
        }

        protected void grdPresentById_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPresent")
            {
                memberId = Convert.ToInt64(e.CommandArgument);
            }
        }

        protected void grdPresentById_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var Edit = (LinkButton)e.Row.FindControl("lnkBtnEdit");
            if (Edit != null)
            {
                if (LoginUser.UserTypeId != 2)
                {
                    Edit.Visible = false;
                }
                else
                    Edit.Visible = true;
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {

            List<GetAbsentMembersByID_Result> Absentemployee = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);
            GridView GridView1 = new GridView();
            GridView1.DataSource = Absentemployee;
            GridView1.DataBind();
            
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
                "attachment;filename=AbsentMember"+memberId+".PDF");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }

        //public static string ToString<T>(this IList<T> list, string include = "", string exclude = "")
        //{
        //    //Variables for build string
        //    string propStr = string.Empty;
        //    StringBuilder sb = new StringBuilder();

        //    //Get property collection and set selected property list
        //    PropertyInfo[] props = typeof(T).GetProperties();
        //    List<GetAbsentMembersByID_Result> Absentemployee = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);

        //    //Add list name and total count
        //    string typeName = GetSimpleTypeName(list);
        //    sb.AppendLine(string.Format("{0} List - Total Count: {1}", typeName, list.Count.ToString()));

        //    //Iterate through data list collection
        //    foreach (var item in list)
        //    {
        //        sb.AppendLine("");
        //        //Iterate through property collection
        //        foreach (var prop in Absentemployee)
        //        {
        //            //Construct property name and value string
        //            propStr = prop.MemberName + ": " + prop.MemberName;

        //            sb.AppendLine(propStr);
        //        }
        //    }
        //    return sb.ToString();
        //}
        //private static string GetSimpleTypeName<T>(IList<T> list)
        //{
        //    string typeName = list.GetType().ToString();
        //    int pos = typeName.IndexOf("[") + 1;
        //    typeName = typeName.Substring(pos, typeName.LastIndexOf("]") - pos);
        //    typeName = typeName.Substring(typeName.LastIndexOf(".") + 1);
        //    return typeName;
        //}

        //private static List<PropertyInfo> GetSelectedProperties(PropertyInfo[] props, string include, string exclude)
        //{
        //    List<PropertyInfo> propList = new List<PropertyInfo>();
        //    if (include != "") //Do include first
        //    {
        //        var includeProps = include.ToLower().Split(',').ToList();
        //        foreach (var item in props)
        //        {
        //            var propName = includeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
        //            if (!string.IsNullOrEmpty(propName))
        //                propList.Add(item);
        //        }
        //    }
        //    else if (exclude != "") //Then do exclude
        //    {
        //        var excludeProps = exclude.ToLower().Split(',');
        //        foreach (var item in props)
        //        {
        //            var propName = excludeProps.Where(a => a == item.Name.ToLower()).FirstOrDefault();
        //            if (string.IsNullOrEmpty(propName))
        //                propList.Add(item);
        //        }
        //    }
        //    else //Default
        //    {
        //        propList.AddRange(props.ToList());
        //    }
        //    return propList;
        //}


        //public static void ToExcel<T>(this IList<T> list, string include = "", string exclude = "")
        //{
        //    //Get property collection and set selected property list
        //    PropertyInfo[] props = typeof(T).GetProperties();
        //    List<PropertyInfo> propList = GetSelectedProperties(props, include, exclude);

        //    //Get simple type name
        //    string typeName = GetSimpleTypeName(list);

        //    //Convert list to array for selected properties
        //    object[,] listArray = new object[list.Count + 1, propList.Count];

        //    //Add property name to array as the first row
        //    int colIdx = 0;
        //    foreach (var prop in propList)
        //    {
        //        listArray[0, colIdx] = prop.Name;
        //        colIdx++;
        //    }
        //    //Iterate through data list collection for rows
        //    int rowIdx = 1;
        //    foreach (var item in list)
        //    {
        //        colIdx = 0;
        //        //Iterate through property collection for columns
        //        foreach (var prop in propList)
        //        {
        //            //Do property value
        //            listArray[rowIdx, colIdx] = prop.GetValue(item, null);
        //            colIdx++;
        //        }
        //        rowIdx++;
        //    }
        //    //Processing for Excel
        //    object oOpt = System.Reflection.Missing.Value;
        //    Excel.Application oXL = new Excel.Application();
        //    Excel.Workbooks oWBs = oXL.Workbooks;
        //    Excel.Workbook oWB = oWBs.Add(Excel.XlWBATemplate.xlWBATWorksheet);
        //    Excel.Worksheet oSheet = (Excel.Worksheet)oWB.ActiveSheet;
        //    oSheet.Name = typeName;
        //    Excel.Range oRng = oSheet.get_Range("A1", oOpt).get_Resize(list.Count + 1, propList.Count);
        //    oRng.set_Value(oOpt, listArray);
        //    //Open Excel
        //    oXL.Visible = true;
        //}

        public void ExportToExcel(List<GetAbsentMembersByID_Result> cars)
        {
            // Load Excel application
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            // Create empty workbook
            excel.Workbooks.Add();

            // Create Worksheet from active sheet
            Microsoft.Office.Interop.Excel._Worksheet workSheet = excel.ActiveSheet;

            // I created Application and Worksheet objects before try/catch,
            // so that i can close them in finnaly block.
            // It's IMPORTANT to release these COM objects!!
            try
            {
                // ------------------------------------------------
                // Creation of header cells
                // ------------------------------------------------
                workSheet.Cells[1, "A"] = "MemberName";
                workSheet.Cells[1, "B"] = "MobileNumber";
                workSheet.Cells[1, "C"] = "Member Id";

                // ------------------------------------------------
                // Populate sheet with some real data from "cars" list
                // ------------------------------------------------
                int row = 2; // start row (in row 1 are header cells)
                
                foreach (GetAbsentMembersByID_Result car in cars)
                {
                    workSheet.Cells[row, "A"] = car.MemberName;
                    workSheet.Cells[row, "B"] = car.mobileNumber;
                    workSheet.Cells[row, "C"] = car.membershipUniqueId;

                    row++;
                }

                // Apply some predefined styles for data to look nicely :)
                workSheet.Range["A1"].AutoFormat(Microsoft.Office.Interop.Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1);

                // Define filename
                DateTime date;
                date = DateTime.Now;

                string fileName = string.Format(@"{0}\EmpAbsent " +memberId+ ".xlsx", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

                // Save this data as a file
                workSheet.SaveAs(fileName);

                // Display SUCCESS message
                //MessageBox.Show(string.Format("The file '{0}' is saved successfully!", fileName));
            }
            catch (Exception exception)
            {
                throw exception;
                //MessageBox.Show("Exception",
                //"There was a PROBLEM saving Excel file!\n" + exception.Message,
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Quit Excel application
                excel.Quit();

                // Release COM objects (very important!)
                if (excel != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

                // Empty variables
                excel = null;
                workSheet = null;

                // Force garbage collector cleaning
                GC.Collect();
            }
        }


        //public void ExportToPdf(List<GetAbsentMembersByID_Result> myDataTable)
        //{
        //    Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
        //    try
        //    {
        //        PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
        //        pdfDoc.Open();
        //        Chunk c = new Chunk("" + System.Web.HttpContext.Current.Session["userName"] + "", FontFactory.GetFont("Verdana", 11));
        //        Paragraph p = new Paragraph();
        //        p.Alignment = Element.ALIGN_CENTER;
        //        p.Add(c);
        //        pdfDoc.Add(p);
        //        string clientLogo = Server.MapPath(".") + "/logo/tpglogo.jpg";
        //        string imageFilePath = Server.MapPath(".") + "/logo/tpglogo.jpg";
        //        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
        //        //Resize image depend upon your need   
        //        jpg.ScaleToFit(80f, 60f);
        //        //Give space before image   
        //        jpg.SpacingBefore = 0f;
        //        //Give some space after the image   
        //        jpg.SpacingAfter = 1f;
        //        jpg.Alignment = Element.HEADER;
        //        pdfDoc.Add(jpg);
        //        Font font8 = FontFactory.GetFont("ARIAL", 7);
        //        DataTable dt = myDataTable;
        //        if (dt != null)
        //        {
        //            //Craete instance of the pdf table and set the number of column in that table  
        //            PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
        //            PdfPCell PdfPCell = null;
        //            for (int rows = 0; rows < dt.Rows.Count; rows++)
        //            {
        //                for (int column = 0; column < dt.Columns.Count; column++)
        //                {
        //                    PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
        //                    PdfTable.AddCell(PdfPCell);
        //                }
        //            }
        //            //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
        //            pdfDoc.Add(PdfTable); // add pdf table to the document   
        //        }
        //        pdfDoc.Close();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment; filename= SampleExport.pdf");
        //        System.Web.HttpContext.Current.Response.Write(pdfDoc);
        //        Response.Flush();
        //        Response.End();
        //        //HttpContext.Current.ApplicationInstance.CompleteRequest();  
        //    }
        //    catch (DocumentException de)
        //    {
        //        System.Web.HttpContext.Current.Response.Write(de.Message);
        //    }
        //    catch (IOException ioEx)
        //    {
        //        System.Web.HttpContext.Current.Response.Write(ioEx.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Web.HttpContext.Current.Response.Write(ex.Message);
        //    }
        //}


        //protected void ExportDataTableToPdf()
        //{
        //    List<GetAbsentMembersByID_Result> Absentemployee = MembersAttendanceHistoryController.GetAbsentMemberById(txtSearchText.Text, SortField, SortDir, txtFromDate.Text, txtToDate.Text, memberId);

        //    GridView GridView1 = new GridView();
        //    GridView1.DataSource = Absentemployee;
        //    GridView1.DataBind();

        //    Response.Clear(); //this clears the Response of any headers or previous output
        //    Response.Buffer = true; //ma
        //    Response.ContentType = "application/pdf";

        //    Response.AddHeader("content-disposition", "attachment;filename=DataTable.pdf");

        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    StringWriter sw = new StringWriter();

        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    GridView1.RenderControl(hw);

        //    StringReader sr = new StringReader(sw.ToString());

        //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //    pdfDoc.Open();

        //    htmlparser.Parse(sr);

        //    pdfDoc.Close();


        //    Response.Write(pdfDoc);
        //    Response.End();

        //    PDFform pdfForm = new PDFform(pdfDoc, Server.MapPath("img2.gif"));

        //    // Create a MigraDoc document
        //    Document document = pdfForm.CreateDocument();
        //    document.UseCmykColor = true;

        //    // Create a renderer for PDF that uses Unicode font encoding
        //    PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

        //    // Set the MigraDoc document
        //    pdfRenderer.Document = document;


        //    // Create the PDF document
        //    pdfRenderer.RenderDocument();

        //    // Save the PDF document...
        //    string filename = "PatientsDetail.pdf";

        //    pdfRenderer.Save(filename);
        //    // ...and start a viewer.
        //    Process.Start(filename);



        //    //Response.Clear();
        //    //Response.Buffer = true;
        //    //Response.Charset = "";
        //    //Response.ContentType = "application/pdf";
        //    //Response.AddHeader("content-disposition", "attachment;filename=Products.pdf");
        //    //StringWriter sWriter = new StringWriter();
        //    //HtmlTextWriter hTWriter = new HtmlTextWriter(sWriter);
        //    //GridView1.RenderControl(hTWriter);
        //    //StringReader sReader = new StringReader(sWriter.ToString());
        //    //Document pdf = new Document(PageSize.A4);
        //    //HTMLWorker worker = new HTMLWorker(pdf);
        //    //PdfWriter.GetInstance(pdf, Response.OutputStream);
        //    //pdf.Open();
        //    //worker.Parse(sReader);
        //    //pdf.Close();
        //    //Response.Write(pdf);
        //    //Response.Flush();
        //    //Response.End();
        //}

    }
}