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

	public class ShoppingCartRepository : Repository<ShoppingCart>
	, IShoppingCartRepository
    {
		private  TeaProject0504Context _context;
		public ShoppingCartRepository(TeaProject0504Context context):base(context) 
		{
			_context = context;
		}

	
		public void Update(ShoppingCartRepository obj)
		{
			_context.Update(obj);
		}
	}

}
