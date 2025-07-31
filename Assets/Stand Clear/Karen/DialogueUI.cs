using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues;
    public float typingSpeed = .05f;
    private int cureentDialogueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogues.Length > 0)
        {
            StartCoroutine(DisplayDialogue());
        }
    }

    IEnumerator DisplayDialogue()
    {
        // Display each dialogue line one after the other
        foreach (string dialogue in dialogues)
        {
            dialogueText.text = ""; // Clear the text each time before showing new dialogue
            foreach (char letter in dialogue)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed); // Type out the dialogue one character at a time
            }

            // Wait for user to press a key before moving to the next dialogue (optional)
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
