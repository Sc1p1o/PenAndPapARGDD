using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Items[] items;
    public GameObject buttonPrefab;
    public GameObject buttonContainer;

    private void Start()
    {
        foreach(Items items in items)
        {
            GameObject go = Instantiate(buttonPrefab);
            go.transform.SetParent(buttonContainer.transform);
            go.GetComponent<ItemButton>().item = items;
            go.GetComponent<ItemButton>().setUI();
        }
    }
}
