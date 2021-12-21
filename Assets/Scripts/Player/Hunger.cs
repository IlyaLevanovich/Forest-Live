using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    public class Hunger : MonoBehaviour
    {
        [SerializeField] private Image _hungerBar;
        [SerializeField] private Inventory.Inventory _inventory;
        private int _maxHunger = 180;

        public void Eat(int id)
        {
            
        }

        private void Update()
        {
            _hungerBar.fillAmount -= Time.deltaTime / _maxHunger;
        }
    }
}