using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Compact.Models
{
    public class GlobalClass
    {
        static private string _ModuleList = "ModuleList";
        public static List<UserModuleClass> ModuleList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._ModuleList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<UserModuleClass>)(HttpContext.Current.Session[GlobalClass._ModuleList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._ModuleList] = value;
            }
        }
        static private string _FormList = "FormList";
        public static List<UserFormClass> FormList
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._FormList] == null)
                {
                    return null;
                }
                else
                {
                    return (List<UserFormClass>)(HttpContext.Current.Session[GlobalClass._FormList]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._FormList] = value;
            }
        }
        public static string ConvertDigits(decimal? tempDecimal)
        {
            // int s = Convert.ToInt32(tempDecimal);
            decimal s = Math.Truncate((decimal)tempDecimal);
            if (s == 0) { return " "; }
            else
            {
                string temp = s.ToString()
                .Replace("0", "০")
                .Replace("1", "১")
                .Replace("2", "২")
                .Replace("3", "৩")
                .Replace("4", "৪")
                .Replace("5", "৫")
                .Replace("6", "৬")
                .Replace("7", "৭")
                .Replace("8", "৮")
                .Replace("9", "৯");
                return temp + "/-";
            }
        }
        public static string ConvertDigitsandRound(decimal? tempDecimal)
        {
            decimal s = Math.Round((decimal)tempDecimal);
            if (s == 0) { return " "; }
            else
            {
                string temp = s.ToString()
                .Replace("0", "০")
                .Replace("1", "১")
                .Replace("2", "২")
                .Replace("3", "৩")
                .Replace("4", "৪")
                .Replace("5", "৫")
                .Replace("6", "৬")
                .Replace("7", "৭")
                .Replace("8", "৮")
                .Replace("9", "৯");
                return temp;
            }
        }
        public static string ConvertDigitsNonCom(decimal? tempDecimal)
        {
            decimal s = Math.Truncate((decimal)tempDecimal);
            if (s == 0) { return " "; }
            else
            {
                string temp = s.ToString()
                .Replace("0", "০")
                .Replace("1", "১")
                .Replace("2", "২")
                .Replace("3", "৩")
                .Replace("4", "৪")
                .Replace("5", "৫")
                .Replace("6", "৬")
                .Replace("7", "৭")
                .Replace("8", "৮")
                .Replace("9", "৯");
                return temp;
            }
        }
        public static string ConvertMonthInNo(int? tempDecimal)
        {

            string temp = tempDecimal.ToString()
            .Replace("0", "০")
            .Replace("1", "০১")
            .Replace("2", "০২")
            .Replace("3", "০৩")
            .Replace("4", "০৪")
            .Replace("5", "০৫")
            .Replace("6", "০৬")
            .Replace("7", "০৭")
            .Replace("8", "০৮")
            .Replace("9", "০৯");
            return temp;

        }
        public static string ConvertSerials(int? tempDecimal)
        {
            if (tempDecimal.ToString().Length > 1)
            {
                string temp = tempDecimal.ToString()


                    .Replace("10", "ঞ")
                    .Replace("11", "ট")
                    .Replace("12", "ঠ")
                    .Replace("13", "ড")
                    .Replace("14", "ঢ")
                    .Replace("15", "ণ")
                    .Replace("16", "ত")
                    .Replace("17", "থ");
                return temp;
            }
            else
            {
                string temp = tempDecimal.ToString()

                    .Replace("1", "ক")
                    .Replace("2", "খ")
                    .Replace("3", "গ")
                    .Replace("4", "ঘ")
                    .Replace("5", "ঙ")
                    .Replace("6", "চ")
                    .Replace("7", "ছ")
                    .Replace("8", "জ")
                    .Replace("9", "ঝ");

                return temp;
            }

        }
        public static string ConvertOrdinal(int? tempDecimal)
        {

            string temp = tempDecimal.ToString()

                .Replace("1", "১ম")
                .Replace("2", "২য়")
                .Replace("3", "৩য়")
                .Replace("4", "৪র্থ")
                .Replace("5", "৫ম")
                .Replace("6", "৬ষ্ঠ")
                .Replace("7", "৭ম")
                .Replace("8", "৮ম")
                .Replace("9", "৯ম");

            return temp;

        }
        public static string ConvertNumbers(int? tempDecimal)
        {

            string temp = tempDecimal.ToString()
                .Replace("0", "0")
                .Replace("1", "১")
                .Replace("2", "২")
                .Replace("3", "৩")
                .Replace("4", "৪")
                .Replace("5", "৫")
                .Replace("6", "৬")
                .Replace("7", "৭")
                .Replace("8", "৮")
                .Replace("9", "৯");

            return temp;

        }
        public static string ConvertString(string tempDecimal)
        {
            if (!string.IsNullOrEmpty(tempDecimal))
            {
                string temp = tempDecimal
                    .Replace("0", "0")
                    .Replace("1", "১")
                    .Replace("2", "২")
                    .Replace("3", "৩")
                    .Replace("4", "৪")
                    .Replace("5", "৫")
                    .Replace("6", "৬")
                    .Replace("7", "৭")
                    .Replace("8", "৮")
                    .Replace("9", "৯");

                return temp;
            }
            else { string temp = " "; return temp; }

        }
        public static string ConvertDate(int t)
        {
            string s = "";
            if (t == 1) s = "জানুয়ারী ";
            if (t == 2) s = "ফেব্রুয়ারী ";
            if (t == 3) s = "মার্চ ";
            if (t == 4) s = "এপ্রিল ";
            if (t == 5) s = "মে ";
            if (t == 6) s = "জুন ";
            if (t == 7) s = "জুলাই ";
            if (t == 8) s = "আগস্ট ";
            if (t == 9) s = "সেপ্টেম্বর ";
            if (t == 10) s = "অক্টোবর ";
            if (t == 11) s = "নভেম্বর ";
            if (t == 12) s = "ডিসেম্বর ";
            if (t == 13) s = " ";

            return s;
        }
        static private string _MasterSession = "MasterSession";
        public static bool MasterSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._MasterSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._MasterSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._MasterSession] = value;
            }
        }
        static private string _LocalString = "LocalString";
        public static System.Globalization.CultureInfo LocalString
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LocalString] == null)
                {
                    return new System.Globalization.CultureInfo("en-EN");
                }
                else
                {
                    return (System.Globalization.CultureInfo)(HttpContext.Current.Session[GlobalClass._LocalString]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LocalString] = value;
            }
        }

        static private string _TempVariable = "TempVariable";
        public static string TempVariable
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._TempVariable] == null)
                {
                    return "";
                }
                else
                {
                    return (HttpContext.Current.Session[GlobalClass._TempVariable]).ToString();
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._TempVariable] = value;
            }
        }
       
        static private string _AnchorID = "AnchorID";
        public static int AnchorID
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._AnchorID] == null)
                {
                    return -99;
                }
                else
                {
                    return (int)(HttpContext.Current.Session[GlobalClass._AnchorID]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._AnchorID] = value;
            }
        }
        static private string _SystemSession = "SystemSession";
        public static bool SystemSession
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._SystemSession] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)(HttpContext.Current.Session[GlobalClass._SystemSession]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._SystemSession] = value;
            }
        }

        static private string _Company = "Company";
        public static Company Company
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._Company] == null)
                {
                    return null;
                }
                else
                {
                    return (Company)(HttpContext.Current.Session[GlobalClass._Company]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._Company] = value;
            }
        }
        static private string _Warehouse= "Warehouse";
        public static Warehouse Warehouse
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._Warehouse] == null)
                {
                    return null;
                }
                else
                {
                    return (Warehouse)(HttpContext.Current.Session[GlobalClass._Warehouse]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._Warehouse] = value;
            }
        }


        static private string _LoginUser = "LoginUser";
        public static User LoginUser
        {
            get
            {
                if (HttpContext.Current.Session[GlobalClass._LoginUser] == null)
                {
                    return null;
                }
                else
                {
                    return (User)(HttpContext.Current.Session[GlobalClass._LoginUser]);
                }
            }
            set
            {
                HttpContext.Current.Session[GlobalClass._LoginUser] = value;
            }
        }

    }
}