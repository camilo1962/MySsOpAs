using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSelector : MonoBehaviour
{
    public GameData currentGameData;
    public GameLevelData levelData;

    void Awake()
    {
        SelectSecuenciaBoardData();
    }

    private void SelectSecuenciaBoardData()
    {
        foreach (var data in levelData.data)
        {
            if(data.categoryName == currentGameData.selectedCategoryName)
            {
                var boardIndex = DataSaver.ReadCategoryCurrentIndexValues(currentGameData.selectedCategoryName);//TODO esto necesita ser leído desde el archivo externo

                if (boardIndex < data.boardData.Count)
                {
                    currentGameData.selectedBoardData = data.boardData[boardIndex];
                }
                else
                {
                    var randonIndex = Random.Range(0, data.boardData.Count);
                    currentGameData.selectedBoardData = data.boardData[randonIndex];
                }
            }
        }
    }
}
