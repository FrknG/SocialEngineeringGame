using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {            
            InteractableInterface interactable = GetInteractableObject();
            if(interactable  != null)
            {
                interactable.Interact(transform);
            }
            
        }
    }

    public InteractableInterface GetInteractableObject()
    {
        List<InteractableInterface> interactableList = new List<InteractableInterface>();
        float interactRange = 1.5f;
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
