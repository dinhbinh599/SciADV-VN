using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.ViewModels.Catalog.ProductImages
{
	public class ImageFileInfo
	{
		public string FileName { set; get; }
		public long FileSize { set; get; }

		public ImageFileInfo(string fileName, long fileSize)
		{
			this.FileName = fileName;
			this.FileSize = fileSize;
		}
	}
}
