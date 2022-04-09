using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isPointerOverObject = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverObject = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverObject = false;
    }
}
