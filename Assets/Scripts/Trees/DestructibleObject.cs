using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Trees
{
    public class DestructibleObject : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private GameObject _drop;
        [SerializeField] private int _health = 5;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0)
            {
                Instantiate(_drop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}