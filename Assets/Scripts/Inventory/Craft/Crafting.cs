using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Inventory.Craft
{
    public class Crafting : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;


        public void TryCraftCampFire() => Craft("/CampFire.json");
        public void TryCraftTent() => Craft("/Tent.json");


        private void Craft(string fileName)
        {
            string info = File.ReadAllText(Application.streamingAssetsPath + fileName);
            var item = JsonConvert.DeserializeObject<CraftItem>(info);

            foreach (var recipe in item.Recipe)
            {
                if (_inventory.Content.ContainsKey(recipe.Key))
                {
                    if (_inventory.Content[recipe.Key] < recipe.Value)
                        return;
                }
            }
            foreach (var recipe in item.Recipe)
                _inventory.Content[recipe.Key] -= recipe.Value;

            _inventory.AddItem(item.Name);
            _inventory.UpdateInfo();
        }
    }
    [System.Serializable]
    public class CraftItem
    {
        public string Name;
        public Dictionary<string, int> Recipe;

    }
}