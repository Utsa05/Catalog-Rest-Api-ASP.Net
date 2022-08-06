using Catelog.Entities;

public interface IIitemRepository
{

    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
    void CreateItem(Item item);
    void updateItem(Item item);
    void deleteItem(Guid guid);
}