using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SRobEngine;

[CreateAssetMenu(menuName = "SRobEngine/Inventory/EnergyPotion")]
public class ItemEnergyPotion : InventoryItem
{
    [SerializeField] uint rechargeQuantity;
}
