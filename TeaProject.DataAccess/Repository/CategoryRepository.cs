using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models;

namespace TeaProject.DataAccess.Repository
{

	public class CategoryRepository : Repository<Category>
	, ICategoryRepository
	{
		private  TeaProject0504Context _context;
		public CategoryRepository(TeaProject0504Context context):base(context) 
		{
			_context = context;
		}

	
		public void Update(Category obj)
		{
			_context.Update(obj);
		}
	}

}
