﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OpenUI(){
      GetComponent<DialogueTrigger>().TriggerDialogue();
    }
  public void CloseUI(){
        Debug.Log(" Book Shelf Closed");
    }
}
