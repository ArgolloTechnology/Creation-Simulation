using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	private bool isDragging = false;
	private Vector3 offset;
	public DraggableObject selectedObject;

	private void Update()
	{
		if (isDragging)
		{
			if (selectedObject != null)
			{
				Vector3 targetPos = GetMouseWorldPos() + offset;
				selectedObject.MoveTo(targetPos);
			}
		}
	}

	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.nearClipPlane;
		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	public void StartDragging(DraggableObject obj)
	{
		isDragging = true;
		selectedObject = obj;
		offset = obj.transform.position - GetMouseWorldPos();
	}

	public void StopDragging()
	{
		isDragging = false;
		selectedObject = null;
	}
}
