using Test.Inventory;
using Test.Inventory.UI;
using UnityEngine;

namespace Test.GamePlay.Weapons
{
	[System.Serializable]
	public class Weapon
	{
		[SerializeField] private Sprite ico;
		[SerializeField] private float damag;
		[SerializeField] private int ammoId;

		

		public Sprite Ico { get => ico;  }
		public float Damag { get => damag; }
		public int AmmoId { get => ammoId; }

		public void Attack(Damager damager)
		{
			
			damager.Damage(Damag);
		}
	}
}