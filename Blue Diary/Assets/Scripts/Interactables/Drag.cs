using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private CanvasGroup group;
    public void DragHandler(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, pointerEventData.position, canvas.worldCamera, out position);
        transform.position = canvas.transform.TransformPoint(position);
        group.alpha = 0.8f;
        group.blocksRaycasts = false;
    }
    public void DropHandler()
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
    }


    void Update()
    {
        
    }
}
