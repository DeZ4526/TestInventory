using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Test.Inventory.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class InventoryUseUI : SingletonMono<InventoryUseUI>
	{
		[SerializeField] private Image icoImage;
		[SerializeField] private TMP_Text descriptionText;
		[SerializeField] private TMP_Text nameText;
		[SerializeField] private TMP_Text useButtonText;
		[SerializeField] private TMP_Text armorText;
		[SerializeField] private TMP_Text massText;
		[SerializeField] private Button useButton;
		[SerializeField] private Button deleteButton;
		[SerializeField] private Button hideButton;

		private InventoryUI _inventoryUI;
		private InventoryController _inventoryController;
		private IUseObject _useObject;
      private InvCell _cell;

		private CanvasGroup _group;

		private CanvasGroup Group
		{
			get
			{
				if (_group == null)
				{
					_group = GetComponent<CanvasGroup>();
				}

				return _group;
			}
		}
		protected override void Awake()
      {
         base.Awake ();
         if (InventoryUI.HasReference)
         {
				_inventoryUI = InventoryUI.Instance;
         }
			if (InventoryController.HasReference)
			{
				_inventoryController = InventoryController.Instance;
			}
			useButton.onClick.RemoveAllListeners();
			useButton.onClick.AddListener(Use);

			hideButton.onClick.RemoveAllListeners();
			hideButton.onClick.AddListener(Hide);

			deleteButton.onClick.RemoveAllListeners();
			deleteButton.onClick.AddListener(Delete);
		}

      public void Show(InvItem item, InvCell cell)
      {
			
			_cell = cell;
			icoImage.sprite = item.Icon;
			Group.alpha = 1.0f;
			Group.interactable = true;
			Group.blocksRaycasts = true;
			item = _inventoryController.Items[cell.IDItem];
			descriptionText.text = item.Description;
			nameText.text = item.Name;
			if (item is Clothes clothes) {
				armorText.text = "+" + clothes.Armor.ToString();
			}
			else
			{
				armorText.text = "0";
			}
			massText.text = (item.Weight * cell.Num).ToString() + " Í„.";
			if (item is IUseObject useObject)
			{
				useButton.gameObject.SetActive(true);
				_useObject = useObject;
				useButtonText.text = _useObject.GetUIText();
			}
			else
			{
				useButton.gameObject.SetActive(false);
			}
		}
      public void Hide()
      {
			Group.alpha = 0f;
			Group.interactable = false;
			Group.blocksRaycasts = false;
			_useObject = null;
		}
      public void Use()
      {
			if (_useObject != null &&_useObject.Use())
			{
				_cell.Num--;
				_inventoryUI.Reload();
				Hide();
			}
		}
		public void Delete()
		{
			_cell.Num = 0;
			_cell.IDItem = -1;
			_inventoryUI.Reload();
			Hide();
		}
   }
}
