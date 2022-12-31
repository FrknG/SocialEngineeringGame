using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour, InteractableInterface
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
        UIEventHandler.instance.OnBinInteract(this);
        DialogueUI.instance.IsOpen = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInteract = GameObject.Find("Player").GetComponentInChildren<PlayerInteract>();
        UIEventHandler.instance.BinInteract += UIEventHandler.instance.Binteracted;
    }

}
