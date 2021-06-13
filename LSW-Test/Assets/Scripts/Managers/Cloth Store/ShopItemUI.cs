using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ShopSystem
{
public class ShopItemUI : MonoBehaviour
{
    
    public TMP_Text itemName; // to display item's Name
     public TMP_Text itemCost; // to display item's Cost
     public Image icon; // to display set item's icon

    public Button sellButton; 
    public TMP_Text buyButtonText; 
   
}
}