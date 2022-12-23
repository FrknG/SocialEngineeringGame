using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, InteractableInterface
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private string iText;
    public PlayerInteractUI playerInteractUI;

    public void UpdateDialogueObject (DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract playerInteract))
        {
            playerInteract.Interactable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerInteract playerInteract))
        {
            if(playerInteract.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                playerInteract.Interactable = null;
            }
        }
    }


    public void Interact(PlayerInteract playerInteract)
    {

        if(dialogueObject != null && playerInteract.DialogueUI.IsOpen == false )
        {

        
            playerInteract.DialogueUI.ShowDialogue(dialogueObject);
        
            foreach(DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
            {
                if(responseEvents.DialogueObject == dialogueObject)
                {
                    playerInteract.DialogueUI.AddResponseEvents(responseEvents.Events);
                    break;
                }
            }

        }
        else if (dialogueObject== null && gameObject.tag == "Interactable")
        {
            gameObject.SetActive(false);
        }
        //playerInteract.DialogueUI.ShowDialogue(dialogueObject);

    }

  

    public string GetIntText()
    {
        return iText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
