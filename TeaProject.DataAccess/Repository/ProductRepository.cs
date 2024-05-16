using Microsoft.EntityFrameworkCore;
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

    public class ProductRepository : Repository<Product>
	, IProductRepository
    {
		private  TeaProject0504Context _context;
        public ProductRepository(TeaProject0504Context context):base(context) 
		{
			_context = context;
		}
      


        public void Update(Product obj)
		{
			_context.Update(obj);
		}


		public async Task<Product> GetProductByIdAsync(int productid)
		{ 
		    return await _context.Products.FirstOrDefaultAsync(p=>p.Id == productid);
		}
        public async Task<decimal?> GetProductPriceAsync(int productId, string size)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return null;
            }


            return product.Price;
        }
    }

}
