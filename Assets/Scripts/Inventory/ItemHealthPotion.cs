using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRobEngine;

[CreateAssetMenu(menuName = "SRobEngine/Inventory/HealthPotion")]
public class ItemHealthPotion : InventoryItem
{
    [SerializeField] uint curationQuantity;
}
