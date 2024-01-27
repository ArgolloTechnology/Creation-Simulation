using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	private bool isDragging = false;
	private bool isRightClick = false;
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

		// Adiciona a l�gica de clicar com o bot�o direito para duplicar o objeto
		if (Input.GetMouseButtonDown(1))  // Bot�o direito do mouse
		{
			isRightClick = true;
			DuplicateSelectedObject();
		}

		if (Input.GetMouseButtonUp(1))  // Libera o bot�o direito do mouse
		{
			isRightClick = false;
		}
	}

	private void DuplicateSelectedObject()
	{
		if (selectedObject != null && isRightClick)
		{
			// Duplica o objeto selecionado
			DraggableObject duplicatedObject = Instantiate(selectedObject, selectedObject.transform.position, Quaternion.identity);
			StartDragging(duplicatedObject);
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
