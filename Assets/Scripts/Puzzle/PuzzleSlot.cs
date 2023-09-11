using UnityEngine;
using UnityEngine.UI;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField] private string targetPuzzleName;
    [SerializeField] private bool slotOccupied = false;

    [SerializeField] private Image puzzleImage;
    [SerializeField] private GameObject btnText;
    [SerializeField] private Button interactButton;

    private RectTransform rect;

    public delegate void PuzzleSlotDelegate(bool status);
    public static event PuzzleSlotDelegate OnSlotOccupied;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void OnSlotFilled()
    {
        btnText.SetActive(true);
        puzzleImage.enabled = true;
        interactButton.interactable = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(slotOccupied)
        {
            return;
        }

        if (col.GetComponent<DragObject>() != null)
        {
            DragObject dragObject = col.GetComponent<DragObject>();

            if (dragObject.isDragging)
            {
                return;
            }

            if (targetPuzzleName != dragObject.PuzzleName)
            {
                OnSlotOccupied?.Invoke(false);
                dragObject.SetPostion();
                return;
            }

            slotOccupied = true;
            OnSlotOccupied?.Invoke(true);
            dragObject.DeactiveObj();
            OnSlotFilled();
        }
    }
}
