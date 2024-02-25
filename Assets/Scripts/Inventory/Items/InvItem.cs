using Test.Inventory.Enums;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
	public class InvItem
	{
		[SerializeField] protected string name;
		[SerializeField] protected string description;
		[SerializeField] protected Sprite icon;
		[SerializeField] protected int max;
		[SerializeField] protected InvIntemType type;
		[SerializeField] protected float weight;


		public string Name { get => name; set => name = value; }
		public string Description { get => description; set => description = value; }
		public Sprite Icon { get => icon; set => icon = value; }
		public int Max { get => max; set => max = value; }
		public InvIntemType Type { get => type; set => type = value; }
		public float Weight { get => weight; set => weight = value; }

		public InvItem(string name, string description, Sprite icon, int max, InvIntemType type)
		{
			this.Name = name;
			this.Description = description;
			this.Icon = icon;
			this.Max = max;
			this.Type = type;
		}
	}
}