using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableInterface
{
    void Interact(Transform interactor);
    string GetIntText();

    string GetChatText();

    Transform GetTransform();
    

}
