using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRobEngine
{
    public abstract class InventoryItem : ScriptableObject
    {
        [SerializeField] uint id;
        [SerializeField] string itemName;
        [SerializeField] Sprite itemIcon;

        public InventoryItem GetItem() { return this; }

    }
}
