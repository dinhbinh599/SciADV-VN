using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Utilities.Dtos
{
	public class SplitResult
	{
		public int Number { set; get; }
		public string CategoryName { set; get; }

		public SplitResult(int number, string categoryName)
		{
			Number = number;
			CategoryName = categoryName;
		}
	}
}
