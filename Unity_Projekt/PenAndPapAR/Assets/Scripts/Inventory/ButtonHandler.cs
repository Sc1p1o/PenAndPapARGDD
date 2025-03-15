using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public PopupManager popupManager;
    public string NameText;
    public string DescriptionText;
    public string WeightText;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => popupManager.OpenPopup(NameText, DescriptionText, WeightText));
    }
}
