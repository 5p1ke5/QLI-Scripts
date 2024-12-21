using UnityEngine;

//!  Makes doors open when near player.
/*!
  Detects the location of the player object. If the player object is within range opens the door.
*/
public class DoorInteraction : MonoBehaviour
{
    public GameObject door;   // Assign the main door GameObject
    public GameObject handle; // Assign the handle GameObject
    public GameObject glass;  // Assign the first glass GameObject
    public GameObject glass1; // Assign the second glass GameObject

    public Vector3 doorPositionOffset;    // Position offset for the door when open
    public Vector3 doorRotationOffset;    // Rotation offset for the door when open
    public Vector3 handlePositionOffset;  // Position offset for the handle when open
    public Vector3 handleRotationOffset;  // Rotation offset for the handle when open
    public Vector3 glassPositionOffset;   // Position offset for the glass when open
    public Vector3 glassRotationOffset;   // Rotation offset for the glass when open
    public Vector3 glass1PositionOffset;  // Position offset for glass1 when open
    public Vector3 glass1RotationOffset;  // Rotation offset for glass1 when open

    public float positionSpeed = 1f;
    public float rotationSpeed = 1f;

    private Vector3 doorOriginalPosition;
    private Quaternion doorOriginalRotation;
    private Vector3 handleOriginalPosition;
    private Quaternion handleOriginalRotation;
    private Vector3 glassOriginalPosition;
    private Quaternion glassOriginalRotation;
    private Vector3 glass1OriginalPosition;
    private Quaternion glass1OriginalRotation;

    private Quaternion doorTargetRotation;
    private Quaternion handleTargetRotation;
    private Quaternion glassTargetRotation;
    private Quaternion glass1TargetRotation;

    private bool isOpen = false;

    void Start()
    {
        // Store the original positions and rotations
        doorOriginalPosition = door.transform.localPosition;
        doorOriginalRotation = door.transform.localRotation;
        handleOriginalPosition = handle.transform.localPosition;
        handleOriginalRotation = handle.transform.localRotation;
        glassOriginalPosition = glass.transform.localPosition;
        glassOriginalRotation = glass.transform.localRotation;
        glass1OriginalPosition = glass1.transform.localPosition;
        glass1OriginalRotation = glass1.transform.localRotation;

        // Calculate the target rotations
        doorTargetRotation = Quaternion.Euler(doorOriginalRotation.eulerAngles + doorRotationOffset);
        handleTargetRotation = Quaternion.Euler(handleOriginalRotation.eulerAngles + handleRotationOffset);
        glassTargetRotation = Quaternion.Euler(glassOriginalRotation.eulerAngles + glassRotationOffset);
        glass1TargetRotation = Quaternion.Euler(glass1OriginalRotation.eulerAngles + glass1RotationOffset);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") || other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            isOpen = !isOpen;  // Toggle the state
        }
    }

    void Update()
    {
        if (isOpen)
        {
            // Rotate and move to open positions
            door.transform.localRotation = Quaternion.Lerp(door.transform.localRotation, doorTargetRotation, Time.deltaTime * rotationSpeed);
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, doorOriginalPosition + doorPositionOffset, Time.deltaTime * positionSpeed);

            handle.transform.localRotation = Quaternion.Lerp(handle.transform.localRotation, handleTargetRotation, Time.deltaTime * rotationSpeed);
            handle.transform.localPosition = Vector3.Lerp(handle.transform.localPosition, handleOriginalPosition + handlePositionOffset, Time.deltaTime * positionSpeed);

            glass.transform.localRotation = Quaternion.Lerp(glass.transform.localRotation, glassTargetRotation, Time.deltaTime * rotationSpeed);
            glass.transform.localPosition = Vector3.Lerp(glass.transform.localPosition, glassOriginalPosition + glassPositionOffset, Time.deltaTime * positionSpeed);

            glass1.transform.localRotation = Quaternion.Lerp(glass1.transform.localRotation, glass1TargetRotation, Time.deltaTime * rotationSpeed);
            glass1.transform.localPosition = Vector3.Lerp(glass1.transform.localPosition, glass1OriginalPosition + glass1PositionOffset, Time.deltaTime * positionSpeed);
        }
        else
        {
            // Reset to closed positions and rotations
            door.transform.localRotation = Quaternion.Lerp(door.transform.localRotation, doorOriginalRotation, Time.deltaTime * rotationSpeed);
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, doorOriginalPosition, Time.deltaTime * positionSpeed);

            handle.transform.localRotation = Quaternion.Lerp(handle.transform.localRotation, handleOriginalRotation, Time.deltaTime * rotationSpeed);
            handle.transform.localPosition = Vector3.Lerp(handle.transform.localPosition, handleOriginalPosition, Time.deltaTime * positionSpeed);

            glass.transform.localRotation = Quaternion.Lerp(glass.transform.localRotation, glassOriginalRotation, Time.deltaTime * rotationSpeed);
            glass.transform.localPosition = Vector3.Lerp(glass.transform.localPosition, glassOriginalPosition, Time.deltaTime * positionSpeed);

            glass1.transform.localRotation = Quaternion.Lerp(glass1.transform.localRotation, glass1OriginalRotation, Time.deltaTime * rotationSpeed);
            glass1.transform.localPosition = Vector3.Lerp(glass1.transform.localPosition, glass1OriginalPosition, Time.deltaTime * positionSpeed);
        }
    }
}


