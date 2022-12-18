using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractableNPC : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    [SerializeField] private string defaultText;
    public PlayerInteractUI playerInteractUI;

    public bool IsTalking;

    public int Choicemade;

    [SerializeField] private GameObject ChatUI;
    [SerializeField] private TextMeshProUGUI cText;
    [SerializeField] private GameObject Choice1;
    [SerializeField] private GameObject Choice2;
    public void Interact(Transform interactor)
    {
        IsTalking = true;

        if (IsTalking)
        {
            ShowText();           
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

    public void ShowText()
    {
        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        ChatUI.SetActive(true);
        cText.text = defaultText;
        Choice1.GetComponent<Button>().onClick.AddListener(Option1);
        Choice2.GetComponent<Button>().onClick.AddListener(Option2);     
    }
    public string GetChatText()
    {
        return defaultText;
    }

    public void Option1()
    {
        if(gameObject.tag == "Aysel")
        {
            cText.text = "Merhaba Furkan";
            Choice1.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "Hi! Yes, I'm here to talk with the Jim";
        }
        if (gameObject.tag == "Seseg")
        {
            cText.text = "Merhaba Seseg";            
        }
        //Choicemade = 1;

    }

    public void Option2()
    {
        cText.text = "Opt 2";
        //Choicemade = 2;
    }

    /*void Update()
    {
        if (Choicemade == 1)
        {
            Choice1.SetActive(false);
        }
        else if (Choicemade == 2)
        {
            Choice2.SetActive(false);
        }
    }
    */
}
