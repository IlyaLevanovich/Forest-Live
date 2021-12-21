using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class UIPressing : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UnityEvent _onPressed;

        public void OnPointerClick(PointerEventData eventData)
        {
            _onPressed?.Invoke();
        }

    }
}