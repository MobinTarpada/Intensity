using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessCenter.BAL
{
    public class UtillController
    {
        public static DateTime ConvertDateTime(object objDate)
        {
            try
            {
                System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                dateInfo.ShortDatePattern = "dd/MMM/yyyy";
                return Convert.ToDateTime(objDate, dateInfo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}