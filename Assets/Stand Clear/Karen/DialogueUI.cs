using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI NamesText;
    public string[] dialogues;
    public string[] names;
    public float typingSpeed = .05f;
    private int cureentDialogueIndex = 0;
    public string next;
    public Image fadeImage;          // UI Image used for fade effect
    public float fadeDuration = 1f;  // How long the fade takes
    private bool dialogueFinished = false;   // Set this true when all dialogue is done
    private bool isTransitioning = false;

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

        for (int i = 0; i < dialogues.Length; i++) 
        {
            string dialogue = dialogues[i];
            
            dialogueText.text = ""; // Clear the text each time before showing new dialogue
            NamesText.text = names[i];
            foreach (char letter in dialogue)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed); // Type out the dialogue one character at a time
            }

            // Wait for user to press a key before moving to the next dialogue (optional)
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        // Load the next scene after all dialogue lines have been shown
        if (fadeImage)
        {
            StartCoroutine(TransitionToNextScene());
        }
        else
        {
            SceneManager.LoadScene(next);
        }
    }

          

    // Call this method when all dialogue is finished
    public void OnDialogueFinished()
    {
        dialogueFinished = true;
    }

    IEnumerator TransitionToNextScene()
    {
        isTransitioning = true;
        float timer = 0f;
        Color color = fadeImage.color;

        Debug.Log("B");
        while (timer < fadeDuration)
        {
            Debug.Log("A");
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(next);
    }
}