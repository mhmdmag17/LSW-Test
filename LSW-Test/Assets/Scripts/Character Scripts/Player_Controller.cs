using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;
using UnityEngine.Tilemaps;

public class Player_Controller : MonoBehaviour
{
    
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
    
  public Tilemap tilemap;
  public Tile[] grassTiles;
  public Tile[] rockRoadTiles;
   public Tile[] woodTiles;
  int tileNum;
   


    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
      
     //movementAudio = GetComponent<AudioSource>();
    referenceCatogrey = targetResolver.GetCategory();
  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = HandleInput();

        HandleAnimation(movement);
        Vector3Int tilepos = tilemap.WorldToCell(transform.position);
        Tile tileatpos = tilemap.GetTile<Tile>(tilepos);

        HandleSounds(movement, tileatpos);
    }

    private void HandleSounds(Vector2 movement, Tile tileatpos)
    {
        if (movement.sqrMagnitude > 0 && GameManager.Instance.canMove )
        {
            if (grassTiles.Contains<Tile>(tileatpos))
            {

                tileNum = 1;
                if (!SFX_Manager.Instance.movementAudios[0].isPlaying)
                {
                    SFX_Manager.Instance.movementAudios[0].pitch = Random.Range(0.9f, 1.1f);
                    SFX_Manager.Instance.movementAudios[0].Play();
                }
            }
            else if (rockRoadTiles.Contains<Tile>(tileatpos))
            {
                tileNum = 2;
                if (!SFX_Manager.Instance.movementAudios[1].isPlaying)
                {
                    SFX_Manager.Instance.movementAudios[1].pitch = Random.Range(0.9f, 1.1f);
                    SFX_Manager.Instance.movementAudios[1].Play();
                }
            }
            else if (woodTiles.Contains<Tile>(tileatpos))
            {
                tileNum = 3;
                if (!SFX_Manager.Instance.movementAudios[2].isPlaying)
                {
                    SFX_Manager.Instance.movementAudios[2].pitch = Random.Range(0.9f, 1.1f);
                    SFX_Manager.Instance.movementAudios[2].Play();
                }
            }





        }
    }

    private Vector2 HandleInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        return movement;
    }

    private void HandleAnimation(Vector2 movement)
    {
        if (GameManager.Instance.canMove)
        {
            if (horizontal != 0 && !targetResolver.GetLabel().Equals("Side"))
                targetResolver.SetCategoryAndLabel(referenceCatogrey, "Side");
            else if (horizontal == 0 && !targetResolver.GetLabel().Equals("Forward"))
                targetResolver.SetCategoryAndLabel(referenceCatogrey, "Forward");


            if (horizontal != 0 && vertical != 0)
                anim.SetFloat("Vertical", 0);
            else
                anim.SetFloat("Vertical", vertical);

            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (GameManager.Instance.canMove)
        {

            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally
                horizontal *= diagonalMoveLimit;
                vertical *= diagonalMoveLimit;
            }

            rb.velocity = new Vector2(horizontal * speed, vertical * speed) * Time.deltaTime;
        }
    }

}

