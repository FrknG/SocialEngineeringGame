using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableNPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    [SerializeField] private string ChatText;
    public PlayerInteractUI playerInteractUI;
   
    public GameObject chatbubble;
    public void Interact(Transform interactor)
    {
        if (playerInteractUI.IsInteracting)
        {
            Talk();
        }
             
    }  

    
    public Transform GetTransform()
    {
        return transform;
    }

    public string GetIntText()
    {
        return iText;
    }

    public void Talk()
    {
         Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
         chatbubble.SetActive(true);
    }
    public string GetChatText()
    {
        return ChatText;
    }
}
