using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using System;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private TextMeshProUGUI prizeText;

    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;

    private int prizeValue;

    private bool resultChecked = false;
    void Update()
    {
        if(!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultChecked)
        {
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize¡G" + prizeValue;
        }

    }

    private void OnMouseDown()
    {
        if((rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped){
            StartCoroutine("PullHandle");
        }
    }
}
