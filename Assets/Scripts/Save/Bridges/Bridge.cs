using System;
using UnityEngine;

namespace Test.Save.Bridges
{
	public abstract class Bridge : MonoBehaviour
	{
		protected virtual void Awake()
		{
			if (SaveController.HasReference)
			{
				SaveController.Instance.RegBridge(this);
			}
		}
		public abstract Type GetBridgeType();
		public abstract InfoSave OnSave();
		public abstract void OnLoad(InfoSave info);
	}
}