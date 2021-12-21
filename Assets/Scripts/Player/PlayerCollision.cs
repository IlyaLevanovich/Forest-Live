using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory _inventory;
        [SerializeField] private GameObject _takeButton;
        private string _dropName;
        private GameObject _currentDrop;

        private void OnTriggerEnter(Collider other)
        {
            _takeButton.SetActive(true);
            _dropName = other.tag;
            _currentDrop = other.gameObject;
        }
        private void OnTriggerExit(Collider other)
        {
            _takeButton.SetActive(false);
        }

        public void TakeDrop()
        {
            Destroy(_currentDrop);
            _inventory.AddItem(_dropName);
            _takeButton.SetActive(false);
        }
    }
}