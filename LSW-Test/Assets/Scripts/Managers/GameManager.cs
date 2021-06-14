using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public   bool canMove {get; private set;}
     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        canMove = true;
    }
    // Start is called before the first frame update
    
    public   void EnableMoving()
    {
        canMove = true;
    }
    public   void DisableMoving()
    {
        canMove = false;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();
    }
}
