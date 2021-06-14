using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShopSystem
{
public class ClothShopUI : MonoBehaviour
{
    
    private static ClothShopUI _instance;

    public static ClothShopUI Instance { get { return _instance; } }
     public ClothShopData shopData;
     [SerializeField] private ShopItemUI[] shopItem; 
     [SerializeField] private Sprite[] icons; 

     [SerializeField] private int money; 
   
     void Awake(){
 if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
         money = PlayerPrefs.GetInt("Money",10000);
         UI_Manager.Instance.moneyText.text = money.ToString();
     }
    // Start is called before the first frame update
    void Start()
    {
         ClothShop_SavingLoadingData.Instance.Initialize();
        for (int i = 0; i < shopData.shopItems.Length; i++)
        {
            shopItem[i].gameObject.SetActive(true);
          shopItem[i].itemName.text   = shopData.shopItems[i].itemName.ToString();
           shopItem[i].icon.sprite   = icons[i];
           if(shopData.shopItems[i].hasBought && shopData.shopItems[i].isEquiped){
             ChangeClothes.Instance.ChangOutFit(shopData.shopItems[i].type.ToString(),shopData.shopItems[i].itemName,"Forward");
            shopItem[i].itemCost.text   = (shopData.shopItems[i].cost / 2).ToString(); 
              shopItem[i].buyButtonText.text   = "Equipped"; 
           }
            else if( shopData.shopItems[i].hasBought &&! shopData.shopItems[i].isEquiped)
             {
                 shopItem[i].itemCost.text   = (shopData.shopItems[i].cost / 2).ToString(); 
            
              shopItem[i].buyButtonText.text  = "Equip"; 
               
              }
              else
              {
         
          shopItem[i].itemCost.text   = shopData.shopItems[i].cost.ToString();  
           }


           if(shopData.shopItems[i].hasBought)
           shopItem[i].sellButton.interactable = true;
           else
            shopItem[i].sellButton.interactable = false;

          
        }
    }

   

    public void Buy(int id){
        if(money >= shopData.shopItems[id].cost&& !shopData.shopItems[id].hasBought){
            shopData.shopItems[id].hasBought = true;
            money -= shopData.shopItems[id].cost;
            PlayerPrefs.SetInt("Money",money);
            shopItem[id].itemCost.text   = (shopData.shopItems[id].cost / 2).ToString();
             shopItem[id].buyButtonText.text    = "Equip"; 
              shopItem[id].sellButton.interactable = true;
              UI_Manager.Instance.moneyText.text = money.ToString();
        }else if(shopData.shopItems[id].hasBought){
               
             Equip(id);
        }
        else
          Debug.Log ("Money is't Enough");

            ClothShop_SavingLoadingData.Instance.SaveData();

    }
     void Equip(int id){
        
                //Change the Part sprite
                
                 ChangeClothes.Instance.ChangOutFit(shopData.shopItems[id].type.ToString(),shopData.shopItems[id].itemName,"Forward");
                 shopData.shopItems[id].isEquiped = true;
                   
                    shopItem[id].buyButtonText.text    = "Equipped"; 
                 for (int i = 0; i < shopData.shopItems.Length; i++)
                 {
                     if ( shopData.shopItems[i].type == shopData.shopItems[id].type && i != id )
                     {
                             
                              shopData.shopItems[i].isEquiped = false;
                              if(shopData.shopItems[i].hasBought)
                               shopItem[i].buyButtonText.text    = "Equip"; 

                     }
                     
                 }
        }


        
     public void Sell(int id){
              

        if(shopData.shopItems[id].hasBought && !shopData.shopItems[id].isEquiped )
        {
               shopData.shopItems[id].hasBought = false;
            money += shopData.shopItems[id].cost / 2;
            PlayerPrefs.SetInt("Money",money);
             shopItem[id].itemCost.text   = shopData.shopItems[id].cost.ToString(); 
                ClothShop_SavingLoadingData.Instance.SaveData();
              shopItem[id].sellButton.interactable = false;
                    shopItem[id].buyButtonText.text    = "Buy"; 
                    UI_Manager.Instance.moneyText.text = money.ToString();
        }
        else if(!shopData.shopItems[id].hasBought){
            Debug.Log ("item Hasn't Bought Yet");
        }
        else if(shopData.shopItems[id].isEquiped){
            Debug.Log ("Can't sell equiped items");
        }
        }
           
    }
}
