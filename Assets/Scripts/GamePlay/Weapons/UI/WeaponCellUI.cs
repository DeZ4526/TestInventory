using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test.GamePlay.Weapons.UI
{
   public class WeaponCellUI : MonoBehaviour
   {
      [SerializeField] private Image icon;
		[SerializeField] private Button button;

      private WeaponUI _weaponUI;
		private WeaponController _weaponController;
		private Weapon _weapon;

      

		public void Init(Weapon weapon)
      {
         _weapon = weapon;
         icon.sprite = weapon.Ico;

			if (WeaponController.HasReference)
         {
            _weaponUI = WeaponUI.Instance;
				_weaponController = WeaponController.Instance;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
            GetComponent<Image>().color = _weaponController.SelectedWeapon.Equals(weapon) ? Color.green : Color.white;
            
			}
		}

      private void OnClick()
      {
         _weaponController.SelectedWeapon = _weapon;
         _weaponUI.Reload();

		}
   }
}