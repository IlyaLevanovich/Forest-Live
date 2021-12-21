using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Craft
{
    public class Craft : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Image _result;

        public void TryCraftCampFire()
        {
            int countWood = 2;

            if (_inventory.Content["Wood"] >= countWood)
            {
                _inventory.Content["Wood"] -= countWood;
                _result.gameObject.SetActive(true);
                _result.sprite = Resources.Load<Sprite>("CampFire");
                _inventory.UpdateInfo();
            }
        }
    }
}