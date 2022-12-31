using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCard : MonoBehaviour, InteractableInterface
{
    [SerializeField] private string iText;
    public PlayerInteract playerInteract;
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
        UIEventHandler.instance.OnCardPickup(this);
        DialogueUI.instance.IsOpen = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInteract = GameObject.Find("Player").GetComponentInChildren<PlayerInteract>();
        UIEventHandler.instance.CardPickup += UIEventHandler.instance.CardPickedUp;
    }
    

}



/*

use this for events template

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