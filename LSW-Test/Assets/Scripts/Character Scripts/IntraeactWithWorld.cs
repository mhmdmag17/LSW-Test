using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntraeactWithWorld : MonoBehaviour
{
    bool inRange; // TO CHECK IF THERE'S AN INTERACTABLE OBJ IN RANGE
     Collider2D objCollider;
    
    UI_Manager uI_Manager;
    GameObject _intraectText;
    void Start  (){
      uI_Manager = UI_Manager.Instance;
      _intraectText = uI_Manager.intreactText;
    }
    // Update is called once per frame
    void Update()
    {
     if(inRange &&  Input.GetKeyDown(KeyCode.E))
        {
              uI_Manager.ScaleDown(_intraectText);
              objCollider.gameObject.GetComponent<IInteractable>().OpenUI();
              GameManager.Instance.DisableMoving();
               Material mat = objCollider.gameObject.GetComponent<SpriteRenderer>().material;
          mat.SetFloat("_OutlineThickness", 0f);
        }
    }

  void OnTriggerEnter2D(Collider2D coll)
    {
      if(coll.gameObject.GetComponent<IInteractable>() != null)
      {
          uI_Manager.ScaleUp(_intraectText);
          inRange = true;
          objCollider = coll;
          Material mat = coll.gameObject.GetComponent<SpriteRenderer>().material;
          mat.SetFloat("_OutlineThickness", 10f);
      }
    }
     void OnTriggerExit2D(Collider2D coll)
    {
      if(coll.gameObject.GetComponent<IInteractable>() != null){
           uI_Manager.ScaleDown(_intraectText);
           inRange = false;
           coll.gameObject.GetComponent<IInteractable>().CloseUI();
           objCollider = null;
           Material mat = coll.gameObject.GetComponent<SpriteRenderer>().material;
          mat.SetFloat("_OutlineThickness", 0f);
      }
    }
}
