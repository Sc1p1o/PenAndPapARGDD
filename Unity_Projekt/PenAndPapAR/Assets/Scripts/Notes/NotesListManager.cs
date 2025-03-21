using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI; // MRTK UI namespace
using Microsoft.MixedReality.Toolkit.Input; // Add this for NearInteractionTouchable
using Microsoft.MixedReality.Toolkit;

public class NotesListManager : MonoBehaviour
{
    public GameObject noteTitlePrefab; // Prefab for note titles
    public Transform contentTransform; // Content container for the note titles
    public GameObject listPanel; // Panel for the note list
    public GameObject writingPanel; // Panel for writing/editing a note
    public TMP_InputField notesInputField; // Input field for note content
    public TMP_InputField titleInputField; // Input field for note title

    public GameObject notesButton; // The "Notes" button
    public GameObject closeListButton; // The "Close List" button 

    private string currentEditingNoteTitle = ""; // Tracks the currently edited note
    private Dictionary<string, string> savedNotes = new Dictionary<string, string>(); // Stores notes by title

    public NotepadInteraction notepadInteraction; // Reference to the NotepadInteraction script

    private void Start()
{
    // Ensure list panel is active initially
    listPanel.SetActive(false); // Initially hide the list
    writingPanel.SetActive(false); // Hide writing panel
    notesButton.SetActive(true); // Show "Notes" button
    closeListButton.SetActive(false); // Hide close list button initially
    
    // Set up buttons with proper interactivity
    SetupHoloLensButton(notesButton, OpenNotesList);
    SetupHoloLensButton(closeListButton, CloseNotesList);
    
    PopulateNoteList(); // Populate the list if needed
    
    // Add debug logs to check button setup
    Debug.Log("NotesListManager started, buttons configured");
}
    
    // Helper method to set up HoloLens interactable buttons
    private void SetupHoloLensButton(GameObject buttonObject, UnityEngine.Events.UnityAction callback)
{
    // Ensure the button has a box collider
    if (buttonObject.GetComponent<BoxCollider>() == null)
    {
        BoxCollider boxCollider = buttonObject.AddComponent<BoxCollider>();
        // Set appropriate size for the collider
        boxCollider.size = new Vector3(0.1f, 0.1f, 0.02f);
        boxCollider.isTrigger = true;
    }

    // Check if the button already has a PressableButton component
    PressableButton pressableButton = buttonObject.GetComponent<PressableButton>();
    if (pressableButton == null)
    {
        // Add PressableButton component for HoloLens interaction
        pressableButton = buttonObject.AddComponent<PressableButton>();
    }
    
    // Add NearInteractionTouchable for hand interaction
    NearInteractionTouchable touchable = buttonObject.GetComponent<NearInteractionTouchable>();
    if (touchable == null)
    {
        touchable = buttonObject.AddComponent<NearInteractionTouchable>();
    }
    touchable.SetLocalCenter(Vector3.zero);
    touchable.SetBounds(new Vector3(0.1f, 0.1f, 0.02f)); // Adjust size as needed
    
    // Set up the button events
    ButtonConfigHelper buttonConfig = buttonObject.GetComponent<ButtonConfigHelper>();
    if (buttonConfig == null)
    {
        buttonConfig = buttonObject.AddComponent<ButtonConfigHelper>();
    }
    
    // Clear any existing listeners to avoid duplicates
    buttonConfig.OnClick.RemoveAllListeners();
    // Add the new callback
    buttonConfig.OnClick.AddListener(callback);
    
    // For debugging - verify the button is properly set up
    Debug.Log($"Button {buttonObject.name} configured with PressableButton and callback");
}

