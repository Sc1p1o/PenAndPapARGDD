using UnityEngine;
using System.Collections;

public class NotepadInteraction : MonoBehaviour
{
    public NotesListManager notesListManager; // Reference to the Notes UI Manager
    public float rotationDuration = 0.5f; // Duration of rotation
    public float openRotationX = 30f; // Rotation when open
    public float closedRotationX = 90f; // Rotation when closed

    private bool isOpen = false; // Tracks if the notepad is open
    private bool isRotating = false; // Prevents multiple rotations

    void Start()
    {
        if (notesListManager == null)
        {
            notesListManager = FindObjectOfType<NotesListManager>();
        }

        // Ensure the initial rotation is set correctly
        transform.rotation = Quaternion.Euler(closedRotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void OnMouseDown()
    {
        if (isRotating) return; // Prevent clicking while rotating
        Debug.Log("Notepad clicked!");

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