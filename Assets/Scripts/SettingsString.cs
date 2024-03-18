using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsString : MonoBehaviour
{
    public GameLevelData levelData;

    public void ClearGameData()
    {
        DataSaver.ClearGameData(levelData);
    }
}
