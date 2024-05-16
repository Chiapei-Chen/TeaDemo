using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        // 實現介面中的 Where 方法，用於條件查詢
        public IQueryable<ShoppingCart> Where(Expression<Func<ShoppingCart, bool>> predicate)
        {
            return _context.Set<ShoppingCart>().Where(predicate);
        }

        public IQueryable<TEntity> Include<TEntity, TProperty>(
            IQueryable<TEntity> source,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            return source.Include(navigationPropertyPath);
        }
    }

}
