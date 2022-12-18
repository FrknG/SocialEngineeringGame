using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject TalkUI;
    [SerializeField] private GameObject ChatUI;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI ChatText;
    public bool IsInteracting;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            IsInteracting = true;
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            IsInteracting = false;
            Hide();
        }
    }
    private void Show(InteractableInterface interactable)
    {        
        TalkUI.SetActive(true);
        interactText.text = interactable.GetIntText();
        ChatText.text = interactable.GetChatText();
    }

    private void Hide()
    {        
        TalkUI.SetActive(false);
        ChatUI.SetActive(false);
    }
}
