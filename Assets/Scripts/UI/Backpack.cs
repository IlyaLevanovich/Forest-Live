using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class Backpack : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _backpack;
        private bool _isBackackStatus;

        public void OnPointerClick(PointerEventData eventData)
        {
            _isBackackStatus = !_isBackackStatus;
            _backpack.SetActive(_isBackackStatus);
        }
    }
}