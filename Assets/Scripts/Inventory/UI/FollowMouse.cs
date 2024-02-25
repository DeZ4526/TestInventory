using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	private RectTransform _rectTransform;
	private Vector3 _vector3;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		_vector3 = new Vector3(_rectTransform.rect.width / 2 + 1, _rectTransform.rect.height / 2 + 1);
	}
	void Update()
	{
		_rectTransform.position = Input.mousePosition - _vector3;
	}
}