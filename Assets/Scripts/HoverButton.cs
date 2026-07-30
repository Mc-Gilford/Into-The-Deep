using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler
{
    Vector3 original;

    void Start()
    {
        original = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = original * 2.05f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = original;
    }
}
