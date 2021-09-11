using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Utilities.Settings
{
	public class ConvertTime
	{
		public string Convert(DateTime postTime)
		{
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = DateTime.Now.Subtract(postTime);

            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "1 giây trước" : ts.Seconds + " giây trước";

            if (delta < 2 * MINUTE)
                return "1 phút trước";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " phút trước";

            if (delta < 90 * MINUTE)
                return "1 giờ trước";

            if (delta < 24 * HOUR)
                return ts.Hours + " giờ trước";

            if (delta < 48 * HOUR)
                return "Hôm qua";

            if (delta < 30 * DAY)
                return ts.Days + " ngày trước";

            if (delta < 12 * MONTH)
            {
                int months = (int) Math.Floor((double)ts.Days / 30);
                return months <= 1 ? "1 tháng trước" : months + " tháng trước";
            }
            else
            {
                int years = (int) Math.Floor((double)ts.Days / 365);
                return years <= 1 ? "1 năm trước" : years + " năm trước";
            }
        }
	}
}
