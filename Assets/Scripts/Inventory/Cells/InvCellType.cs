using Newtonsoft.Json;
using Test.Inventory.Enums;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
   public class InvCellType : InvCell
   {
		[JsonIgnore]
		[SerializeField] private InvIntemType type;
		[JsonIgnore]
		[SerializeField] private string title;
		[JsonIgnore]
		[SerializeField] private ArmorType armorType;

		public ArmorType ArmorType { get => armorType; }
		public InvIntemType Type { get => type; }
		public string Title { get => title; }
	}
}