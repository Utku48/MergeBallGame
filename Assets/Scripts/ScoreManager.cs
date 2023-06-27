using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score;

    public TextMeshProUGUI Gmerge;
    public static int gMerge;



    void Update()
    {
        text.text = "Money: " + score + " $";
        Gmerge.text = "Green Merge:  \n " + gMerge + "/100 ";

    }
}
