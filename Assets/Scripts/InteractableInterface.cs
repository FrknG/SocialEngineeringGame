using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableInterface
{
    void Interact(Transform interactor);
    string GetIntText();

    Transform GetTransform();
    
}
