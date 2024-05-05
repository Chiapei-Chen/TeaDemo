using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeaProject.DataAccess.Repository.IRepositity
{
    public interface  IRepository<T> where T : class
        //泛型參數的約束(constraint)。在這裡，約束了型別參數 T 必須是一個引用型別（class），
        //這意味著 T 必須是一個類別或委派等引用型別，而不是值型別（struct）。
    {
        IEnumerable<T> GetAll();
		//檢索資料庫中特定型別的所有資料，並以可枚舉的集合形式返回
		T Get(Expression<Func<T, bool>> filter);
		//根據指定的條件過濾並返回符合條件的單個資料項
		void Add(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entitiy);
    }
    
}
