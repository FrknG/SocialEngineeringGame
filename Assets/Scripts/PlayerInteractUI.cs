using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject TalkUI;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

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
    private void Show(Interactable interactable)
    {
        TalkUI.SetActive(true);
        interactText.text = interactable.GetChatText();
    }

    private void Hide()
    {
        TalkUI.SetActive(false);
    }
}
