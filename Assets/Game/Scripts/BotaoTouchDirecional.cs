using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoTouchDirecional : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool estaPressionado { get; private set; }

    public void OnPointerDown(PointerEventData eventData) => estaPressionado = true;
    public void OnPointerUp(PointerEventData eventData) => estaPressionado = false;
}