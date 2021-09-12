using AdvWeb_VN.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdvWeb_VN.Utilities.Settings
{
	public class Split
	{
		public SplitResult GetID(string raw, int length)
		{
			string name = raw.Substring(0,length);
			int id = Int32.Parse(raw.Substring(length,raw.Length-length));
			return  new SplitResult(id,name);
		}


		public string NormalizeName(string text, int maxLength)
		{
			return Truncate(text, maxLength);
		}

		//Chuẩn hóa nội dung (Search Google nếu muốn biết chuẩn hóa tên gồm cái gì)
		public string NormalizeContent(string contents, int maxLength)
		{
			string text = Regex.Replace(contents, "<((?!<)(.|\n))*?\\>","");
			return Truncate(text, maxLength);
		}

		//Thu gọn text lại, nếu dài quá tự biến thành ....
		public string Truncate(string text, int maxLength)
		{
			string newText = "";
			string[] arrListStr = text.Split(' ');
			if (arrListStr.Length > maxLength)
			{
				for (int i = 0; i < maxLength; i++)
				{
					newText += arrListStr[i] + " ";
				}
				return newText + "...";
			}
			return text;
		}
	}
}
