using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact(transform);

                    
                }
            }
        }
    }

    public Interactable GetInteractableObject()
    {
        List<Interactable> interactableList = new List<Interactable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Interactable interactable))
            {
                interactableList.Add(interactable);    
            }
        }

        //Checking if there is any close interactable
        Interactable closestInteractable = null;
        foreach (Interactable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                //Checking if interactable is closer than other one
                if (Vector3.Distance(transform.position, interactable.transform.position) < 
                   Vector3.Distance(transform.position, closestInteractable.transform.position))
                {
                    closestInteractable = interactable;
                }
            }
        }


        return closestInteractable;
    }



    
  
}
