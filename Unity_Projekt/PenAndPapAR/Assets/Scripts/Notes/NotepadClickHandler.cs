using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class NotepadClickHandler : MonoBehaviour, IPointerClickHandler
{
    public NotesListManager notesListManager; // Reference to the Notes UI Manager
    public float rotationDuration = 0.5f; // Duration of rotation
    public float openRotationX = 30f; // Rotation when open
    public float closedRotationX = 90f; // Rotation when closed
    private bool isOpen = false; // Tracks if the notepad is open
    private bool isRotating = false; // Prevents multiple rotations

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Notepad clicked via pointer!");
        if (isRotating) return; // Prevent clicking while rotating

        if (notesListManager != null)
        {
            if (isOpen)
            {
                notesListManager.CloseNotesList();
                StartCoroutine(RotateNotepad(closedRotationX)); // Rotate back to closed position
            }
            else
            {
                notesListManager.OpenNotesList();
                StartCoroutine(RotateNotepad(openRotationX)); // Rotate to open position
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
}
