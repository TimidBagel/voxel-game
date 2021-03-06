using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject{
    #region Variables
    new public string name = "New Item";
    public string type;
    public string description;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    #endregion
}