using Test.Inventory.Enums;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
	public class Ammo: InvItem, IUseObject
	{
		private InventoryController _inventoryController;
		public Ammo(string name, string description, Sprite icon, int max, InvIntemType type) : base(name, description, icon, max, type)
		{
		}

		public bool Use()
		{
			if(_inventoryController == null && InventoryController.HasReference)
			{
				_inventoryController = InventoryController.Instance;
				_inventoryController.AddItem(this, Max);
			}
			return true;
		}

		public string GetUIText()
			=> "Купить";
	}
}