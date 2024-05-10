using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaProject.Models;

namespace TeaProject.DataAccess.Repository.IRepositity
{
	
	public interface IShoppingCartRepository:IRepository<ShoppingCart>
	{
		void Update(ShoppingCartRepository obj);

	}
}
