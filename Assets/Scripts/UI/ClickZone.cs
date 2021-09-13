using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickZone : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Pauser _pauser;
    public event Action ONClicked;

    private void Start()
    {
        _pauser.ONStatePauseChanged += SetActive;
    }

    private void SetActive(bool isPaused)
    {
        gameObject.SetActive(!isPaused);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ONClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _pauser.ONStatePauseChanged -= SetActive;
    }
}
