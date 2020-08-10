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
			string name = raw.Substring(0,length);
			int id = Int32.Parse(raw.Substring(length,raw.Length-length));
			return  new SplitResult(id,name);
		}
	}
}
