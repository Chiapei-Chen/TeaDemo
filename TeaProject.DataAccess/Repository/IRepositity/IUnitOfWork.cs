using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaProject.DataAccess.Repository.IRepositity
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		void Save();
	}
}
