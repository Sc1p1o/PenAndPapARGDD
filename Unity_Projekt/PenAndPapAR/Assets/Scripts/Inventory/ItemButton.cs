using UnityEngine;
using TMPro;

namespace Inventory
{
    public class ItemButton : MonoBehaviour
    {
        public TextMeshProUGUI buttonText;
        public Items item;

        public void setUI()
        {
            buttonText.text = item.itemName;
        }
        public void ButtonPressed()
        {
            DescriptionBoxManager.SetUI(item);
        }
    }
}