using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, InteractableInterface
{
    Animator _doorAnim;
    [SerializeField] private string iText;    
    public PlayerInteract playerInteract;

    public bool NeedCard;
    

   

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = GetComponent<Animator>();
        playerInteract = GameObject.Find("Player").GetComponentInChildren<PlayerInteract>();

        
}


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
        if(NeedCard && playerInteract.HasCard)
        {
            if (_doorAnim.GetBool("IsOpening") == false)
            {
               DoorOpen(playerInteract.GetComponent<Collider>());
            }
           
        }
        else if (!NeedCard)
        {
            if (_doorAnim.GetBool("IsOpening") == false)
            {
                DoorOpen(playerInteract.GetComponent<Collider>());
            }
        }
       
        

    }

    private void DoorOpen(Collider other)
    {
       
        _doorAnim.SetBool("IsOpening", true);
        
    }
        
    void Update()
    {
        if (_doorAnim.GetBool("IsOpening") == true)
        {
            StartCoroutine(DoorClose());
            //DoorClose(playerInteract.GetComponent<Collider>());
        }
    }

    // Door auto closing.
    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(2);
        _doorAnim.SetBool("IsOpening", false);
    }
}
