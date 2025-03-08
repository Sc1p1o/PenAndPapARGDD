using UnityEngine;
using UnityEngine.UI;

public class ImportDataManager : MonoBehaviour
{
    public GameObject characterSheetPanel; // Referenz zum Panel
    private InputField inputField; // Private Referenz zum InputField

    void Start()
    {
        // Finde das InputField im Panel
        if (characterSheetPanel != null)
        {
            inputField = characterSheetPanel.GetComponentInChildren<InputField>();
        }

        // Deaktiviere das Panel beim Start
        if (characterSheetPanel != null)
        {
            characterSheetPanel.SetActive(false);
        }
    }

    public void OnOpenCharacterSheetButtonClick()
    {
        if (characterSheetPanel != null)
        {
            // Aktiviere das Panel
            characterSheetPanel.SetActive(true);

            // Setze den Fokus auf das InputField
            if (inputField != null)
            {
                inputField.Select();
                inputField.ActivateInputField();
            }
        }
    }
}