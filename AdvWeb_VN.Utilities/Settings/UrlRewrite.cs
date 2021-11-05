﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdvWeb_VN.Utilities.Settings
{
	public class UrlRewrite
	{
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        private static string RemoveSignForVietnameseString(string str)

        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)

            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;
        }

        private string SplitAndConcat(string str)
        {
            string[] arrListStr = str.Split(' ');
            string newStr = "";
            foreach(var s in arrListStr)
            {
                newStr += s + "-";
            }
            return newStr;
        }

        public string Rewrite(string postName)
		{
            var name = postName.ToLower();

            name = RemoveSignForVietnameseString(name);

            // except: Ngoại lệ
            string except = " ";

            name = Regex.Replace(name, @"[^a-zA-Z0-9" + except + "]+", string.Empty);

            return SplitAndConcat(name);
		}
	}
}
