using Test.Inventory.UI;
using Test.Inventory;
using UnityEngine;

namespace Test.GamePlay.Weapons
{
   public class WeaponController : SingletonMono<WeaponController>
	{
      [SerializeField] private Weapon[] weapons;
		[SerializeField] private Damager damager;
		public Weapon SelectedWeapon;

		private InventoryController _inventoryController;
		private InventoryUI _inventoryUI;

		public Weapon[] Weapons { get =>weapons; }

		protected override void Awake()
		{
			base.Awake();
			SelectedWeapon = weapons[0];
		}

		public void Attack()
      {
			if (InventoryController.HasReference && InventoryUI.HasReference)
			{
				_inventoryController = InventoryController.Instance;
				_inventoryUI = InventoryUI.Instance;
				var cell = _inventoryController.GetCell(SelectedWeapon.AmmoId);
				if (cell != null)
				{
					cell.Num--;
					if (cell.Num == 0)
					{
						cell.Clear();
					}
					_inventoryUI.Reload();

				}
				else
				{
					return;
				}
			}
			SelectedWeapon.Attack(damager);

		}
   }
}