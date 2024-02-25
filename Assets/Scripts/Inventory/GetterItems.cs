using System.Collections.Generic;
using Test.Inventory.ScriptableObjects;
using UnityEngine;

namespace Test.Inventory
{
	public class GetterItems : IItemsGetter
	{
		private readonly string _path;

		public GetterItems(string path)
			=> _path = path;

		public InvItem[] GetItems()
			=> (Resources.Load(_path) as ItemsSO).GetItems();
	}
}