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

    public void On_ClickG()
    {
        if (ScoreManager.score >= 10)
        {
            GameObject newObject = Instantiate(BallPrefab[0], transform.position, transform.rotation);
            newObject.GetComponent<BallController>().BallColorIndex = 0;
            newObject.transform.localScale = BallPrefab[0].transform.localScale;

            ScoreManager.score -= 10;

        }
    }
    public void On_ClickR()
    {
        if (ScoreManager.score >= 30)
        {
            GameObject newObject = Instantiate(BallPrefab[1], transform.position, transform.rotation);
            newObject.GetComponent<BallController>().BallColorIndex = 1;
            newObject.transform.localScale = BallPrefab[1].transform.localScale;

            ScoreManager.score -= 30;
        }
    }
    public void On_ClickY()
    {
        if (ScoreManager.score >= 40)
        {
            GameObject newObject = Instantiate(BallPrefab[2], transform.position, transform.rotation);
            newObject.GetComponent<BallController>().BallColorIndex = 2;
            newObject.transform.localScale = BallPrefab[2].transform.localScale;

            ScoreManager.score -= 40;
        }
    }


}
