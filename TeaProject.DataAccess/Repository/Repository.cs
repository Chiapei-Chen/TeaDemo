using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository.IRepositity;

namespace TeaProject.DataAccess.Repository
{
	//主要用於資料存取操作
	public class Repository<T>:IRepository<T> where T : class
	{
		private readonly TeaProject0504Context _context;
		internal DbSet<T> dbSet;
		public Repository(TeaProject0504Context context) { 
		
		_context= context;
		this.dbSet= _context.Set<T>();
			//表示資料庫中一個特定型別的集合的類型。
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter) {


			IQueryable<T> query = dbSet;
			//是 LINQ 中的一個介面，代表了可查詢的資料集合。
			//它提供了一個通用的查詢介面，可以用於對資料集合進行各種查詢操作，
			query = query.Where(filter);
			return query.FirstOrDefault();
		}
		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(filter != null)
			{
				query=query.Where(filter);
			}
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries)) {
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}
		public void Remove(T entity) { 
		
		dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity) {
		
			dbSet.RemoveRange(entity);
		}
	}
	

}
