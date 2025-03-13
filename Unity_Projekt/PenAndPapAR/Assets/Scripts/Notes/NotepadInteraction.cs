using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using System.Collections;

// Update your NotepadInteraction script to implement MRTK input interfaces
public class NotepadInteraction : MonoBehaviour, IMixedRealityInputHandler, IMixedRealityPointerHandler
{
    public NotesListManager notesListManager;
    public float rotationDuration = 0.5f;
    public float openRotationX = 30f;
    public float closedRotationX = 90f;
    private bool isOpen = false;
    private bool isRotating = false;

    void Start()
    {
        if (notesListManager == null)
        {
            notesListManager = FindObjectOfType<NotesListManager>();
        }

        // Register for input events
        Microsoft.MixedReality.Toolkit.CoreServices.InputSystem?.RegisterHandler<IMixedRealityInputHandler>(this);
        Microsoft.MixedReality.Toolkit.CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);

        // Ensure the initial rotation is set correctly
        transform.rotation = Quaternion.Euler(closedRotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void OnDestroy()
    {
        // Unregister from input events when destroyed
        Microsoft.MixedReality.Toolkit.CoreServices.InputSystem?.UnregisterHandler<IMixedRealityInputHandler>(this);
        Microsoft.MixedReality.Toolkit.CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(this);
    }

    // MRTK input handlers
    public void OnInputDown(InputEventData eventData)
    {
        // Handle input down events if needed
    }

    public void OnInputUp(InputEventData eventData)
    {
        // Handle input up events if needed
    }

    // MRTK pointer handlers
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        HandleNotepadClick();
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        // Handle pointer up if needed
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // This will also fire when the notepad is clicked
        // You can use either this or OnPointerDown
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Handle dragging if needed
    }

    // Consolidated click handling logic
    private void HandleNotepadClick()
    {
        if (isRotating) return; // Prevent clicking while rotating
        
        Debug.Log("Notepad clicked via HoloLens!");

        if (notesListManager != null)
        {
            if (isOpen)
            {
                notesListManager.CloseNotesList();
                StartCoroutine(RotateNotepad(closedRotationX)); // Rotate back to 90°
            }
            else
            {
                notesListManager.OpenNotesList();
                StartCoroutine(RotateNotepad(openRotationX)); // Rotate to 30°
            }

            isOpen = !isOpen; // Toggle state
        }
    }

    private IEnumerator RotateNotepad(float targetXRotation)
    {
        isRotating = true;
        float elapsedTime = 0f;
        float startXRotation = transform.eulerAngles.x;

        while (elapsedTime < rotationDuration)
        {
            float newXRotation = Mathf.Lerp(startXRotation, targetXRotation, elapsedTime / rotationDuration);
            transform.rotation = Quaternion.Euler(newXRotation, transform.eulerAngles.y, transform.eulerAngles.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(targetXRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        isRotating = false;
    }

    // Rotate to the open position (30 degrees)
    public void RotateNotepadToOpen()
    {
        StartCoroutine(RotateNotepad(openRotationX));
    }

    // Rotate to the closed position (90 degrees)
    public void RotateNotepadBack()
    {
        StartCoroutine(RotateNotepad(closedRotationX));
    }
}