using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab;  // Assign PopupWindow prefab in Unity Inspector
    public Transform popupParent;   // Parent object to store all popups
    public TextMeshProUGUI debugText; // Optional: Debug UI to display events

    private GameObject currentPopup = null; // Tracks the open popup

    public void OpenPopup(string ItemDescription, string ItemWeight, string ItemName)
    {
        // Close existing pop-up if one is open
        if (currentPopup != null)
        {
            Destroy(currentPopup);
        }

        // Create a new pop-up
        currentPopup = Instantiate(popupPrefab, popupParent);
        TextMeshProUGUI NameText = currentPopup.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI DescriptionText = currentPopup.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI WeightText = currentPopup.transform.Find("WeightText").GetComponent<TextMeshProUGUI>();
        Button closeButton = currentPopup.transform.Find("CloseButton").GetComponent<Button>();

        NameText.text = ItemName;
        DescriptionText.text = ItemDescription;
        WeightText.text = ItemWeight;
        closeButton.onClick.AddListener(ClosePopup);
    }

    public void ClosePopup()
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
    }
}
