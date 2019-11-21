using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace E_Pahal
{
    public partial class frm_Subscription : Form
    {

        public static Boolean SaveMode = true;

        public frm_Subscription()
        {
            InitializeComponent();
        }

        private void frm_Subscription_Load(object sender, EventArgs e)
        {
            txt_formnum.Text = clsAutoNumber.SerialNumber("formid", "Epahal_form", "");
            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Notice = "";
                string Year = "";
                string Cash = "";

                if (rb_supply.Checked == true)
                {
                    Notice = "Supply";
                }
                else if (rb_construction.Checked == true)
                {
                    Notice = "Construction";
                }
                else if (rb_consultancy.Checked == true)
                {
                    Notice = "Consultancy";
                }

                if (rb_year1.Checked == true)
                {
                    Year = "One Year";
                }
                else if (rb_year2.Checked == true)
                {
                    Year = "Two Year";
                }
                else if (rb_year3.Checked == true)
                {
                    Year = "Three Year";
                }
                else if (rb_year5.Checked == true)
                {
                    Year = "Five Year";
                }

                if (txt_cash.Checked == true)
                {
                    Cash = "Cash";
                }
                else
                {
                    Cash = "Not Cash";
                }

                if (txt_orgName.Text == "")
                {
                    errorProvider_Subscription.SetError(txt_orgName, "Can't left blank.");
                    txt_orgName.Focus();
                }
                else if (dtp_startDate.Text == "")
                {
                    errorProvider_Subscription.SetError(dtp_startDate, "Invalid Date Format.");
                    dtp_startDate.Focus();
                }
                else
                {
                    if (SaveMode == true)
                    {
                        if (txt_formnum.Text == "")
                            MessageBox.Show("Can't save without Form Number", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            cls_Subscription.SaveForm1(txt_formnum.Text, txt_invoice.Text, txt_receipt.Text, txt_orgName.Text, txt_orgAdd.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_email.Text, Notice, dtp_startDate.Text, Year, dtp_ExpireDate.Text, txt_PaidBy.Text, txt_ReceivedBy.Text, txt_CheckedBy.Text, txt_fdbck.Text, txt_rmark.Text, txt_amount.Text, dtp_recDate.Text, Cash, txt_chequeNo.Text, txt_depositeby.Text, txt_BankName.Text, txt_referedBy.Text);
                            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                            btn_reset.Focus();
                            SaveMode = false;
                        }
                    }
                    else if (SaveMode == false)
                    {
                        DialogResult drUpdate;
                        drUpdate = MessageBox.Show("Do you want to Update?", GlobalConnection.ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (drUpdate == DialogResult.Yes)
                        {
                            cls_Subscription.UpdateForm1(txt_formnum.Text, txt_invoice.Text, txt_receipt.Text, txt_orgName.Text, txt_orgAdd.Text, txt_orgPhone.Text, txt_orgFirst.Text, txt_orgFirstMobile.Text, txt_contactPerson.Text, txt_contactPersonMobile.Text, txt_email.Text, Notice, dtp_startDate.Text, Year, dtp_ExpireDate.Text, txt_PaidBy.Text, txt_ReceivedBy.Text, txt_CheckedBy.Text, txt_fdbck.Text, txt_rmark.Text, txt_amount.Text, dtp_recDate.Text, txt_cash.Text, txt_chequeNo.Text, txt_depositeby.Text, txt_BankName.Text, txt_referedBy.Text);
                            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                            btn_reset.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            SaveMode = true;
            txt_formnum.ResetText();
            txt_invoice.ResetText();
            txt_receipt.ResetText();
            txt_orgName.ResetText();
            txt_orgAdd.ResetText();
            txt_orgPhone.ResetText();
            txt_orgFirst.ResetText();
            txt_orgFirstMobile.ResetText();
            txt_contactPerson.ResetText();
            txt_contactPersonMobile.ResetText();
            txt_email.ResetText();
            rb_supply.Checked = false;
            rb_construction.Checked = false;
            rb_consultancy.Checked = false;
            dtp_startDate.ResetText();
            rb_year1.Checked = false;
            rb_year2.Checked = false;
            rb_year3.Checked = false;
            rb_year5.Checked = false;
            dtp_ExpireDate.ResetText();
            txt_amount.ResetText();
            dtp_recDate.ResetText();
            txt_cash.Checked = false;
            txt_chequeNo.ResetText();
            txt_depositeby.ResetText();
            txt_BankName.ResetText();
            txt_referedBy.ResetText();
            txt_PaidBy.ResetText();
            txt_ReceivedBy.ResetText();
            txt_CheckedBy.ResetText();
            txt_fdbck.ResetText();
            txt_rmark.ResetText();
            txt_orgName.Focus();
            txt_formnum.Text = clsAutoNumber.SerialNumber("formid", "Epahal_form", "");
        }

        private void dgv_subscriber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button2.Enabled = true;
                txt_formnum.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Form No."].Value.ToString();
                txt_invoice.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Invoice No."].Value.ToString();
                txt_receipt.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Receipt No."].Value.ToString();
                txt_orgName.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Name of Organization"].Value.ToString();
                txt_orgAdd.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Address of Organization"].Value.ToString();
                txt_orgPhone.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Phone No."].Value.ToString();
                txt_orgFirst.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["First Person of Organization"].Value.ToString();
                txt_orgFirstMobile.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["First Person Mobile"].Value.ToString();
                txt_contactPerson.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Contact Person"].Value.ToString();
                txt_contactPersonMobile.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Mobile No."].Value.ToString();
                txt_email.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Receiving Email Address"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Type of Notice Required"].Value.ToString() == "Supply")
                {
                    rb_supply.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Type of Notice Required"].Value.ToString() == "Construction")
                {
                    rb_construction.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Type of Notice Required"].Value.ToString() == "Consultancy")
                {
                    rb_consultancy.Checked = true;
                }
                dtp_startDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Start Date"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "One Year")
                {
                    rb_year1.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Two Year")
                {
                    rb_year2.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Three Year")
                {
                    rb_year3.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Period"].Value.ToString() == "Five Year")
                {
                    rb_year5.Checked = true;
                }
                dtp_ExpireDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Service Expiry Date"].Value.ToString();
                txt_amount.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received Amount"].Value.ToString();
                dtp_recDate.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received Amount Date"].Value.ToString();
                if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Cash"].Value.ToString() == "Cash")
                {
                    txt_cash.Checked = true;
                }
                else if ((string)dgv_subscriber.Rows[e.RowIndex].Cells["Cash"].Value.ToString() == "Not Cash")
                {
                    txt_cash.Checked = false;
                }
                txt_chequeNo.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Cheque No."].Value.ToString();
                txt_depositeby.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Bank Deposited By"].Value.ToString();
                txt_BankName.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Bank Name"].Value.ToString();
                txt_referedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Refered By"].Value.ToString();
                txt_PaidBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Paid By"].Value.ToString();
                txt_ReceivedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Received By"].Value.ToString();
                txt_CheckedBy.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Checked By"].Value.ToString();
                txt_fdbck.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Feedbacks"].Value.ToString();
                txt_rmark.Text = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                cls_Subscription.tempUpdateId = (string)dgv_subscriber.Rows[e.RowIndex].Cells["Form No."].Value.ToString();
                SaveMode = false;
            }
            catch
            { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Name(txt_namesearch.Text);
        }

        private void txt_addsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Add(txt_addsearch.Text);
        }

        private void txt_phsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Pho(txt_phsearch.Text);
        }

        private void txt_emailsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_Email(txt_emailsearch.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txt_namesearch.ResetText();
            txt_addsearch.ResetText();
            txt_phsearch.ResetText();
            txt_emailsearch.ResetText();
            dtp_startsearch.ResetText();
            dtp_expirysearch.ResetText();
            txt_namesearch.Focus();
            dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
        }
               

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveMode == true)
                {
                    DialogResult drDelete;
                    drDelete = MessageBox.Show("Select a Suscriber which you want to delete.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (drDelete == DialogResult.Yes)
                    {
                        btn_reset_Click(sender, e);
                    }
                }
                else if (SaveMode == false)
                {
                    DialogResult drDelete;
                    drDelete = MessageBox.Show("Do you really want to delete the Suscriber \"" + txt_orgName.Text + "\"?", "Confirm Suscriber deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (drDelete == DialogResult.Yes)
                    {

                        cls_Subscription.Delete(txt_formnum.Text);
                        dgv_subscriber.DataSource = cls_Subscription.LoadSubscriber();
                        btn_reset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtp_startsearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_StartDate(dtp_startDate.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = 300;
            cell.PaddingBottom = 10f;
            cell.PaddingTop = 0f;
            return cell;
        }

        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path);
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;

            return cell;
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            try
            {
                PdfContentByte contentByte = writer.DirectContent;
                contentByte.SetColorStroke(iTextSharp.text.BaseColor.BLACK);
                contentByte.MoveTo(x1, y1);
                contentByte.LineTo(x2, y2);
                contentByte.Stroke();
            }
            catch
            {

            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {

                //  DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; 
                DataTable dt_Search = cls_Subscription.Search_Particular(txt_formnum.Text);

                //Rectangle pageSize = new Rectangle(216, 720);
                //pageSize.setBackgroundColor(new BaseColor(0xFF, 0xFF, 0xDE));


                Document document = new Document(PageSize.A4, 88f, 8f, 10f, 10f);


                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".pdf", FileMode.Create));
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    iTextSharp.text.BaseColor color = null;

                    document.Open();

                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    var spacer = new Paragraph("")
                    {
                        SpacingBefore = 10f,
                        SpacingAfter = 10f,
                    };

                    

                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.SetWidths(new float[] { 5f, 5f });
                    table.SpacingBefore = 20f;


                    //Details
                    cell = PhraseCell(new Phrase("Suscriber Detail", FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.RED)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);

                    document.Add(spacer);


                    //Form No

                    table.AddCell(PhraseCell(new Phrase("Form No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Form No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.PaddingLeft = 20f;
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Invoice No
                    table.AddCell(PhraseCell(new Phrase("Invoice No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Invoice No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Receipt No
                    table.AddCell(PhraseCell(new Phrase("Receipt No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Receipt No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Name
                    table.AddCell(PhraseCell(new Phrase("Name Of Organisation:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Name of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Organization Address
                    table.AddCell(PhraseCell(new Phrase("Address of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Address of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Phone No.
                    table.AddCell(PhraseCell(new Phrase("Phone No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Phone No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person
                    table.AddCell(PhraseCell(new Phrase("First Person of Organization:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person of Organization"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Org 1st Person Mobile Np
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["First Person Mobile"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person
                    table.AddCell(PhraseCell(new Phrase("Contact Person:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Contact Person"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Contact Person Mobile
                    table.AddCell(PhraseCell(new Phrase("Mobile No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Mobile No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Email
                    table.AddCell(PhraseCell(new Phrase("Service Receiving Email Address:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Receiving Email Address"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Notice Reqd
                    table.AddCell(PhraseCell(new Phrase("Type of Notice Required:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Type of Notice Required"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //start date
                    table.AddCell(PhraseCell(new Phrase("Service Start Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Start Date"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //service period
                    table.AddCell(PhraseCell(new Phrase("Service Period:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Period"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //expire date
                    table.AddCell(PhraseCell(new Phrase("Service Expiry Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Service Expiry Date"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Amount
                    table.AddCell(PhraseCell(new Phrase("Received Amount:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Received Date
                    table.AddCell(PhraseCell(new Phrase("Received Date:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Received Amount Date"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Cash
                    table.AddCell(PhraseCell(new Phrase("Payment Mode:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cash"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    if (txt_cash.Checked == false)
                    {
                        try
                        {
                            //Cheque
                            table.AddCell(PhraseCell(new Phrase("Cheque No:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cheque No."].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank Deposite
                            table.AddCell(PhraseCell(new Phrase("Bank Deposited By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Deposited By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                            //Bank 
                            table.AddCell(PhraseCell(new Phrase("Bank Name:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Bank Name"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);

                        }
                        catch
                        {
                            //Cash
                            table.AddCell(PhraseCell(new Phrase("Payment Mode:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Cash"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = 50;
                            table.HorizontalAlignment = 200;
                            cell.PaddingBottom = 10f;
                            table.AddCell(cell);
                        }
                    }

                    //Refered By
                    table.AddCell(PhraseCell(new Phrase("Refered By:", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(dt_Search.Rows[0]["Refered By"].ToString(), FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 50;
                    table.HorizontalAlignment = 200;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    //Addtional Information
                    //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    //table.AddCell(PhraseCell(new Phrase(dr["Notes"].ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                    document.Add(table);
                    document.Close();


                    byte[] bytes = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".pdf");
                    //Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                    var blackFont = FontFactory.GetFont("Arial", "18", Font.Bold);
                    var dateTimeNow = DateTime.Now; // Return 00/00/0000 00:00:00
                    var dateOnlyString = dateTimeNow.ToShortDateString(); //Return 00/00/0000
                    using (MemoryStream stream = new MemoryStream())
                    {
                        PdfReader reader = new PdfReader(bytes);
                        using (PdfStamper stamper = new PdfStamper(reader, stream))
                        {
                            int pages = reader.NumberOfPages;
                            for (int i = 1; i <= pages; i++)
                            {
                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_CENTER, new Phrase("Page " + i.ToString() + " of " + pages, blackFont), 300f, 24f, 0);

                                ColumnText.ShowTextAligned(stamper.GetUnderContent(i),
                                @Element.ALIGN_RIGHT, new Phrase("" + dateOnlyString, blackFont), 549f, 24f, 0);
                            }
                        }

                        bytes = stream.ToArray();

                    }
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + txt_orgName.Text + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".pdf", bytes);

                    MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
            }
            catch
            {
                MessageBox.Show("PDF Report Successfully Generated in User's Desktop", GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }

        private void rb_year1_Click(object sender, EventArgs e)
        {
            dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(1).ToString("MM/dd/yyyy"));
        }

        private void rb_year2_Click(object sender, EventArgs e)
        {
            dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(2).ToString("MM/dd/yyyy"));
        }

        private void rb_year3_Click(object sender, EventArgs e)
        {
            dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(3).ToString("MM/dd/yyyy"));
        }

        private void rb_year5_Click(object sender, EventArgs e)
        {
            dtp_ExpireDate.Text = Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(5).ToString("MM/dd/yyyy"));
        }

        private void dtp_expirysearch_TextChanged(object sender, EventArgs e)
        {
            dgv_subscriber.DataSource = cls_Subscription.LoadSuscriber_EndDate(dtp_expirysearch.Text);
        }

        private void txt_invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_receipt.Focus();
            }
        }

        private void txt_receipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgName.Focus();
            }
        }

        private void txt_orgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgAdd.Focus();
            }
        }

        private void txt_orgAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgPhone.Focus();
            }
        }

        private void txt_orgPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgFirst.Focus();
            }
        }

        private void txt_orgFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_orgFirstMobile.Focus();
            }
        }

        private void txt_orgFirstMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_contactPerson.Focus();
            }
        }

        private void txt_contactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_contactPersonMobile.Focus();
            }
        }

        private void txt_contactPersonMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_email.Focus();
            }
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rb_supply.Focus();
            }
        }

        private void rb_supply_Leave(object sender, EventArgs e)
        {
            if (rb_supply.Checked == true)
            {
                dtp_startDate.Focus();
            }
            else
            {
                rb_construction.Focus();
            }
        }

        private void rb_supply_KeyDown(object sender, KeyEventArgs e)
        {
            rb_supply_Leave(sender, e);
        }

        private void rb_construction_Leave(object sender, EventArgs e)
        {
            if (rb_construction.Checked == true)
            {
                dtp_startDate.Focus();
            }
            else
            {
                rb_consultancy.Focus();
            }
        }

        private void rb_construction_KeyDown(object sender, KeyEventArgs e)
        {
            rb_construction_Leave(sender, e);
        }

        private void rb_consultancy_Leave(object sender, EventArgs e)
        {
            if (rb_consultancy.Checked == true)
            {
                dtp_startDate.Focus();
            }
            else
            {
                rb_supply.Focus();
            }
        }

        private void rb_consultancy_KeyDown(object sender, KeyEventArgs e)
        {
            rb_consultancy_Leave(sender, e);
        }

        private void dtp_startDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dtp_startDate.Text == Convert.ToString(Convert.ToDateTime(dtp_startDate.Text).AddYears(1).ToString("dd/MM/yyyy")))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        rb_year1.Focus();
                    }
                }
                else
                {
                    if (dtp_startDate.Text != "")
                    {
                        errorProvider_Subscription.SetError(dtp_startDate,"Invalid Date Format.");
                        dtp_startDate.Focus();
                    }
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rb_year1_Leave(object sender, EventArgs e)
        {
            if (rb_year1.Checked == true)
            {
                txt_amount.Focus();
            }
            else
            {
                rb_year2.Focus();
            }
        }


        private void rb_year1_KeyDown(object sender, KeyEventArgs e)
        {
            rb_year1_Leave(sender, e);
        }

        private void rb_year2_Leave(object sender, EventArgs e)
        {
            if (rb_year2.Checked == true)
            {
                txt_amount.Focus();
            }
            else
            {
                rb_year3.Focus();
            }
        }

        private void rb_year2_KeyDown(object sender, KeyEventArgs e)
        {
            rb_year2_Leave(sender, e);
        }

        private void rb_year3_Leave(object sender, EventArgs e)
        {
            if (rb_year3.Checked == true)
            {
                txt_amount.Focus();
            }
            else
            {
                rb_year5.Focus();
            }
        }

        private void rb_year3_KeyDown(object sender, KeyEventArgs e)
        {
            rb_year3_Leave(sender, e);
        }

        private void rb_year5_Leave(object sender, EventArgs e)
        {
            if (rb_year5.Checked == true)
            {
                txt_amount.Focus();
            }
            else
            {
                rb_year1.Focus();
            }
        }

        private void rb_year5_KeyDown(object sender, KeyEventArgs e)
        {
            rb_year5_Leave(sender, e);
        }

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_recDate.Focus();
            }
        }

        private void dtp_recDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_cash.Focus();
            }
        }

        private void txt_cash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_chequeNo.Focus();
            }
        }

        private void txt_chequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_depositeby.Focus();
            }
        }

        private void txt_BankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_referedBy.Focus();
            }
        }

        private void txt_referedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_PaidBy.Focus();
            }
        }

        private void txt_PaidBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ReceivedBy.Focus();
            }
        }

        private void txt_ReceivedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_CheckedBy.Focus();
            }
        }

        private void txt_CheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_fdbck.Focus();
            }
        }

        private void txt_fdbck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_rmark.Focus();
            }
        }

        private void txt_rmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

        private void txt_depositeby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_BankName.Focus();
            }
        }

        private void txt_orgName_TextChanged(object sender, EventArgs e)
        {
            if (txt_orgName.Text != "")
            {
                errorProvider_Subscription.SetError(txt_orgName, "");
            }
        }


        private void dtp_startDate_TextChanged_1(object sender, EventArgs e)
        {
            if (dtp_startDate.Text != "")
            {
                errorProvider_Subscription.SetError(dtp_startDate, "");
            }
        }
    }
}
