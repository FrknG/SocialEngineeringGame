using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    public GameObject chatbubble;
    public void Interact(Transform interactor)
    {
        Debug.Log("Speaking to " +GetIntText());
        Instantiate(chatbubble, transform.position, Quaternion.identity);
        Destroy(chatbubble, 2);
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
