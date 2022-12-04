using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    public void Interact(Transform interactor)
    {
        Debug.Log("Speaking to " +GetIntText());
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public string GetIntText()
    {
        return iText;
    }
}
