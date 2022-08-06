using Catelog.Entities;

namespace Catalog.Repositories
{


    public class InMemItemsRepository : IIitemRepository
    {
        private readonly List<Item> Items = new()
       {
           new Item{Id=Guid.NewGuid(),Name="Potion",Price=9,CreatedDate=DateTimeOffset.UtcNow},
           new Item{Id=Guid.NewGuid(),Name="Iron Sword",Price=12,CreatedDate=DateTimeOffset.UtcNow},
           new Item{Id=Guid.NewGuid(),Name="Bronze Shield",Price=15,CreatedDate=DateTimeOffset.UtcNow},
       };

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }
        public Item GetItem(Guid id)
        {
            return Items.Where(item => item.Id == id).SingleOrDefault()!;
        }

        public void CreateItem(Item item)
        {
            Items.Add(item);
        }

        public void updateItem(Item item)
        {
            var index = Items.FindIndex(i => i.Id == item.Id);

            Items[index] = item;
        }

        public void deleteItem(Guid id)
        {
            var index = Items.FindIndex(i => i.Id == id);
            Items.RemoveAt(index);
        }
    }
}