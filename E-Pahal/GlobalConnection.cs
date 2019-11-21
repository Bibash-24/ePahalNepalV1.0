using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;


namespace E_Pahal
{
    class GlobalConnection
    {
        public static SqlConnection cn;
        //SERVER INFORMATION
        public static string strServer = @"DESKTOP-5UI1E43";
        public static string strSUid = "sa";
        public static string strSPwd = "nikesh";
        public static string strDatabase = "eduMediatorTest";

        //CONNECTION DETAILS
        public static string strServerID;
        //public static string strServer; = @"DESKTOP-MV6FIUL"/*"DESKTOP-0HG51M7"*/;
        //public static string strSUid;// = "sa";
        //public static string strSPwd;// = /*"eclat"*/"eclat";
        //public static string strDatabase;// = "eclatProductTest";//"myApplication";
        public static string strServerStatus;

        //USER INFORMATION
        public static string strUid;

        //USER INFORMATION
        public static string strUGroup;
        public static string strUGroupID;

        public static string strUserLoginName;
        public static string strUsername;
        public static string strPWD;
        public static string strUCategory;
        public static string strUStatus;
        public static string strUpdateDelete = "";
        public static string strClintId = "";
        public static string strClintName = "";


        //DEFINING FOLDER AND FILE PATH
        public static string ProjectPath;
        public static string XMLFilePath;
        public static string PhotoPath;
        public static string DocumentPath;

      
        //SERVER STATUS NFORMATION
        public static Boolean ServerAvailable;

        public static string DataSaved = "Record Added Sucessfully.";
        public static string DataSavedOffline = "Record Added Sucessfully.";
        
        public static string DataUpdate = "Record Updated Sucessfully.";
        public static string DataUpdateOffline = "Record Updated Sucessfully.";
        
        public static string DataDelete = "Record Deleted Sucessfully.";
        public static string DataDeleteOffline = "Record Deleted Sucessfully.";
        
        public static string DataAdd = "Adding New Record.";

        public static string ProjectName = "E-Pahal";
        public static string strProjectValue;
        public static string UserTransactionID;
        public static int UserTransactionNumber;

        //Test Preparation Score
        public static string studentId_score;
        public static string score_date;





        //public static string strProjectName = "eProduct";
        //public static string strProjectValue = "eProduct";

        //ORGANIZATION INFORMATION
        public static string strCompanyName = "E-Pahal Nepal";
        public static string strCompanyType;
        public static string strCompanyNumber;
        public static byte strCompanyLogo;
        public static string strCompanyAddress = "Tokha, Kathmandu, Nepal";
        public static string strCompanyContactInfo;
        public static string strLicenseDate;
        public static string strExpiryDate;

        //PRODUCT DETAILS
        public static string strEditionID;
        public static string strEditionName;
        public static string strEditionVer;



       

        //SYSTEM INFORMATION
        public static string ArValue;           //= "1";
        public static string FY_ID;             //= "F0001";
        public static string FY_Name;           //= "2072/073";
        public static string FY_StartDate;
        public static string FY_EndDate;
        public static string FY_Status;



        //eProduct SYSTEM SETTING
        public static string Discount_Desc;
        public static string PurchaseTaxRate_Desc;
        public static string SalesTaxRate_Desc;
        public static string BillNumber_Desc;
        public static string VoucherNumber_Desc;


        public static string con_string;

        public static void PerformConnection()
        {
            try
            {
                //cn = new SqlConnection("Server=" + strServer + ";Uid=" + strSUid + ";Pwd=" + strSPwd + ";Database=" + strDatabase);
                con_string = @"Data Source=localhost;Initial Catalog=EPahal;Integrated Security=true";
                cn = new SqlConnection(con_string);
                cn.Open();
                ServerAvailable = true;
            }
            catch
            {
                ServerAvailable = false;
            }

            
        }

    }
}
