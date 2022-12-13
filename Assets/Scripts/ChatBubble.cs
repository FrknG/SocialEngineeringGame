using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
 



    private SpriteRenderer backgroundSpriteRend;
    private TextMeshPro textMesh;


    private void Awake()
    {
        backgroundSpriteRend = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMesh = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        Setup("Hi Jack This is the first chat bubble ");

    }

    private void Setup(string text)
    {
        textMesh.SetText(text);
        textMesh.ForceMeshUpdate();
        Vector2 textSize=textMesh.GetRenderedValues(false);

        Vector2 padding = new Vector2(4f,2f);
        backgroundSpriteRend.size = textSize + padding;

     



    }
}
