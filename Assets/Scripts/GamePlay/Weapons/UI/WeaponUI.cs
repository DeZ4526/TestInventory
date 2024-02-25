using System.Collections.Generic;
using UnityEngine;

namespace Test.GamePlay.Weapons.UI
{
	public class WeaponUI : SingletonMono<WeaponUI>
	{
		[SerializeField] private WeaponCellUI weaponCell;
		[SerializeField] private Transform weaponCellsContainer;
		private List<WeaponCellUI> _weaponCells = new List<WeaponCellUI>();
		private WeaponController _weaponController;



		protected override void Awake()
		{
			base.Awake();
			if (WeaponController.HasReference)
			{
				_weaponController = WeaponController.Instance;
				Reload();
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		public void Reload()
		{
			_weaponCells.ForEach(i => Destroy(i.gameObject));
			_weaponCells.Clear();
			foreach (var item in _weaponController.Weapons)
			{
				var z = Instantiate(weaponCell, weaponCellsContainer);
				_weaponCells.Add(z);
				z.Init(item);
			}
		}
	}
}