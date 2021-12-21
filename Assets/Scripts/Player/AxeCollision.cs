using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Collider))]
    public class AxeCollision : MonoBehaviour
    {
        private int _damage = 1;
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }
        private void OnTriggerEnter(Collider other)
        {
            var tree = other.GetComponent<Trees.DestructibleObject>();
            tree?.TakeDamage(_damage);
            _collider.enabled = false;
        }
    }
}