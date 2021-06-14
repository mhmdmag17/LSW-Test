using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, ISpecialNPC
{
    UI_Manager uI_Manager;
    GameObject _questionpanel,_nextPanel;
      void Start()
      {
          uI_Manager = UI_Manager.Instance;
          _questionpanel = uI_Manager.questionpanel;
          _nextPanel = uI_Manager.shopPanel;
      }
     public void DoSpecialThing(){
          uI_Manager.ScaleUp(_questionpanel);

      }
   public void Yes()
    {
          uI_Manager.ScaleUp(_nextPanel);
          uI_Manager.ScaleDown(_questionpanel);

    }
    public void No()
    {
          uI_Manager.ScaleDown(_nextPanel);
          uI_Manager.ScaleDown(_questionpanel);
    }

  
    
}
