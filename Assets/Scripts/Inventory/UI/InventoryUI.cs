using System.Collections.Generic;
using UnityEngine;

namespace Test.Inventory.UI 
{
	public class InventoryUI : SingletonMono<InventoryUI>
	{
		[SerializeField] private InvCellUI cellUI;
		[SerializeField] private InvCellUI selectedItemUI;
		[SerializeField] private Transform cellsContainer;
		[SerializeField] private Transform cellsTypeContainer;

		private InventoryController _inventoryController;
		private readonly List<GameObject> _cellsObjects = new();
		private readonly List<GameObject> _cellsTypeObjects = new();

		protected override void Awake()
		{
			base.Awake();

			if (InventoryController.HasReference)
			{
				_inventoryController = InventoryController.Instance;
			}
			Reload();
		}
		public void Reload()
		{
			Debug.Log("Inventory UI Reload");
			_cellsObjects.ForEach(c => Destroy(c));
			_cellsTypeObjects.ForEach(c => Destroy(c));

			_cellsObjects.Clear();
			_cellsTypeObjects.Clear();
			
			int countCells = _inventoryController.GetCountCells();
			int countCellsType = _inventoryController.GetCountCellsType();

			for (int i = 0; i < countCells; i++)
			{
				var obj = Instantiate(cellUI, cellsContainer);
				obj.Init(_inventoryController.GetInvCell(i));
				_cellsObjects.Add(obj.gameObject);
			}
			for (int i = 0; i < countCellsType; i++)
			{
				var obj = Instantiate(cellUI, cellsTypeContainer);
				obj.Init(_inventoryController.GetInvCellType(i));
				_cellsTypeObjects.Add(obj.gameObject);
			}
			if (_inventoryController.SelectedItem.Num != 0 && _inventoryController.SelectedItem.IDItem != -1)
			{
				selectedItemUI.gameObject.SetActive(true);
				selectedItemUI.Init(_inventoryController.SelectedItem);
			}
			else
			{
				selectedItemUI.gameObject.SetActive(false);
			}
		}
	}
}