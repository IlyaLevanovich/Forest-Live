using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _taget;

        private void Update()
        {
            Vector3 newPosition = new Vector3(_taget.position.x, transform.position.y, _taget.position.z - 4);
            transform.position = newPosition;
        }
    }
}