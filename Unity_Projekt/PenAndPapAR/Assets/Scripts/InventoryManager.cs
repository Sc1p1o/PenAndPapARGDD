using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Items[] items;
    public GameObject buttonPrefab;
    public GameObject buttonContainer;
    public GameObject inventoryPanel;
    public BackPackInteraction backPackInteraction;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void OpenInventoryPanel()
    {
        inventoryPanel.SetActive(true); // Show the inventory

        foreach (Items item in items)
        {
            GameObject go = Instantiate(buttonPrefab);
            go.transform.SetParent(buttonContainer.transform);
            go.GetComponent<ItemButton>().item = item;
            go.GetComponent<ItemButton>().setUI();
        }

        // Simulate a click on the backpack to open it
        if (backPackInteraction != null)
        {
            backPackInteraction.OnMouseDown();
        }
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.SetActive(false); // Hide the inventory

        // Simulate a click on the backpack to close it
        if (backPackInteraction != null)
        {
            backPackInteraction.OnMouseDown();
        }
    }
}
