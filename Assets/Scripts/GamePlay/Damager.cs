using Test.Inventory.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Test.GamePlay
{
	public abstract class Damager : MonoBehaviour
	{
		[SerializeField] protected float hp;

		public UnityEvent OnDamage;

		public float Hp { get => hp; }
		public virtual void Damage(float damag)
		{
			if (hp <= 0) return;
			hp -= damag;
			if (hp <= 0)
			{
				Kill();
			}
			OnDamage?.Invoke();
		}
		public virtual void Heal(float val)
		{
			hp = hp + val > 100 ? 100 : hp + val;
			OnDamage?.Invoke();
		}
		abstract public void Damage(ArmorType type, float damag);
		abstract public void Kill();
	}
}