using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Image[] _slots;
        [SerializeField] private Image _currentItem;
        private Text[] _slotsText;

        private Dictionary<string, int> _content = new Dictionary<string, int>();
        public Dictionary<string, int> Content { get { return _content; } set { _content = value; } }

        private void Start()
        {
            _slotsText = new Text[_slots.Length];

            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                _slotsText[i] = current.GetComponentInChildren<Text>();
                if (current.sprite != null)
                    _content.Add(current.sprite.name, int.Parse(_slotsText[i].text));
            }
        }

        public void AddItem(string name)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                var current = _slots[i];
                if (current.sprite != null && current.sprite.name == name)
                {
                    int count = int.Parse(_slotsText[i].text) + 1;
                    _content[name]++;
                    _slotsText[i].text = count.ToString();
                    if (current.sprite == _currentItem.sprite)
                        _currentItem.GetComponentInChildren<Text>().text = _slotsText[i].text;
                    return;
                }
            }
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].sprite == null)
                {
                    _slots[i].sprite = Resources.Load<Sprite>(name);
                    _slotsText[i].text = 1.ToString();
                    _content.Add(name, 1);
                    return;
                }
            }
        }

        public void UpdateInfo()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if(_slots[i].sprite != null)
                    _slotsText[i].text = _content[_slots[i].sprite.name].ToString();
                if (int.Parse(_slotsText[i].text) == 0)
                    _slots[i].sprite = null;
            }
        }
        public void SetCurrentItem(Image image)
        {
            if (image.sprite == null) return;
            _currentItem.sprite = image.sprite;
            _currentItem.GetComponentInChildren<Text>().text = image.GetComponentInChildren<Text>().text;
        }
    }
}