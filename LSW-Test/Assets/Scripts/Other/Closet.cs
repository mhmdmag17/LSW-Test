using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
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
        Debug.Log("Closet Opened");
    }
  public void CloseUI(){
        Debug.Log("Closet  Closed");
    }
}
