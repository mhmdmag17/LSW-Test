using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            LeanTween.scaleX(gameObject,0f,1f).setEase(LeanTweenType.easeOutExpo);
        }
    }
      void OnTriggerExit2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            LeanTween.scaleX(gameObject,1.558446f,1f).setEase(LeanTweenType.easeOutExpo);
        }
    }

}
