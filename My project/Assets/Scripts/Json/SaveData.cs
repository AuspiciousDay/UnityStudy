using UnityEngine;

public abstract class SaveData
{
    public int Version { get; protected set; }
    public abstract SaveData VersionUp();
}

public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV2();
        data.PlayerName = PlayerName;
        return data;
    }
}

public class SaveDataV2 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;

    public SaveDataV2()
    {
        Version = 2;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV3();
        data.PlayerName = PlayerName;
        data.Gold = Gold;
        return data;
    }
}

public class SaveDataV3 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;
    public float EXP { get; set; } = 0f;
    public SaveDataV3()
    {
        Version = 3;
    }
    public override SaveData VersionUp()
    {
        var data = new SaveDataV4();
        data.PlayerFirstName = PlayerName.Split(' ')[1];
        data.PlayerLastName = PlayerName.Split(' ')[0];
        data.Gold = Gold;
        return data;
    }
}

public class SaveDataV4 : SaveData
{
    public string PlayerFirstName { get; set; } = string.Empty;
    public string PlayerLastName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;
    public SaveDataV4()
    {
        Version = 4;
    }
    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }
}