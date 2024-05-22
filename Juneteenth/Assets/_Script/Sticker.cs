using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sticker : DeskItem
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        nameTMP.text = GameManager.gm.PlayerName + ",";
    }
}
