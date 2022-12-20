using UnityEngine;
using System.Collections;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private TypeWriter typeWriter;

    private ResponseHandler responseHandler;
    private void Start()
    {
        typeWriter= GetComponent<TypeWriter>();
        responseHandler = GetComponent<ResponseHandler>();


        CloseDialogue();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWriter.Run(dialogue, textLabel);
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;


            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if(dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogue();
        }
         
    }

    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
