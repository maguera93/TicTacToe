using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class GameView : View {

    public RectTransform boardTransform;

	public void SpawnCells(GameObject cellGO)
    {
        float initPos = boardTransform.rect.width / 3;
        Vector3 pos = new Vector3(-initPos, initPos);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject obj = GameObject.Instantiate(cellGO, Vector3.zero, Quaternion.identity, boardTransform.transform);
                obj.transform.localPosition = pos;
                pos.x += initPos;
                obj.GetComponent<CellView>().gridPos = new Vector2Int(i, j);
            }
            pos.x = -initPos;
            pos.y -= initPos;
        }
    }
}
