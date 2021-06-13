using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;

public class Player_Controller : MonoBehaviour
{
    private static Player_Controller _instance;

    public static Player_Controller Instance { get { return _instance; } }
   
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    [SerializeField] float speed;
    [SerializeField] float diagonalMoveLimit;


     Animator anim;

  
    [SerializeField]
  private SpriteLibrary spriteLibrary ;

  [SerializeField]
  private SpriteResolver targetResolver ;

 

   

     
     public string referenceCatogrey;
    // public GameObject exit;

    // public Sprite canPressExit;
    // public Sprite canNotPressExit;

   
    // public GameObject exitAnim;
   
  

    
  public   bool canMove = true;
    

   
  //  [SerializeField] AudioSource movementAudio;

private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = true;
      
        //movementAudio = GetComponent<AudioSource>();
 
  
    referenceCatogrey = targetResolver.GetCategory();
  
    }

    // Update is called once per frame
    void Update()
    {
       
           horizontal = Input.GetAxisRaw("Horizontal");
           vertical = Input.GetAxisRaw("Vertical"); 
            Vector2 movement = new Vector2(horizontal,vertical);

            if(canMove)
            {
            if(horizontal != 0 && !targetResolver.GetLabel().Equals("Side"))
             targetResolver.SetCategoryAndLabel(referenceCatogrey, "Side");
            else if(horizontal == 0 &&!targetResolver.GetLabel().Equals("Forward"))
            targetResolver.SetCategoryAndLabel(referenceCatogrey, "Forward");
            
            if(horizontal !=0 && vertical !=0 )
               anim.SetFloat("Vertical", 0);
               else
            anim.SetFloat("Vertical", vertical);

            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Speed", movement.sqrMagnitude);
           }else{
                anim.SetFloat("Speed", 0);
           }

        //     if (canMove)
        // {
        //     // joystick.gameObject.SetActive(true);

        //     // if (joystick.Horizontal >= .2f)
        //     // {
        //         x = speed;
        //         y = 0;
        //         player_MAnager.SetHairSpriteRendrer(1);
        //         player_MAnager.SetFaceSpriteRendrer(1);

        //     }
        //     else if (joystick.Horizontal <= -.2f)
        //     {
        //         x = -speed;
        //         y = 0;
        //         player_MAnager.SetHairSpriteRendrer(-1);
        //         player_MAnager.SetFaceSpriteRendrer(-1);
        //     }
        //     else
        //     {
        //         x = 0;
               

        //     }

        //     if (joystick.Vertical >= .2f)
        //     {
        //         y = speed;
        //         x = 0;
        //         player_MAnager.SetHairSpriteRendrer(2);
        //         player_MAnager.SetFaceSpriteRendrer(2);
        //     }
        //     else if (joystick.Vertical <= -.2f)
        //     {
        //         y = -speed;
        //         x = 0;
        //         player_MAnager.SetHairSpriteRendrer(-2);
        //         player_MAnager.SetFaceSpriteRendrer(-2);
        //     }
        //     else
        //     {
        //         y = 0;
             
        //     }
        //     if(x == 0 && y == 0)
        //     {
        //         player_MAnager.SetHairSpriteRendrer(-2);
        //         player_MAnager.SetFaceSpriteRendrer(-2);
        //     }

          
    //         anim.SetFloat("H", x);
    //         anim.SetFloat("V", y);
    //         anim.SetFloat("Speed", movement.sqrMagnitude);
    //         if(movement.sqrMagnitude > 1)
    //         {
    //             if (!movementAudio.isPlaying)
    //             {
    //                 movementAudio.pitch = Random.Range(0.9f, 1.1f);
    //                 movementAudio.Play();
    //             }
    //         }
    //         else
    //         {
    //             movementAudio.Stop();
    //         }

    //     }
    //     else
    //     {
    //         joystick.gameObject.SetActive(false);
    //     }

    // }
    // private void FixedUpdate()
    // {
    //     if (canMove)
    //     {
    //         rb.MovePosition(rb.position + new Vector2(x, y) * speed * Time.deltaTime);
    //     }
     }

     private void FixedUpdate()
{  
if(canMove){

     if (horizontal != 0 && vertical != 0) // Check for diagonal movement
   {
      // limit movement speed diagonally
      horizontal *= diagonalMoveLimit;
      vertical *= diagonalMoveLimit;
   }

   rb.velocity = new Vector2(horizontal * speed, vertical * speed) * Time.deltaTime;
}
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (!taskOneFinished)
        {
            if (collision.gameObject.name == ("cabinet"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = openTask[0];
                task[0].SetActive(true);
            }



            if (collision.tag == "OpenTask")
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = openTask[0];
                blackPanel = GameObject.Find("BlackPanel").GetComponent<CanvasGroup>();
                gm[0] = collision.gameObject.GetComponentInChildren<Transform>().GetChild(0).gameObject;

            }
        }

        if (!taskTwoFinished)
        {
            if (collision.gameObject.name == ("cabinet (1)"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = openTask[1];
                task[1].SetActive(true);
            }
        }*/
        // if (collision.tag == "Exit")
        // {
        //     collision.gameObject.GetComponent<SpriteRenderer>().sprite = canPressExit;
        //     exit.SetActive(true);
        // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       

       /* if (collision.gameObject.name == ("cabinet"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = cantopenTask[0];
            task[0].SetActive(false);
        }
        if (collision.gameObject.name == ("cabinet (1)"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = cantopenTask[1];
            task[1].SetActive(false);
        }
*/
       

        // if (collision.tag == "Exit")
        // {
        //     collision.gameObject.GetComponent<SpriteRenderer>().sprite = canNotPressExit;
        //     exit.SetActive(false);
        // }
    }

  /*  public void OpenTask()
    {
       
        blackPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackPanel, 1, 0.5f).setDelay(0.1f).setEase(LeanTweenType.easeInCirc);
        LeanTween.scale(gm[0], new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInExpo);
        canMove = false;
    }*/

  
    public void OpenExitPanel()
    {
        // if(GameManager.TasksCount >= 1) 
        // LeanTween.scale(exitAnim, new Vector3(0.75f, 0.75f, 1), 0.5f).setEase(LeanTweenType.easeSpring);
        // else if(GameManager.TasksCount <= 0)
        //     Events.ScoreEvent.Invoke();

        // canMove = false;
    }
    public void CloseExitPanel()
    {
        //LeanTween.scale(exitAnim, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo);
        canMove = true;
    }
  
    
   public void ReanbleCanMove(){
       canMove = true;
   }

 

  
}

