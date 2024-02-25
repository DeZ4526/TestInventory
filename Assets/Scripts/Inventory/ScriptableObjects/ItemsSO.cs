using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Test.Inventory.ScriptableObjects
{
	[CreateAssetMenu(fileName = "InventoryItemsSO", menuName = "ScriptableObjects/Inventory/Items", order = 1)]
	public class ItemsSO : ScriptableObject, IItemsGetter
	{
		[SerializeField] private InvItem[] items;
		[SerializeField] private Clothes[] clothes;
		[SerializeField] private Medic[] medics;
		[SerializeField] private Ammo[] ammos;

		public InvItem[] GetItems()
		{
			List<InvItem> list = new(items);
			list.AddRange(clothes);
			list.AddRange(medics);
			list.AddRange(ammos);
			return list.ToArray();
		}
	}
}