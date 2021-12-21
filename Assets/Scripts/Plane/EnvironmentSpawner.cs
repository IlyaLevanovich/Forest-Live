using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Plane
{
    public class EnvironmentSpawner : MonoBehaviour
    {
        [SerializeField] private int _x, _y;
        [SerializeField] private GameObject[] _trees;
        [SerializeField] private GameObject[] _grass;
        [SerializeField] private GameObject[] _mushrooms;
        [SerializeField] private GameObject[] _stones;

        private void Start()
        {
            CreateEnvironment();
        }
        private void CreateEnvironment()
        {
            for (int x = -_x; x < _x; x += 3)
            {
                for (int y = -_y; y < _y; y += 3)
                {
                    float value = Random.value;
                    if (value >= 0.7f) InstantiateCurrentObject(_trees, x, y);
                    else if (value >= 0.5f) InstantiateCurrentObject(_grass, x, y);
                    else if (value >= 0.3f) InstantiateCurrentObject(_mushrooms, x, y);
                    else if (value >= 0.2f) InstantiateCurrentObject(_stones, x, y);
                }
            }
        }

        private GameObject InstantiateCurrentObject(GameObject[] array, int x, int y)
        {
            var instance = Instantiate(array[Random.Range(0, array.Length)], new Vector3(x, 0, y), Quaternion.identity);
            instance.transform.SetParent(transform);
            return instance;
        }
    }
}

