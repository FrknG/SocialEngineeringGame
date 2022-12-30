using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using TMPro;
using System;

public class UIEventHandler : MonoBehaviour
{
    public static UIEventHandler instance;  

    public PlayerInteract playerInteract;
    public GameObject NotificationUI;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
    }

    public event Action<GameObject> CardPickup;
   
    private void Start()
    {
        playerInteract = GameObject.Find("Player").GetComponentInChildren<PlayerInteract>();
      
    }   

 
    public void OnCardPickup(GameObject go)
    {
        CardPickup?.Invoke(go);
    }

    public void CardPickedUp(GameObject go)
    {
        playerInteract.HasCard = true;
        if (playerInteract.HasCard)
        {
            NotificationUI.GetComponentInChildren<TextMeshProUGUI>().text = "You have picked up a " + go.name;
            NotificationUI.SetActive(true);
        }


    }

    private void Update()
    {
        
    }

}


/*

use this for events

private void Start()
{
    UIEventHandler.instance.CardPickup += UIEventHandler.instance.CardPickedUp;

}


if (dialogueObject == null && this.tag == "AccessCard")
{
    Debug.Log("Interacting");
    UIEventHandler.instance.OnCardPickup(gameObject);


}


*/