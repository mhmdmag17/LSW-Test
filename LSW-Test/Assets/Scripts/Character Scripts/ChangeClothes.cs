﻿
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;

public class ChangeClothes : MonoBehaviour
{
    #region Inspector

private static ChangeClothes _instance;

    public static ChangeClothes Instance { get { return _instance; } }
  [SerializeField]
  private SpriteLibrary spriteLibrary ;

  [SerializeField]
  private SpriteResolver bodyTargetResolver ;

  [SerializeField]
  private SpriteResolver legsTargetResolver ;
  [SerializeField]
  private SpriteResolver shoesTargetResolver ;

  [SerializeField]
  

  #endregion


  #region Properties

 

  #endregion


  #region Methods

 private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
  public  void ChangOutFit (string bodyPart,string targetCategory , string label)
  {
    switch (bodyPart)
    {
        case "Top":
    bodyTargetResolver.SetCategoryAndLabel(targetCategory, label);
    GetComponent<Player_Controller>().referenceCatogrey = targetCategory;
        break; 
            case "Legs":
    legsTargetResolver.SetCategoryAndLabel(targetCategory, label);

        break; 
            case "Shoes":
    shoesTargetResolver.SetCategoryAndLabel(targetCategory, label);

        break; 
        
        default:
        return;
    }
  }

  
  #endregion

  
}

