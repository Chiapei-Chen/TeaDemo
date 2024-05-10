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

	public class ApplicationUserRepository : Repository<ApplicationUserRepository>
	, IApplicationUserRepository
    {
		private  TeaProject0504Context _context;
		public ApplicationUserRepository(TeaProject0504Context context):base(context) 
		{
			_context = context;
		}

	
	
		public void Update(IApplicationUserRepository obj)
		{
			_context.Update(obj);
		}
	}

}
