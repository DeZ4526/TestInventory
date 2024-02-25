using Test.GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagerUI : MonoBehaviour
{
	[SerializeField] private Image progress;
	[SerializeField] private TMP_Text hpUIText;
	[SerializeField] private Damager damager;

	private void Awake()
	{
		damager.OnDamage.AddListener(Reload);
		Reload();
	}
	public void Reload()
	{
		if (hpUIText != null)
		{
			hpUIText.text = damager.Hp.ToString();
		}

		if(progress != null)
		{
			progress.fillAmount = damager.Hp / 100;
		}
	}
}
