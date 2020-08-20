using AdvWeb_VN.ViewModels.Catalog.Tags;
using AdvWeb_VN.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvWeb_VN.WriterApp.Services
{
	public interface ITagApiClient
	{
		Task<ApiResult<List<TagViewModel>>> GetAll();
	}
}
