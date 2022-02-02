using System;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public float priсe;
    public Inventory owner;
    [SerializeField] private Text priceText;
    
    private void Start()
    {
        owner = transform.parent.gameObject.GetComponent<Inventory>();
    }

    private void Update()
    {
        priceText.text = priсe.ToString();
    }

    public void Select(TradeController tradeController)
    {
        // parent = this.transform.parent;
        transform.parent = tradeController.transform;
    }

    public void Unselect()
    {
        transform.parent = owner.transform;
    }

    public void ChangeOwner(Inventory newOwner)
    {
        owner = newOwner;
        transform.SetParent(owner.transform);
    }
}