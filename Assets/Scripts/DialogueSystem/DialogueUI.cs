using UnityEngine;
using System.Collections;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject InteractUI;


    public bool IsOpen { get;  set; }

    private TypeWriter typeWriter;

    private ResponseHandler responseHandler;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        typeWriter= GetComponent<TypeWriter>();
        responseHandler = GetComponent<ResponseHandler>();
        textLabel.color = new Color(255, 255, 255, 255);
        IsOpen = false;
        CloseDialogue();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        //dialogueBox.SetActive(true);
        dialogueBox.GetComponent<Animator>().SetBool("IsOn", true);
        InteractUI.SetActive(false);
       
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResposeEvents(responseEvents);
    }


    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);

           
            textLabel.text = dialogue;
            

            //yield return typeWriter.Run(dialogue, textLabel);
            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;

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

    private IEnumerator RunTypingEffect(string dialogue)
    {
        
        typeWriter.Run(dialogue, textLabel);

        while(typeWriter.IsRunning)
        {
            yield return null;
            if(Input.GetKeyDown(KeyCode.X))
            {
                typeWriter.Stop();
            }
        }
    }

   
    public void CloseDialogue()
    {
        IsOpen= false;
        InteractUI.SetActive(true);
        dialogueBox.GetComponent<Animator>().SetBool("IsOn", false);
        //dialogueBox.SetActive(false);
        textLabel.text = string.Empty;        
    }

    private void Update()
    {
        if(IsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       
        
    }
}
