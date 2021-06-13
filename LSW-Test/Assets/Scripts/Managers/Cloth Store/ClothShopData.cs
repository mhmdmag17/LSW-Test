using UnityEngine;

namespace ShopSystem
{
    [System.Serializable]
    public class ClothShopData
    {
        public ShopItem[] shopItems;
    }

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;             //name of item
        public bool hasBought;   //bool to check Bought status
        
         public bool isEquiped;          //bool to check Equiped status
        public int cost;              //cost of unlock
       
      public enum partType {Top, Pants, Shoes};
      public partType type;
    }

   
   
}
   
   

