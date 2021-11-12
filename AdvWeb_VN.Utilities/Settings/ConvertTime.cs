using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Utilities.Settings
{
	public class ConvertTime
	{
        //Chuyển đổi định dạng từ DateTime sang kiểu đếm lùi (Ví dụ: Bao nhiêu giây, phút trước)
		public string Convert(DateTime postTime)
		{
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = DateTime.Now.ToUniversalTime().Subtract(postTime);

            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "1 giây trước" : Math.Abs(ts.Seconds) + " giây trước";

            if (delta < 2 * MINUTE)
                return "1 phút trước";

            if (delta < 45 * MINUTE)
                return Math.Abs(ts.Minutes) + " phút trước";

            if (delta < 90 * MINUTE)
                return "1 giờ trước";

            if (delta < 24 * HOUR)
                return Math.Abs(ts.Hours) + " giờ trước";

            if (delta < 48 * HOUR)
                return "Hôm qua";

            if (delta < 30 * DAY)
                return Math.Abs(ts.Days) + " ngày trước";

            if (delta < 12 * MONTH)
            {
                int months = (int) Math.Floor((double)ts.Days / 30);
                return months <= 1 ? "1 tháng trước" : Math.Abs(months) + " tháng trước";
            }
            else
            {
                int years = (int) Math.Floor((double)ts.Days / 365);
                return years <= 1 ? "1 năm trước" : Math.Abs(years) + " năm trước";
            }
        }
	}
}
