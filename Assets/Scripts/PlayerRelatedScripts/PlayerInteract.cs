using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public bool HasCard;
    public InteractableInterface Interactable { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        HasCard = false;
    }

    private void Update()
    {


        if(Input.GetKeyDown(KeyCode.E))
        {
            /*
            if(interactable  != null)
            {
                interactable.Interact(transform);
            }
            */            
            InteractableInterface Interactable = GetInteractableObject();            
            Interactable?.Interact(this);
        }
    }
    
    public InteractableInterface GetInteractableObject()
    {



        List<InteractableInterface> interactableList = new List<InteractableInterface>();
        //float interactRange = 0.4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, this.GetComponent<CapsuleCollider>().radius);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out InteractableInterface interactable))
            {
                interactableList.Add(interactable);    
            }
        }

        //Checking if there is any close interactable
        InteractableInterface closestInteractable = null;
        foreach (InteractableInterface interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                //Checking if interactable is closer than other one
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                   Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }


        return closestInteractable;
    }



    
  
}
