using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Models;

namespace UNLTestTask.Core.DataCore
{
	public class MemoryRepository : IRepository
	{
		private readonly IList<object> _dbList;

		public MemoryRepository()
		{
			_dbList = new List<object>();

			FillStaticContactData();
		}

		public Task AddAllAsync<T>(IEnumerable<T> entities) where T : class, IBaseEntity
		{
			RemoveAllAsync<T>();

			return Task.Run(() =>
			{
				entities = AddIndexToEntities(entities);

				foreach (var entity in entities)
				{
					_dbList.Add(entity);
				}

				return true;
			});
		}

		public async Task<IList<T>> GetAllAsync<T>() where T : class, IBaseEntity
		{
			return await Task.Run(() => _dbList.OfType<T>().ToList());
		}

		public Task RemoveAllAsync<T>() where T : class, IBaseEntity
		{
			return Task.Run(() =>
			{
				_dbList.Clear();
				return true;
			});
		}

		private IEnumerable<T> AddIndexToEntities<T>(IEnumerable<T> entities) where T : class, IBaseEntity
		{
			var list = entities.ToList();

			for (int i = 0; i < list.Count; i++)
			{
				var item = list[i];
				item.Id = i;
			}

			return list;
		}

		private async void FillStaticContactData()
		{
			var contacts = new List<Contact>
			{
				new Contact
				{
					PhotoPath = "tom.png",
					Name = "Tom",
					PhoneNumber = "+375441234569",
					PhoneType = ContactType.None
				},

				new Contact
				{
					PhotoPath = "jerry.png",
					Name = "Jerry",
					PhoneNumber = "+375252236548",
					PhoneType = ContactType.WorkPhone
				}
			};

			await AddAllAsync(contacts);
		}
	}
}