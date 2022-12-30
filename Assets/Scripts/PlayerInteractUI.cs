using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject TalkUI;
    
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

    public UnityEvent progress;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            
            Hide();
        }
    }
    private void Show(InteractableInterface interactable)
    {        
        TalkUI.SetActive(true);
        interactText.text = interactable.GetIntText();
      
    }

    private void Hide()
    {        
        TalkUI.SetActive(false);
       
    }
}
