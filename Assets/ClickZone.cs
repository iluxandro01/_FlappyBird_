using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickZone : MonoBehaviour, IPointerClickHandler
{
    public event Action ONClicked;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ONClicked?.Invoke();
    }
}
