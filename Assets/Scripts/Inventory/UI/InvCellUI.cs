using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Test.Inventory.UI
{
	public class InvCellUI : MonoBehaviour, IPointerDownHandler
	{
		[SerializeField] private Button button;
		[SerializeField] private TMP_Text countText;
		[SerializeField] private TMP_Text titleText;
		[SerializeField] private Image iconImage;
		[SerializeField] private GameObject infoGO;
		[SerializeField] private TMP_Text infoText;

		private InvCell _invCell;
		private InventoryController _inventoryController;
		private InventoryUI _inventoryUI;
		private InventoryUseUI _InventoryUseUI;

		public void Init(InvCell cell)
		{
			if (!InventoryController.HasReference || !InventoryUI.HasReference || !InventoryUseUI.HasReference) return;
			_inventoryUI = InventoryUI.Instance;
			_InventoryUseUI = InventoryUseUI.Instance;
			_inventoryController = InventoryController.Instance;
			_invCell = cell;

			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(OnClick);

			Sprite sprite = null;
			
			if (cell is InvCellType cellType)
			{
				titleText.text = cellType.Title;
				sprite = cellType.Sprite;
				
			}
			else
			{
				titleText.text = "";
				titleText.gameObject.SetActive(false);
			}
			if (cell.IDItem != -1 && cell.Num > 0)
			{
				var item = _inventoryController.Items[cell.IDItem];
				countText.text = cell.Num > 1 ? cell.Num.ToString() : "";
				if (item is Clothes clothes && cell is InvCellType)
				{
					infoGO.SetActive(true);
					infoText.text = clothes.Armor.ToString();
				}
				else
				{
					infoGO.SetActive(false);
				}
				if (item.Icon != null)
					sprite = item.Icon;
				
			}
			else
			{
				countText.text = "";
			}
			iconImage.sprite = sprite;

		}
		public void OnClick()
		{
			Debug.Log("OnClick");
			if (_inventoryController.SelectedItem.IDItem != -1 &&
				_inventoryController.SelectedItem.Num > 0 &&
				(_invCell.IDItem == -1 || _invCell.IDItem == _inventoryController.SelectedItem.IDItem)) 
			{
				if (_invCell is InvCellType cellType)
				{
					_inventoryController.SetItemInCellType(cellType, _inventoryController.SelectedItem);
				}
				else if(_invCell is InvCell)
				{
					_inventoryController.SetItemInCell(_invCell, _inventoryController.SelectedItem);
				}
			}
			else if(_inventoryController.SelectedItem.IDItem == -1 && _invCell.IDItem != -1)
			{
				_inventoryController.SelectedItem = (InvCell)_invCell.Clone();
				_invCell.Clear();
			}
			_InventoryUseUI.Hide();
			_inventoryUI.Reload();
		}

		public void OnPointerDown(PointerEventData eventData) 
		{
			if(eventData.button == PointerEventData.InputButton.Right)
			{
				if((_inventoryController.SelectedItem.Num == 0 || _inventoryController.SelectedItem.IDItem == -1) &&
					_invCell.IDItem != -1)
				{
					_InventoryUseUI.Show(_inventoryController.Items[_invCell.IDItem], _invCell);
				}
			}
		}
	}
}