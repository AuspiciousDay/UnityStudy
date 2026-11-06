using UnityEngine;

public class CharacterData
{
    public string Id { get; set;}
    public string Name { get; set;}
    public int Hp { get; set;}
    public int Atk { get; set;}
    public int Def { get; set;}
    public int Speed { get; set;}
    public string Icon { get; set;}

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringId => DataTableManager.StringTable.Get(Id);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");
}