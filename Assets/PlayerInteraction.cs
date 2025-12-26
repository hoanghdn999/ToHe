using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;

    public Image crosshairImage;
    public TextMeshProUGUI interactText;

    void Start()
    {
        if (interactText != null) interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        // Looking for the door
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactableLayer))
        {
            if (hit.collider.GetComponent<TransitionScene>() != null)
            {
                interactText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<TransitionScene>().EnterDoor();
                }
                return; // Exit early so we don't hit the 'false' logic below
            }
        }

        // If not looking at the door
        interactText.gameObject.SetActive(false);
    }
}