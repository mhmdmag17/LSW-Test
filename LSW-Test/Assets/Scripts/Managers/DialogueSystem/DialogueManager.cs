using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueManager : MonoBehaviour {

	
	UI_Manager uI_Manager;

	private Queue<string> sentences;
     
	 Question question;

	void Start () {
		sentences = new Queue<string>();
		uI_Manager = UI_Manager.Instance;
	}

	public void StartDialogue (DialougeSystem dialogue)
	{
	
	uI_Manager.ScaleUp(uI_Manager.dialoguePanel);
	uI_Manager.nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
question = null;
        if (!dialogue.question.Equals(""))
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
	uI_Manager.dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			uI_Manager.dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
       
		uI_Manager.ScaleDown(uI_Manager.dialoguePanel);
        if(question.text.Length > 0){
        uI_Manager.questionText.text = question.text;
          			uI_Manager.ScaleUp(uI_Manager.questionpanel);
        }else{
			GameManager.Instance.EnableMoving();
		}
	}
    

}