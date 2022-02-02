using UnityEngine;
using UnityEngine.Serialization;


public class TradeController : MonoBehaviour
{ 
    public Item CurrentItem;
    private Inventory buyer;

    public void SelectItem(Item item)
    {
        CurrentItem = item;
        CurrentItem.Select(this);
        buyer = null;
    }
    
    public void CompareInventory(Inventory inventory)
    {
        if (inventory != CurrentItem.owner)
        {
            buyer = inventory;
        }
    }

    public void SellItem()
    {
        CurrentItem.Unselect();
        if (buyer == null)
        {
            return;
        }
        if (buyer.BuyItem(CurrentItem))
        {
            CurrentItem.owner.SellItem(CurrentItem);
            CurrentItem.ChangeOwner(buyer);
        }

    } 

}