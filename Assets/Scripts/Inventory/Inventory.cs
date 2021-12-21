using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Image[] _slots;
        private Dictionary<string, int> _content = new Dictionary<string, int>();
        public Dictionary<string, int> Content { get { return _content; } set { _content = value; } }

        private void Start()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                if (current.sprite != null)
                    _content.Add(current.sprite.name, int.Parse(current.GetComponentInChildren<Text>().text));
            }
        }

        public void AddItem(string name)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                if (current.sprite != null && current.sprite.name == name)
                {
                    Text countText = current.GetComponentInChildren<Text>();
                    int count = int.Parse(countText.text) + 1;
                    _content[name]++;
                    countText.text = count.ToString();
                    return;
                }
            }
            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                if(current.sprite == null)
                {
                    current.sprite = Resources.Load<Sprite>(name);
                    current.GetComponentInChildren<Text>().text = 1.ToString();
                    _content.Add(name, 1);
                    break;
                }
            }
        }
        public void UpdateInfo()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                if (current.sprite != null)
                    current.GetComponentInChildren<Text>().text = _content[current.sprite.name].ToString();
            }
        }
    }
}