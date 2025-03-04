using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragBasket : MonoBehaviour, IDropHandler 
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ondrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

}
