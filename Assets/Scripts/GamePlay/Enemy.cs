using Test.Inventory.UI;
using Test.Inventory;
using UnityEngine;
using Test.Inventory.Enums;

namespace Test.GamePlay
{
	public class Enemy : Damager
	{
		[SerializeField] private Damager damager;
		
		private InventoryController _inventoryController;
		private InventoryUI _inventoryUI;

		private ArmorType _armorType;


		public override void Damage(ArmorType type, float damag) => Damage(damag);

		public override void Damage(float damag)
		{
			base.Damage(damag);
			if(damager != null)
			{
				_armorType = _armorType == ArmorType.Head ? ArmorType.Body : ArmorType.Head;
				damager.Damage(_armorType, 15);
			}
		}
		public override void Kill()
		{
			if (InventoryController.HasReference && InventoryUI.HasReference)
			{
				_inventoryController = InventoryController.Instance;
				_inventoryUI = InventoryUI.Instance;
				_inventoryController.AddItem(new InvCell() { Num = 1, IDItem = Random.Range(0, _inventoryController.Items.Length) });
				_inventoryUI.Reload();
			}
			hp = 100;
		}

	}
}	