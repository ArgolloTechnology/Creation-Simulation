using UnityEngine;

public class DraggableObject : MonoBehaviour
{
	private DragAndDrop dragManager;

	private void Start()
	{
		dragManager = FindObjectOfType<DragAndDrop>();
	}

	private void OnMouseDown()
	{
		dragManager.StartDragging(this);
	}

	private void OnMouseUp()
	{
		dragManager.StopDragging();
	}

	public void MoveTo(Vector2 targetPosition)
	{
		transform.position = Vector2.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);
	}
}
