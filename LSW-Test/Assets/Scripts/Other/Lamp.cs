using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lamp : MonoBehaviour , IInteractable
{
    // Start is called before the first frame update
bool switchLight = true;
  
 [SerializeField]   GameObject ui;
 [SerializeField]   TMP_Text text;
   
   public void SwitchigLight(){
       switchLight = !switchLight;
          if(switchLight)
{   text.text = "Switch Off";
          transform.GetChild(0).gameObject.SetActive(true);
          }
          else
          {
               text.text = "Switch On";
          transform.GetChild(0).gameObject.SetActive(false);
    }
   }

      public void OpenUI(){
LeanTween.scale(ui,new Vector2(1,1),0.5f).setEase(LeanTweenType.easeSpring);
SFX_Manager.Instance.PopSound();
    }
  public void CloseUI(){
      LeanTween.scale(ui,new Vector2(0,0),0.5f).setEase(LeanTweenType.easeOutExpo);
    }
}
