using UnityEngine;
using System.Collections;

public class BackPackInteraction : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float rotationDuration = 0.5f; // Duration of rotation
    public float openRotationX = 30f; // Rotation when open
    public float closedRotationX = 270f; // Rotation when closed
    private bool isOpen = false; // Tracks if the backpack is open
    private bool isRotating = false; // Prevents multiple rotations

    void Start()
    {
        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManager>();
        }

        // Ensure the initial rotation is set correctly
        transform.rotation = Quaternion.Euler(closedRotationX, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void OnMouseDown()
    {
        if (isRotating) return; // Prevent clicking while rotating
        Debug.Log("BackPack clicked!");

        if (inventoryManager != null)
        {
            StartCoroutine(RotateBackPack(isOpen ? closedRotationX : openRotationX));
        }
    }

    private IEnumerator RotateBackPack(float targetXRotation)
    {
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetXRotation, transform.eulerAngles.y, transform.eulerAngles.z);

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation; // Ensure exact rotation at the end

        // Toggle state after rotation completes
        isOpen = !isOpen;

        // Open or close inventory only after rotation completes
        if (isOpen)
        {
            inventoryManager.OpenInventoryPanel();
        }
        else
        {
            inventoryManager.CloseInventoryPanel();
        }

        isRotating = false;
    }
}