    // Method to update note title buttons to be HoloLens compatible
    private void AddNoteToList(string noteTitle)
    {
        // Instantiate the note title button
        GameObject newButton = Instantiate(noteTitlePrefab, contentTransform);

        // Ensure the new button's TMP_Text is updated
        TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
        if (buttonText != null)
        {
            buttonText.text = noteTitle; // Set the button's title
            Debug.Log($"Title set to: {noteTitle}");
        }
        else
        {
            Debug.LogError("TMP_Text component not found in noteTitlePrefab.");
        }

        // Add HoloLens interactability
        PressableButton pressableButton = newButton.GetComponent<PressableButton>();
        if (pressableButton == null)
        {
            pressableButton = newButton.AddComponent<PressableButton>();
            
            // Add NearInteractionTouchable for hand interaction
            var touchable = newButton.AddComponent<NearInteractionTouchable>();
            touchable.SetLocalCenter(Vector3.zero);
            touchable.SetBounds(new Vector3(0.1f, 0.1f, 0.02f)); // Adjust size as needed
        }
        
        // Set up the title button click event
        ButtonConfigHelper buttonConfig = newButton.GetComponent<ButtonConfigHelper>();
        if (buttonConfig == null)
        {
            buttonConfig = newButton.AddComponent<ButtonConfigHelper>();
        }
        
        string capturedTitle = noteTitle; // Capture for lambda
        buttonConfig.OnClick.AddListener(() => LoadNote(capturedTitle));
    }

    // Rest of your methods remain the same
    public void AddNewNote()
    {
        // Clear input fields for a new note
        notesInputField.text = "";
        titleInputField.text = "";
        currentEditingNoteTitle = "";

        // Switch to writing panel
        listPanel.SetActive(false);
        writingPanel.SetActive(true);
    }

    public void SaveNote()
    {
        string noteTitle = titleInputField.text.Trim();
        string noteContent = notesInputField.text;

        if (string.IsNullOrEmpty(noteTitle))
        {
            Debug.LogWarning("Note title cannot be empty!");
            return; // Ensure a title is provided
        }

        // Save the note in the dictionary
        if (savedNotes.ContainsKey(noteTitle))
        {
            savedNotes[noteTitle] = noteContent; // Update existing note
        }
        else
        {
            savedNotes.Add(noteTitle, noteContent); // Add new note
            AddNoteToList(noteTitle); // Add title to the list
        }

        Debug.Log($"Note saved: {noteTitle}");

        // Return to the list panel
        SwitchToListPanel();
    }

    public void LoadNote(string noteTitle)
    {
        if (savedNotes.TryGetValue(noteTitle, out string noteContent))
        {
            // Populate input fields
            titleInputField.text = noteTitle;
            notesInputField.text = noteContent;
            currentEditingNoteTitle = noteTitle;

            // Switch to the writing panel
            listPanel.SetActive(false);
            writingPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Note not found: {noteTitle}");
        }
    }

    public void SwitchToListPanel()
    {
        // Return to the list panel
        writingPanel.SetActive(false);
        listPanel.SetActive(true);
    }

    public void CloseListPanel()
    {
        listPanel.SetActive(false);
        // Rotate the notepad back to 90 degrees (closed position)
        if (notepadInteraction != null)
        {
            notepadInteraction.RotateNotepadBack(); // Rotate to 90 degrees
        }
    }

    private void PopulateNoteList()
    {
        // Clear existing children in the contentTransform
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }

        // Populate the list with saved notes (if any)
        foreach (var noteTitle in savedNotes.Keys)
        {
            AddNoteToList(noteTitle);
        }
    }

    // Close the Notes list when clicking the "Close List" button
    public void CloseNotesList()
    {
        notesButton.SetActive(true); // Show the "Notes" button again
        closeListButton.SetActive(false); // Hide the "Close List" button
        listPanel.SetActive(false); // Hide the notes list
        // Rotate the notepad back to 90 degrees (closed position)
        if (notepadInteraction != null)
        {
            notepadInteraction.RotateNotepadBack(); // Rotate to 90 degrees
        }
    }

    // Show the Notes list when clicking the "Notes" button
    public void OpenNotesList()
    {
        Debug.Log($"Clickedddddddd");
        notesButton.SetActive(false); // Hide the "Notes" button
        closeListButton.SetActive(true); // Show the "Close List" button
        listPanel.SetActive(true); // Show the notes list

        // Rotate the notepad to 30 degrees (open position)
        if (notepadInteraction != null)
        {
            notepadInteraction.RotateNotepadToOpen(); // Rotate to 30 degrees
        }
    }
}