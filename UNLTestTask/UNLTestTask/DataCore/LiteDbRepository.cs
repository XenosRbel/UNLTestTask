using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using UNLTestTask.Models;

namespace UNLTestTask.DataCore
{
	public class LiteDbRepository : IRepository
	{
		private readonly LiteRepository _liteRepository;

		public LiteDbRepository(LiteRepository liteRepository)
		{
			_liteRepository = liteRepository ?? throw new ArgumentNullException(nameof(liteRepository));
		}

		public Task AddAllAsync<T>(IEnumerable<T> entities) where T : class, IBaseEntity
		{
			return Task.Run(() => _liteRepository.Upsert<T>(entities));
		}

		public async Task<IList<T>> GetAllAsync<T>() where T : class, IBaseEntity
		{
			return await Task.Run(() => _liteRepository.Fetch<T>());
		}

		public Task RemoveAllAsync<T>() where T : class, IBaseEntity
		{
			return Task.Run(() => _liteRepository.Delete<T>(LiteDB.Query.All()));
		}
	}
}