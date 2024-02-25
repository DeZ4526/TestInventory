using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Inventory
{
	public class InventoryController : SingletonMono<InventoryController>
	{
		[SerializeField] private IItemsGetter itemsGetter = new GetterItems("Inventory/InventoryItemsSO");
		[SerializeField] private InvCellType[] cellsType;
		[SerializeField] private InvCell[] cells;

		[HideInInspector]
		public InvCell SelectedItem = new();
		private InvItem[] _items;

		public InvItem[] Items
		{
			get
			{
				if (_items == null)
				{
					_items = itemsGetter.GetItems();
				}
				return _items;
			}
		}

		public InvCellType[] CellsType { get => cellsType; set => cellsType = value; }
		public InvCell[] Cells { get => cells; set => cells = value; }

		#region UnityMethods
		protected override void Awake()
		{
			base.Awake();
			_items = itemsGetter.GetItems();
		}
		#endregion

		#region CellMethod
		public int GetCountCells()
			=> cells.Length;

		public InvCell GetInvCell(int id)
			=> cells[TestId(id, cells)];

		public InvCell GetCell(int ItemId)
		{
			foreach (var item in cells)
			{
				if (item.IDItem == ItemId)
				{
					return item;
				}
			}
			return null;
		}

		public bool SetItemInCell(InvCell cell, InvCell item)
		{
			var invItem = _items[TestId(item.IDItem, _items)];

			if (cell.IDItem == -1 || cell.IDItem == item.IDItem)
			{
				cell.IDItem = item.IDItem;
				if (cell.Num + item.Num <= invItem.Max)
				{
					cell.Num += item.Num;
					item.Num = 0;
				}
				else if (cell.Num + item.Num > invItem.Max)
				{
					item.Num = (cell.Num + item.Num) - invItem.Max;
					cell.Num = invItem.Max;
				}
				if (item.Num <= 0)
				{
					item.Clear();
				}
				return true;
			}


			return false;
		}
		#endregion
		#region CellTypeMethod
		public int GetCountCellsType()
			=> CellsType.Length;

		public InvCellType GetInvCellType(int id)
			=> CellsType[TestId(id, CellsType)];

		public bool SetItemInCellType(InvCellType cell, InvCell item)
		{
			var invItem = _items[TestId(item.IDItem, _items)];
			if ((cell.IDItem == -1 || cell.IDItem == item.IDItem) && Items[item.IDItem].Type == cell.Type && Items[item.IDItem] is Clothes clothes && clothes.ArmorType == cell.ArmorType)
			{
				cell.IDItem = item.IDItem;
				if (cell.Num + item.Num <= invItem.Max)
				{
					cell.Num += item.Num;
					item.Num = 0;
				}
				else if (cell.Num + item.Num > invItem.Max)
				{
					item.Num = (cell.Num + item.Num) - invItem.Max;
					cell.Num = invItem.Max;
				}
				if (item.Num <= 0)
				{
					item.Clear();
				}
				return true;
			}

			return false;
		}


		#endregion
		public bool AddItem(InvItem item, int num)
		{
			for (int i = 0; i < Items.Length; i++)
			{
				if (Items[i].Equals(item))
				{
					return AddItem(new InvCell() { IDItem = i, Num = num });
				}
			}
			return false;
		}
		public bool AddItem(InvCell item)
		{
			item.IDItem = TestId(item.IDItem, _items);
			foreach (var cell in cells)
			{
				if (item.Num <= 0) return true;
				if (cell.IDItem == -1 || cell.IDItem == item.IDItem)
				{
					cell.IDItem = item.IDItem;
					if (cell.Num + item.Num <= Items[item.IDItem].Max)
					{
						cell.Num += item.Num;
						item.Num = 0;
					}
					else if (cell.Num + item.Num > Items[item.IDItem].Max)
					{
						item.Num = (cell.Num + item.Num) - Items[item.IDItem].Max;
						cell.Num = Items[item.IDItem].Max;
					}
				}
			}
			return false;
		}

		private int TestId(int id, Array array)
			=> id > 0 ? (id < array.Length ? id : 0) : 0;
	}
}