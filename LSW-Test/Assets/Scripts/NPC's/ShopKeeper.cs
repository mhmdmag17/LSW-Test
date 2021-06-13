using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour, ISpecialNPC
{
    // Start is called before the first frame update
   [SerializeField] GameObject panel;
   [SerializeField]  GameObject nextPanel;
     public void DoSpecialThing(){
panel.SetActive(true);
      }
   public void Yes()
    {
        nextPanel.SetActive(true);
         panel.SetActive(false);
    }
    public void No()
    {
         nextPanel.SetActive(false);
         panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
