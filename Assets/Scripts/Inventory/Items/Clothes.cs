using Test.Inventory.Enums;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
	public class Clothes : InvItem, IUseObject
	{
		[SerializeField] private float armor;
		[SerializeField] private ArmorType armorType;
		public float Armor { get => armor; set => armor = value; }
		public ArmorType ArmorType { get => armorType; set => armorType = value; }


		public Clothes(string name, string description, Sprite icon, int max, InvIntemType type, float armor, ArmorType armorType) : base(name, description, icon, max, type)
		{
			this.armor = armor;
			this.armorType = armorType;
		}

		public bool Use()
		{
			if (InventoryController.HasReference)
			{
				foreach (var item in InventoryController.Instance.CellsType)
				{
					if(item.ArmorType == armorType && item.Num == 0)
					{
						for (int i = 0; i < InventoryController.Instance.Items.Length; i++)
						{
							if (this == InventoryController.Instance.Items[i])
							{
								item.IDItem = i;
								break;
							}
						}
						item.Num = 1;
						return true;
					}
				} 
			}
			return false;
		}

		public string GetUIText()
			=> "Ёкипировать";
	}
}