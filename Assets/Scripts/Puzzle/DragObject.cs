using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    [field: SerializeField] public string PuzzleName { get; private set; }

    [field: SerializeField] public bool isDragging { get; private set; }

    private Vector3 defaultPos;


    // Add this script to the moveable object
    private RectTransform rectTransform;

    Vector3 offset;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        defaultPos = rectTransform.position;
    }

    public void ToggleDragBooelan()
    {
        isDragging = false;
    }

    public void GetOffset()
    {
        offset = rectTransform.position - Input.mousePosition;
    }
    public void MoveObject()
    {
        isDragging = true;

        rectTransform.position = Input.mousePosition + offset;
    }

    public void DeactiveObj()
    {
        gameObject.SetActive(false);
    }

    public void SetPostion()
    {
        rectTransform.position = defaultPos;
    }
}
