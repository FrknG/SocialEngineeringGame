using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice1;
    public GameObject Choice2;

    public int Choicemade;

    public void ChoiceOption1()
    {
        TextBox.GetComponent<TextMeshProUGUI>().text = "First choice made";
        
        Choicemade = 1;
    }
    public void ChoiceOption2()
    {
        TextBox.GetComponent<TextMeshProUGUI>().text = "Second choice made";
        Choicemade = 2;
    }



    void Update()
    {
        if (Choicemade >= 1)
        {
            Choice1.SetActive(false);
            Choice2.SetActive(false);
        }
    }
}
