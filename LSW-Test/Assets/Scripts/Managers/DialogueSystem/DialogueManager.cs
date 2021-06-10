using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TMP_Text nameText;
	public TMP_Text  dialogueText;
    	public TMP_Text  questionText;


    public GameObject panel;
    
    public GameObject questionpanel;
	//public Animator animator;

	private Queue<string> sentences;
     
     Question question;
	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (DialougeSystem dialogue)
	{
		panel.SetActive(true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
question = null;
        if (dialogue.question != null)
question = dialogue.question;

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
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
       
		panel.SetActive(false);
        if(question != null){
questionText.text = question.text;
            questionpanel.SetActive(true);
        }
	}
    

}