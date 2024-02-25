using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Test.Inventory
{
	[System.Serializable]
	public class InvCell: ICloneable
	{
		public int IDItem = -1;
		public int Num;
		[JsonIgnore]
		[SerializeField] private Sprite sprite;
		[JsonIgnore]
		public Sprite Sprite { get => sprite; }

		public void Clear()
		{
			IDItem = -1;
			Num = 0;
		}

		public object Clone()
			=> MemberwiseClone();
	}
}