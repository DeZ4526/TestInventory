using System;
using Test.Inventory;
using Test.Inventory.UI;
using UnityEngine;

namespace Test.Save.Bridges
{
	public class InventoryBridge : Bridge
	{
		public override Type GetBridgeType()
			=> typeof(InfoInv);

		public override void OnLoad(InfoSave info)
		{
			if (InventoryController.HasReference)
			{
				var inv = InventoryController.Instance;
				for (int i = 0; i < inv.Cells.Length; i++)
				{
					inv.Cells[i].IDItem = ((InfoInv)info).Cells[i].IDItem;
					inv.Cells[i].Num = ((InfoInv)info).Cells[i].Num;
				}
				for (int i = 0; i < inv.CellsType.Length; i++)
				{
					inv.CellsType[i].IDItem = ((InfoInv)info).CellsType[i].IDItem;
					inv.CellsType[i].Num = ((InfoInv)info).CellsType[i].Num;
				}
				if (InventoryUI.HasReference)
				{
					InventoryUI.Instance.Reload();
				}
			}
		}

		public override InfoSave OnSave()
		{
			if (InventoryController.HasReference)
			{
				return new InfoInv() { Cells = InventoryController.Instance.Cells, CellsType = InventoryController.Instance.CellsType };
			}
			else return null;
		}
	}
	[Serializable]
	class InfoInv : InfoSave
	{
		[SerializeField]
		public InvCellType[] CellsType;
		[SerializeField]
		public InvCell[] Cells;
	}
}