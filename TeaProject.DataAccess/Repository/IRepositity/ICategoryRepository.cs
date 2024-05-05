using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaProject.Models;

namespace TeaProject.DataAccess.Repository.IRepositity
{
	//針對類型 Category 的特定資料操作
	public interface ICategoryRepository:IRepository<Category>
	{
		void Update(Category category);
	//	void Save();
	}
}
