using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{


    public GameObject[] BallPrefab;



    private void Start()
    {
        GameObject greenObject = Instantiate(BallPrefab[0], transform.position, transform.rotation);
        greenObject.GetComponent<BallController>().BallColorIndex = 0;

        GameObject greenObject2 = Instantiate(BallPrefab[0], transform.position + new Vector3(1f, 1f, 1f), transform.rotation);
        greenObject2.GetComponent<BallController>().BallColorIndex = 0;

    }
    private void Update()
    {
    }


    public void OnButtonClick(int ballIndex, int requiredScore)
    {
        if (ScoreManager.score >= requiredScore)
        {
            GameObject newObject = Instantiate(BallPrefab[ballIndex], transform.position, transform.rotation);
            newObject.GetComponent<BallController>().BallColorIndex = ballIndex;
            newObject.transform.localScale = BallPrefab[ballIndex].transform.localScale;

            ScoreManager.score -= requiredScore;
        }
    }

    public void On_ClickG()
    {
        OnButtonClick(0, 10); //Topun Index'i 0'sa ve para 10'dan büyük ise Yeşil top butonuna basıldığında yeşil topu Instantiate et 
    }

    public void On_ClickR()
    {
        OnButtonClick(1, 30);
    }

    public void On_ClickY()
    {
        OnButtonClick(2, 40);
    }

    public void On_ClickSK()
    {
        OnButtonClick(3, 50);
    }

    public void On_ClickWM()
    {
        OnButtonClick(4, 60);
    }
    public void On_ClickYB()
    {
        OnButtonClick(5, 1);
    }


}

#region Buttons
//public void On_ClickG()
//{
//    if (ScoreManager.score >= 10)
//    {
//        GameObject newObject = Instantiate(BallPrefab[0], transform.position, transform.rotation);
//        newObject.GetComponent<BallController>().BallColorIndex = 0;
//        newObject.transform.localScale = BallPrefab[0].transform.localScale;

//        ScoreManager.score -= 10;

//    }
//}

//public void On_ClickR()
//{
//    if (ScoreManager.score >= 30)
//    {
//        GameObject newObject = Instantiate(BallPrefab[1], transform.position, transform.rotation);
//        newObject.GetComponent<BallController>().BallColorIndex = 1;
//        newObject.transform.localScale = BallPrefab[1].transform.localScale;

//        ScoreManager.score -= 30;
//    }
//}
//public void On_ClickY()
//{
//    if (ScoreManager.score >= 40)
//    {
//        GameObject newObject = Instantiate(BallPrefab[2], transform.position, transform.rotation);
//        newObject.GetComponent<BallController>().BallColorIndex = 2;
//        newObject.transform.localScale = BallPrefab[2].transform.localScale;

//        ScoreManager.score -= 40;
//    }
//}
//public void On_ClickSK()
//{
//    if (ScoreManager.score >= 50)
//    {
//        GameObject newObject = Instantiate(BallPrefab[3], transform.position, transform.rotation);
//        newObject.GetComponent<BallController>().BallColorIndex = 3;
//        newObject.transform.localScale = BallPrefab[3].transform.localScale;

//        ScoreManager.score -= 50;
//    }
//}
//public void On_ClickWM()
//{
//    if (ScoreManager.score >= 60)
//    {
//        GameObject newObject = Instantiate(BallPrefab[4], transform.position, transform.rotation);
//        newObject.GetComponent<BallController>().BallColorIndex = 4;
//        newObject.transform.localScale = BallPrefab[3].transform.localScale;

//        ScoreManager.score -= 60;
//    }
//}

#endregion


