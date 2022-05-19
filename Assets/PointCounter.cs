using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public delegate void ScoreUpdate();

    public static event ScoreUpdate UpdateScore;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>()!=null)
        {
            UpdateScore?.Invoke();
        }
    }
}
