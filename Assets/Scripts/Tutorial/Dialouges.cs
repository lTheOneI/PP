using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialouges : MonoBehaviour
{

    public TextMeshProUGUI dialogueField;
    public string[] lines;
    public float textSpeed;

    private int index;
    void Start()
    {
        dialogueField.text = string.Empty;
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (dialogueField.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueField.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueField.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length -1)
        {
            index ++;
            dialogueField.text = string.Empty;
            StartCoroutine(TypeLine());
        }

    }
}
