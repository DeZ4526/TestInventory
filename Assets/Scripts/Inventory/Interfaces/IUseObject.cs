using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Inventory
{
	public interface IUseObject
	{
		public bool Use();
		public string GetUIText();
	}
}