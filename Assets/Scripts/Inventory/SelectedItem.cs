using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class SelectedItem : MonoBehaviour
    {
        [SerializeField] private Transform _playerPosition;

        public void CreateItem(Image image)
        {
            if (image.sprite == null) return;
            Vector3 createPosition = _playerPosition.position;
            Instantiate(Resources.Load<GameObject>("Objects/" + image.sprite.name), createPosition, Quaternion.identity);
        }
    }
}