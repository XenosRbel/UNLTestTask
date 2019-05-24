using System.Collections.Generic;
using System.Threading.Tasks;
using UNLTestTask.Core.Models;

namespace UNLTestTask.Core.DataCore
{
	public interface IRepository
	{
		Task AddAllAsync<T>(IEnumerable<T> entities) where T : class, IBaseEntity;
		Task<IList<T>> GetAllAsync<T>() where T : class, IBaseEntity;
		Task RemoveAllAsync<T>() where T : class, IBaseEntity;
	}
}
