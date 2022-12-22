using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableNPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    public PlayerInteractUI playerInteractUI;

    
    public Transform GetTransform()
    {
        return transform;
    }

    public string GetIntText()
    {
        return iText;
    }


    public void Interact(PlayerInteract playerInteract)
    {
        Debug.Log("Interacting NPC");
    }

  
}
