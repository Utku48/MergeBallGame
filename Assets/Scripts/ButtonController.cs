using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{


    public GameObject greenBallPrefab;
    private void Start()
    {
        GameObject greenObject = Instantiate(greenBallPrefab, transform.position, transform.rotation);
        GameObject greenObject2 = Instantiate(greenBallPrefab, transform.position + new Vector3(1f, 1f, 1f), transform.rotation);

    }



    private void Update()
    {
    }




    public void On_ClickB()
    {
        if (ScoreManager.score >= 10)
        {
            GameObject newObject = Instantiate(greenBallPrefab, transform.position, transform.rotation);

            newObject.transform.localScale = greenBallPrefab.transform.localScale;
            ScoreManager.score -= 10;
        }
    }


}
