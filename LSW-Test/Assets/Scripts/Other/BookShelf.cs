using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour, IInteractable
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
        Debug.Log("Book Shelf Opened");
    }
  public void CloseUI(){
        Debug.Log(" Book Shelf Closed");
    }
}