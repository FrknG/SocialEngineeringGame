using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public InteractableInterface Interactable { get; set; }
    
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, 0.4f);
    }
    public InteractableInterface GetInteractableObject()
    {



        List<InteractableInterface> interactableList = new List<InteractableInterface>();
        float interactRange = 0.4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
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
