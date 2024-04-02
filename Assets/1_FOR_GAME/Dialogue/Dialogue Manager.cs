using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public AudioSource audioSource;

    private AudioClip[] audioClips;
    private int currentIndex = 0;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        // Press enter to go to next text
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }    

    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        // Pause Time
        Time.timeScale = 0f;

        // Add text to the dialogue
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach ( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        audioClips = dialogue.clips;
        currentIndex = 0;

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentece(sentence));

        audioSource.clip = audioClips[currentIndex];
        audioSource.Play();
        currentIndex++;
    }

    IEnumerator TypeSentece (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        // Unpause the game
        Time.timeScale = 1f;
        Debug.Log("Game unpaused!");
    }

}
