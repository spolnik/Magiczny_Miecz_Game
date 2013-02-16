using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Core;

namespace MagicznyMiecz.Engine.Data
{
    public class SimpleItemsRepositoryInitializer : IRepositoryInitializer<IItem>
    {
        #region Implementation of IRepositoryInitializer

        public void Init(IEditableRepository<IItem> repository)
        {
            var newItem = Item.New(ItemRepository.Miecz).SetMight(2);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.Sztylet).SetMight(1);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.Tarcza).SetDefense(2);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.Zbroja).SetDefense(3);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.Helm).SetDefense(1);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.TarczaBogaTolimana);
            repository.Add(newItem);

            newItem = Item.New(ItemRepository.MagicznyMiecz);
            repository.Add(newItem);

            repository.Init();
        }

        #endregion
    }
}