using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

     private static UI_Manager _instance;

    public static UI_Manager Instance { get { return _instance; } }
   
#region DialogueManager

     public TMP_Text nameText;
	public TMP_Text  dialogueText;
    public TMP_Text  questionText;


    public GameObject dialoguePanel;
    
    public GameObject questionpanel;
    #endregion

#region  ShopKeeper
 public GameObject shopPanel;
 public TMP_Text  moneyText;
   #endregion

#region  IitreactWithWorldClass
public GameObject intreactText;
#endregion
   private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
   
   
    public void ScaleUp(GameObject gm){
        LeanTween.scale(gm,new Vector2(1,1),0.5f).setEase(LeanTweenType.easeSpring);
    }
     public void ScaleDown(GameObject gm){
        LeanTween.scale(gm,new Vector2(0,0),0.5f).setEase(LeanTweenType.easeOutExpo);
    }
}
