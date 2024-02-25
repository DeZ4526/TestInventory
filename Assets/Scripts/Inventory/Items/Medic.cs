using Test.Inventory.Enums;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
	public class Medic : InvItem, IUseObject
	{
		[SerializeField] private float hp;
		public float HP { get => hp; }

		public Medic(string name, string description, Sprite icon, int max, InvIntemType type, float hp) : base(name, description, icon, max, type)
			=> this.hp = hp;

		public bool Use()
		{
			if (Player.HasReference)
			{
				Player.Instance.Heal(hp);
			}
			return true;
		}

		public string GetUIText()
			=> "Лечить";
	}
}