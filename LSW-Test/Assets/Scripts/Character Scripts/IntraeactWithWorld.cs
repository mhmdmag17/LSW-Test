using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntraeactWithWorld : MonoBehaviour
{
    [SerializeField]Transform intreactCheckpos;
     [SerializeField] bool inRange;
     Collider2D objCollider;
    [SerializeField] GameObject intreact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(inRange &&  Input.GetKeyDown(KeyCode.E))
        {
              intreact.SetActive(false);
            objCollider.gameObject.GetComponent<IInteractable>().OpenUI();
            GetComponent<Player_Controller>().canMove = false;
        }
    }

  void OnTriggerEnter2D(Collider2D coll)
    {
      if(coll.gameObject.GetComponent<IInteractable>() != null)
      {
          intreact.SetActive(true);
      inRange = true;
        objCollider = coll;
        }
    }
     void OnTriggerExit2D(Collider2D coll)
    {
      if(coll.gameObject.GetComponent<IInteractable>() != null){
           intreact.SetActive(false);
      inRange = false;
        coll.gameObject.GetComponent<IInteractable>().CloseUI();
         objCollider = null;
      }
    }
}
