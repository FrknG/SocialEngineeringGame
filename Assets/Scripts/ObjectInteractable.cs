using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteractable : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    public PlayerInteractUI playerInteractUI;   

    public string GetIntText()
    {
        return iText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
    public void Interact(PlayerInteract playerInteract)
    {
        throw new System.NotImplementedException();
    }

}
