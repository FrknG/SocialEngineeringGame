using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private string chatText;
    public void Interact(Transform interactor)
    {
        Debug.Log(interactor);
    }

    public string GetChatText()
    {
        return chatText;
    }
}
