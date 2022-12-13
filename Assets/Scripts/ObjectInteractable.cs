using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, InteractableInterface
{
    public string GetIntText()
    {
        return "Use Laptop";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactor)
    {
        Search();
    }

    public void Search()
    {
        Debug.Log("Using Laptop");
    }
}
