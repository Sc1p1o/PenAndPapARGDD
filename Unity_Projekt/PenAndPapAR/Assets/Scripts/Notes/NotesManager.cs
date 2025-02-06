using UnityEngine;
using TMPro;

public class NotesManager : MonoBehaviour
{
    public TMP_InputField notesInputField; // Assign in the Inspector
    public TMP_InputField titleInputField; // For the title
    public GameObject notesPanel; // Assign your Panel in the Inspector

    private void Start()
    {
        // Optional: Load saved notes on start
        if (notesInputField != null)
        {
            notesInputField.text = PlayerPrefs.GetString("PlayerNotes", ""); // Load saved notes
        }
    }

    public void SaveNotes()
    {
        string notes = notesInputField.text;
        PlayerPrefs.SetString("PlayerNotes", notes); // Save notes locally
    }

    public void ClosePanel()
    {
        notesPanel.SetActive(false); // Hides the panel
    }
}
