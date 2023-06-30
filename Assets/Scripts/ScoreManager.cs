using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static List<int> ballColorIndexes = new List<int>() { 0, 0, 0 };


    public TextMeshProUGUI text;
    public static int score;

    public TextMeshProUGUI[] mergeTexts; // Text component'lerini tutan dizi

    private int[] mergeCounts = { 0, 0, 0 }; // Renk sayıları

    private string[] colors = { "Green", "Red", "Yellow" }; // Renk isimleri

    private string[] maxMerge = { "/25", "/50", "/75" };




    void Update()
    {
        text.text = "Money: " + score + " $";

        for (int i = 0; i < mergeTexts.Length; i++)
        {
            mergeTexts[i].text = colors[i] + " Merge \n  " + mergeCounts[i] + maxMerge[i];

        }
        for (int i = 0; i < ballColorIndexes.Count; i++)
        {
            mergeCounts[i] = ballColorIndexes[i];
        }

    }
}
