using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject targetObject;

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator targetAnimator = targetObject.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("topDeğidi");
            ScoreManager.score += 2;
            targetAnimator.SetBool("isMoney", true);

        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Animator targetAnimator = targetObject.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("ball"))
        {
            targetAnimator.SetBool("isMoney", false);

        }


    }


}
