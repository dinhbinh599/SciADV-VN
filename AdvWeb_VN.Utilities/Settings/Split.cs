using AdvWeb_VN.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Utilities.Settings
{
	public class Split
	{
		public SplitResult GetID(string raw, int length)
		{
			string categoryName = raw.Substring(0,length);
			int id = Int32.Parse(raw.Substring(length+1,raw.Length-categoryName.Length));
			return  new SplitResult(id,categoryName);
		}
	}
}
