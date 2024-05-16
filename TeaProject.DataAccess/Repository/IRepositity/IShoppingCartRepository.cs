using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeaProject.Models;

namespace TeaProject.DataAccess.Repository.IRepositity
{
	
	public interface IShoppingCartRepository:IRepository<ShoppingCart>
	{
      
        void Update(ShoppingCartRepository obj);
        // 添加 Where 方法的定义
        // 在購物車中執行條件查詢
        IQueryable<ShoppingCart> Where(Expression<Func<ShoppingCart, bool>> predicate);
        IQueryable<TEntity> Include<TEntity, TProperty>(
           IQueryable<TEntity> source,
           Expression<Func<TEntity, TProperty>> navigationPropertyPath)
           where TEntity : class;


    }
}
