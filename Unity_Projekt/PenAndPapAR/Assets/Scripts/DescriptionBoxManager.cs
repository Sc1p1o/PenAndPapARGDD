using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DescriptionBoxManager : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemWeight;
    //public Image itemSprite;

    public Items currentItem;

    private static DescriptionBoxManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            itemName.text = "";
            itemDescription.text = "";
            itemWeight.text = "0";
            //itemSprite.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetUI(Items items)
    {
        instance.currentItem = items;

       // if (!instance.itemSprite.IsActive())
           //- instance.itemSprite.gameObject.SetActive(true); 

        instance.itemName.text = items.name;
        instance.itemDescription.text = items.itemDescription;
        instance.itemWeight.text = items.itemWeight.ToString();
        //instance.itemSprite.sprite = items.itemSprite;

    }
}
