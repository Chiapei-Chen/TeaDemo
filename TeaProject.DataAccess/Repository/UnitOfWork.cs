using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository.IRepositity;

namespace TeaProject.DataAccess.Repository
{
	public class UnitOfWork:IUnitOfWork
	{
		private TeaProject0504Context _context;
		public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public UnitOfWork(TeaProject0504Context context)
		{

			_context = context;
			CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
