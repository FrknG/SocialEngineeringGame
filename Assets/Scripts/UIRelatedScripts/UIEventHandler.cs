using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIEventHandler : MonoBehaviour
{
    public static UIEventHandler instance;  

    public PlayerInteract playerInteract;
    public GameObject NotificationUI;
    public GameObject ComputerScreenUI;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
    }

    public event Action<InteractableInterface> CardPickup;
    public event Action<InteractableInterface> DocumentInteract;
    public event Action<InteractableInterface> BinInteract;

    private void Start()
    {
        playerInteract = GameObject.Find("Player").GetComponentInChildren<PlayerInteract>();
      
    }   

    public void OnBinInteract(InteractableInterface interactable)
    {
        BinInteract?.Invoke(interactable);
    }
    public void OnCardPickup(InteractableInterface interactable)
    {
        CardPickup?.Invoke(interactable);
    }
    public void OnDocumentInteract(InteractableInterface interactable)
    {
        DocumentInteract?.Invoke(interactable);
    }

    public void Binteracted(InteractableInterface interactable)
    {
        ComputerScreenUI.SetActive(true);
    }


    public void CardPickedUp(InteractableInterface interactable)
    {
        playerInteract.HasCard = true;
        if (playerInteract.HasCard)
        {
            NotificationUI.GetComponentInChildren<TextMeshProUGUI>().text = "You have picked up a " + interactable.GetIntText();
            NotificationUI.SetActive(true);
            NotificationUI.GetComponent<Animator>().SetBool("IsOn", true);           
            StartCoroutine(DeactiveUI());
        }


    }    

    public void DocumentInteracted(InteractableInterface interactable)
    {
        NotificationUI.GetComponentInChildren<TextMeshProUGUI>().text = "You have picked up a " + interactable.GetIntText();
        NotificationUI.SetActive(true);
        StartCoroutine(DeactiveUI());
    }

    IEnumerator DeactiveUI()
    {
        
        yield return new WaitForSeconds(3);
        NotificationUI.GetComponent<Animator>().SetBool("IsOn", false);
       
    }

}


