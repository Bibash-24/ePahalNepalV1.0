using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Pahal
{
    class cls_Subscription
    {
        public static string tempUpdateId;

        //DATA ADAPTER AND DATA SET FOR ENQUIRY SELECTED RECORD
        public static SqlDataAdapter daStudentInfo = null;
        public static SqlDataAdapter daStudentInfoo = null;
        public static DataSet dsStudentInfo = null;
        public static DataSet dsStudentInfoo = null;

        public static void SaveForm1(string formNo, string invoice,  string receipt, string OrgName, string OrgAdd, string OrgPhone, string OrgFirstPerson, string OrgFirstPersonMobile, string ContactPerson, string ContactMobile, string email, string notice, string startdate, string period, string ExpireDate, string Paidby, string receivedby, string checkedby, string fdbck, string rmark, string amount, string recDate, string cash, string chequeNo, string DepositedBy, string BankName, string ReferedBy)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "INSERT INTO EPahal_form(formID,Invoice_no,receipt_no,organization_name,organization_address,organization_phone,organization_first_persion,organization_first_persion_mobile,contact_person,contact_person_moble,service_email,notice_type,service_start_date,service_period,service_expire_date,paid_by,received_by,checked_by,feedback,remarks,receive_amount,receive_amount_date,cash,cheque_no,deposite_by,bank_name,refered_by) VALUES" + "(@formID,@Invoice_no,@receipt_no,@organization_name,@organization_address,@organization_phone,@organization_first_persion,@organization_first_persion_mobile,@contact_person,@contact_person_moble,@service_email,@notice_type,@service_start_date,@service_period,@service_expire_date,@paid_by,@received_by,@checked_by,@feedback,@remarks,@receive_amount,@receive_amount_date,@cash,@cheque_no,@deposite_by,@bank_name,@refered_by)";
                cmd.Parameters.AddWithValue("@formID", formNo);
                cmd.Parameters.AddWithValue("@Invoice_no", invoice);
                cmd.Parameters.AddWithValue("@receipt_no", receipt);
                cmd.Parameters.AddWithValue("@organization_name", OrgName);
                cmd.Parameters.AddWithValue("@organization_address", OrgAdd);
                cmd.Parameters.AddWithValue("@organization_phone", OrgPhone);
                cmd.Parameters.AddWithValue("@organization_first_persion", OrgFirstPerson);
                cmd.Parameters.AddWithValue("@organization_first_persion_mobile", OrgFirstPersonMobile);
                cmd.Parameters.AddWithValue("@contact_person", ContactPerson);
                cmd.Parameters.AddWithValue("@contact_person_moble", ContactMobile);
                cmd.Parameters.AddWithValue("@service_email", email);
                cmd.Parameters.AddWithValue("@notice_type", notice);
                cmd.Parameters.AddWithValue("@service_start_date", startdate);
                cmd.Parameters.AddWithValue("@service_period", period);
                cmd.Parameters.AddWithValue("@service_expire_date", ExpireDate);
                cmd.Parameters.AddWithValue("@paid_by", Paidby);
                cmd.Parameters.AddWithValue("@received_by", receivedby);
                cmd.Parameters.AddWithValue("@checked_by", checkedby);
                cmd.Parameters.AddWithValue("@feedback", fdbck);
                cmd.Parameters.AddWithValue("@remarks", rmark);
                cmd.Parameters.AddWithValue("@receive_amount", amount);
                cmd.Parameters.AddWithValue("@receive_amount_date", recDate);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@cheque_no", chequeNo);
                cmd.Parameters.AddWithValue("@deposite_by", DepositedBy);
                cmd.Parameters.AddWithValue("@bank_name", BankName);
                cmd.Parameters.AddWithValue("@refered_by", ReferedBy);
                //cmd.Parameters.AddWithValue("@exam_createby", GlobalConnection.strUid);
                //cmd.Parameters.AddWithValue("@exam_createdate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show(GlobalConnection.DataSaved, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateForm1(string formNo, string invoice,  string receipt, string OrgName, string OrgAdd, string OrgPhone, string OrgFirstPerson, string OrgFirstPersonMobile, string ContactPerson, string ContactMobile, string email, string notice, string startdate, string period, string ExpireDate, string Paidby, string receivedby, string checkedby, string fdbck, string rmark, string amount, string recDate, string cash, string chequeNo, string DepositedBy, string BankName, string ReferedBy)
        {
            try
            {
                GlobalConnection.PerformConnection();

                SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                cmd.CommandText = "UPDATE EPahal_form set formID=@formID,Invoice_no=@Invoice_no,receipt_no=@receipt_no,organization_name=@organization_name,organization_address=@organization_address,organization_phone=@organization_phone,organization_first_persion=@organization_first_persion,organization_first_persion_mobile=@organization_first_persion_mobile,contact_person=@contact_person,contact_person_moble=@contact_person_moble,service_email=@service_email,notice_type=@notice_type,service_start_date=@service_start_date,service_period=@service_period,service_expire_date=@service_expire_date,paid_by=@paid_by,received_by=@received_by,checked_by=@checked_by,feedback=@feedback,remarks=@remarks,receive_amount=@receive_amount,receive_amount_date=@receive_amount_date,cash=@cash,cheque_no=@cheque_no,deposite_by=@deposite_by,bank_name=@bank_name,refered_by=@refered_by where formID= '" + tempUpdateId + "'";
                cmd.Parameters.AddWithValue("@formID", formNo);
                cmd.Parameters.AddWithValue("@Invoice_no", invoice);
                cmd.Parameters.AddWithValue("@receipt_no", receipt);
                cmd.Parameters.AddWithValue("@organization_name", OrgName);
                cmd.Parameters.AddWithValue("@organization_address", OrgAdd);
                cmd.Parameters.AddWithValue("@organization_phone", OrgPhone);
                cmd.Parameters.AddWithValue("@organization_first_persion", OrgFirstPerson);
                cmd.Parameters.AddWithValue("@organization_first_persion_mobile", OrgFirstPersonMobile);
                cmd.Parameters.AddWithValue("@contact_person", ContactPerson);
                cmd.Parameters.AddWithValue("@contact_person_moble", ContactMobile);
                cmd.Parameters.AddWithValue("@service_email", email);
                cmd.Parameters.AddWithValue("@notice_type", notice);
                cmd.Parameters.AddWithValue("@service_start_date", startdate);
                cmd.Parameters.AddWithValue("@service_period", period);
                cmd.Parameters.AddWithValue("@service_expire_date", ExpireDate);
                cmd.Parameters.AddWithValue("@paid_by", Paidby);
                cmd.Parameters.AddWithValue("@received_by", receivedby);
                cmd.Parameters.AddWithValue("@checked_by", checkedby);
                cmd.Parameters.AddWithValue("@feedback", fdbck);
                cmd.Parameters.AddWithValue("@remarks", rmark);
                cmd.Parameters.AddWithValue("@receive_amount", amount);
                cmd.Parameters.AddWithValue("@receive_amount_date", recDate);
                cmd.Parameters.AddWithValue("@cash", cash);
                cmd.Parameters.AddWithValue("@cheque_no", chequeNo);
                cmd.Parameters.AddWithValue("@deposite_by", DepositedBy);
                cmd.Parameters.AddWithValue("@bank_name", BankName);
                cmd.Parameters.AddWithValue("@refered_by", ReferedBy);
                //cmd.Parameters.AddWithValue("@exam_createby", GlobalConnection.strUid);
                //cmd.Parameters.AddWithValue("@exam_createdate", DateTime.Now);
                cmd.ExecuteNonQuery();
                MessageBox.Show(GlobalConnection.DataUpdate, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Delete(string formno)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    //  DELETING DATABASE TABLE

                    SqlCommand cmd = GlobalConnection.cn.CreateCommand();
                    cmd.CommandText = "UPDATE EPahal_form SET estatus=0 WHERE formID='" + tempUpdateId + "'";
                    //cmd.Parameters.AddWithValue("@pp_deleteby", GlobalConnection.strUid);
                    //cmd.Parameters.AddWithValue("@pp_deletedate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(GlobalConnection.DataDelete, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, GlobalConnection.ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public static DataTable LoadSubscriber()
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE  estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Name(string Name)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE organization_name LIKE LTRIM('%" + Name + "%') AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Add(string Add)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE organization_address LIKE LTRIM('%" + Add + "%') AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Pho(string Pho)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE organization_phone LIKE LTRIM('%" + Pho + "%') AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_Email(string Email)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE service_email LIKE LTRIM('%" + Email + "%') AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_StartDate(string Sdate)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE service_start_date LIKE'" + Sdate + "%' AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable LoadSuscriber_EndDate(string Edate)
        {
            GlobalConnection.PerformConnection();
            if (GlobalConnection.ServerAvailable == true)
            {
                try
                {
                    SqlDataAdapter daVfrm = null;
                    DataSet dsVfrm = null;
                    daVfrm = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE service_expire_date LIKE '" + Edate + "%' AND estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
                    dsVfrm = new DataSet();
                    daVfrm.Fill(dsVfrm, "subscriber");
                    return dsVfrm.Tables[0];
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static DataTable Search_Selection()
        {
            GlobalConnection.PerformConnection();
            daStudentInfo = new SqlDataAdapter("select EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By],EPahal_form.paid_by[Paid By],EPahal_form.received_by[Received By],EPahal_form.checked_by[Checked By],Epahal_form.feedback[Feedbacks],Epahal_form.remarks[Remarks] from EPahal_form WHERE estatus = 1 ORDER BY formID DESC", GlobalConnection.cn);
            dsStudentInfo = new DataSet();
            daStudentInfo.Fill(dsStudentInfo, "subscriber_search");
            DataTable dt_search = dsStudentInfo.Tables["subscriber_search"];
            return dt_search;
        }

        public static DataTable Search_Particular(string fno)
        {
            GlobalConnection.PerformConnection();
            daStudentInfo = new SqlDataAdapter("SELECT EPahal_form.formID[Form No.],EPahal_form.Invoice_no[Invoice No.],EPahal_form.receipt_no[Receipt No.],EPahal_form.organization_name[Name of Organization],EPahal_form.organization_address[Address of Organization],EPahal_form.organization_phone[Phone No.],EPahal_form.organization_first_persion[First Person of Organization],EPahal_form.organization_first_persion_mobile[First Person Mobile],EPahal_form.contact_person[Contact Person],EPahal_form.contact_person_moble[Mobile No.],EPahal_form.service_email[Service Receiving Email Address],EPahal_form.notice_type[Type of Notice Required],EPahal_form.service_start_date[Service Start Date],EPahal_form.service_period[Service Period],EPahal_form.service_expire_date[Service Expiry Date],EPahal_form.receive_amount[Received Amount],EPahal_form.receive_amount_date[Received Amount Date],EPahal_form.cash[Cash],EPahal_form.cheque_no[Cheque No.],EPahal_form.deposite_by[Bank Deposited By],EPahal_form.bank_name[Bank Name],EPahal_form.refered_by[Refered By] FROM EPahal_form WHERE formID = '" + fno + "'", GlobalConnection.cn);
            dsStudentInfo = new DataSet();
            daStudentInfo.Fill(dsStudentInfo, "subscriber_search");
            DataTable dt_search = dsStudentInfo.Tables["subscriber_search"];
            return dt_search;
        }

    }


}
