using UnityEngine;
using Utils;

public class ImportDataManager : MonoBehaviour
{
    // Referenz zum Panel
    public GameObject characterSheetPanel;

    // Standard-Link
    private string defaultLink = "https://www.dndbeyond.com/characters/137425320";

    // Key für PlayerPrefs (zum Speichern des Links)
    private const string LastSheetLinkKey = "LastSheetLink";

    void Start()
    {
        // Deaktiviere das Panel beim Start
        if (characterSheetPanel != null)
        {
            characterSheetPanel.SetActive(false);
        }
    }

    // Methode, um das Panel zu öffnen oder zu schließen
    public void OnOpenCharacterSheetButtonClick()
    {
        if (characterSheetPanel != null)
        {
            // Schalte die Sichtbarkeit des Panels um
            characterSheetPanel.SetActive(!characterSheetPanel.activeSelf);
        }
    }

    // Methode für den Cancel Button (Panel schließen)
    public void OnCancelButtonClick()
    {
        Debug.Log("Cancel Button wurde gedrückt");
        if (characterSheetPanel != null)
        {
            // Deaktiviere das Panel
            characterSheetPanel.SetActive(false);
        }
    }

    // Methode für den Add Button (ohne Funktion)
    public void OnAddButtonClick()
    {
        // Lade den zuletzt gespeicherten Link
        string lastSheetLink = PlayerPrefs.GetString(LastSheetLinkKey, defaultLink);

        Debug.Log(lastSheetLink);

    }

    // Methode für den Load Button (letzten oder Standard-Link laden)
    public void OnLoadButtonClick()
    {
        Debug.Log("Load Button pressed, calling LoadCharacterData");

        // Call the static method with the character ID "#0000"
        DBConnector.LoadCharacterData("#0000");

    }

    // Methode, um den aktuellen Link zu speichern
    public void SaveSheetLink(string link)
    {
        if (!string.IsNullOrEmpty(link))
        {
            // Speichere den Link in PlayerPrefs
            PlayerPrefs.SetString(LastSheetLinkKey, link);
            PlayerPrefs.Save(); // Speichern der Änderungen
            Debug.Log("Sheet-Link gespeichert: " + link);
        }
    }
}