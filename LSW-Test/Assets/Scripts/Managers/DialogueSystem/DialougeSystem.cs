
using UnityEngine;
[System.Serializable]
public class DialougeSystem 
{
	public string name;

	[TextArea(1, 10)]
	public string[] sentences;
 
    public Question question;
}



[System. Serializable]
public struct Choice{

[TextArea(2, 5) ]
public string choice;
public DialougeSystem dialouge;
}
[System. Serializable]

public class Question {
[TextArea(2, 5)]
public string text;
public Choice[] choices;

}
    
