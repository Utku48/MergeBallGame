using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    public int BallColorIndex;

    private bool hasCollided = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
        OnTouch();

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        //magnitude, bir vektörün uzunluğunu temsil eder ve o vektörün başlangıç noktasından son noktasına kadar olan mesafeyi verir.
        var speed = lastVelocity.magnitude / 10; //speed burada nesnenin mevcut hareket hızını (hız vektörünün büyüklüğünü) tutar
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 2f);

        if (collision.gameObject.CompareTag("Wall"))
        {
            ScoreManager.score += 2;

        }

    }



    private void OnTouch()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunulan nesneyi kontrol et
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                // Dokunulan nesne bu gameObject ise, yok et
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {

                    if (this.gameObject.CompareTag("ball"))
                    {
                        Destroy(gameObject);

                        ScoreManager.ballColorIndexes[BallColorIndex] += 1;

                    }

                }
            }
        }
    }


}
