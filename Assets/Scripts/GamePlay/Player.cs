using Test.GamePlay;
using Test.Inventory;
using Test.Inventory.Enums;
using UnityEngine;

public class Player : Damager
{
	private InventoryController _InventoryController;

	[SerializeField] protected bool isDontDestroy;
	protected static Player Reference;

	public static Player Instance
	{
		get
		{
			if (Reference == null)
			{
				if (!(Reference = FindObjectOfType<Player>()))
				{
					throw new MissingReferenceException($"The singleton reference to a Player does not found!");
				}
			}

			return Reference;
		}
	}

	public static bool HasReference
	{
		get
		{
			if (Reference == null)
			{
				return (Reference = FindObjectOfType<Player>()) != null;
			}

			return true;
		}
	}

	protected virtual void Awake()
	{
		if (isDontDestroy)
		{
			DontDestroyOnLoad(Instance);
		}
	}

	public override void Damage(ArmorType type, float damag)
	{
		if (InventoryController.HasReference && _InventoryController == null)
		{
			_InventoryController = InventoryController.Instance;
		}
		for (int i = 0; i < _InventoryController.CellsType.Length; i++)
		{
			if(_InventoryController.CellsType[i].ArmorType == type && _InventoryController.CellsType[i].IDItem != -1)
			{
				var armor = (_InventoryController.Items[_InventoryController.CellsType[i].IDItem] as Clothes).Armor;
				damag -= armor;
				if(damag <= 0)
				{
					damag = 1;
				}
				Damage(damag);
				return;
			}
		}
		Damage(damag);
	}

	public override void Kill()
	{
		throw new System.NotImplementedException();
	}
}