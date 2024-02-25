using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Test.Save.Bridges;
using UnityEngine;

namespace Test.Save
{
	public class SaveController : SingletonMono<SaveController>
	{
		private readonly List<Bridge> _bridges = new();
		[HideInInspector] public List<InfoSave> Saves = new();
		private readonly JsonSerializerSettings _settings = new() { TypeNameHandling = TypeNameHandling.All };

		public void RegBridge(Bridge bridge)
		{
			_bridges.Add(bridge);
		}
		public void Save()
		{
			Saves.Clear();
			_bridges.ForEach(b => Saves.Add(b.OnSave()));
			File.WriteAllText("Save", JsonConvert.SerializeObject(Saves, _settings));
		}
		public void Load()
		{
			if (File.Exists("Save"))
			{
				var json = File.ReadAllText("Save");
				List<InfoSave> saves = (List<InfoSave>)JsonConvert.DeserializeObject(json, _settings);
				for (int i = 0; i < _bridges.Count; i++)
				{
					_bridges[i].OnLoad(saves[i]);
				}
			}
			else
			{
				Save();
			}
		}
	}
}