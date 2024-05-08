using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaProject.Models;

namespace TeaProject.DataAccess.Repository.IRepositity
{

    public interface IProductRepository:IRepository<Product>
	{
		void Update(Product obj);
	//	void Save();
	}
}
