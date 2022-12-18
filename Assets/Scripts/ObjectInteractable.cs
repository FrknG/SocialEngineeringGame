using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteractable : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    [SerializeField] private string ChatText;
    public PlayerInteractUI playerInteractUI;

    public GameObject chatbubble;

    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject ChatTextObject;

    public string GetChatText()
    {
        return ChatText;
    }

    public string GetIntText()
    {
        return iText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactor)
    {
        Use();
    }

    public void Use()
    {
        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        chatbubble.SetActive(true);
    }

    public int Choicemade;


    public void Option1()
    {
        //cText.text = "Opt 3";
    }

    public void Option2()
    {
        //cText.text = "Opt 4";
    }
}
