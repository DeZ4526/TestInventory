using System.Collections.Generic;

namespace Test.Inventory
{
   public interface IItemsGetter
   {
      public InvItem[] GetItems();
   }
}