using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Inventory/Object")]
public class Object : ScriptableObject
{
    new public string name = "New Object";
    public string type;
    public string description;
}
