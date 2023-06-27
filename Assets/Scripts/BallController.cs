using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//NOT BURAYI SİL FARKETMEZ NERDE OLDUGUN
//TAGLER YERİNE RENKLER AYNI MI DİYE KONTROL ETTİR

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }




    private void OnCollisionEnter2D(Collision2D col)
    {
        //magnitude, bir vektörün uzunluğunu temsil eder ve o vektörün başlangıç noktasından son noktasına kadar olan mesafeyi verir.
        var speed = lastVelocity.magnitude; //speed burada nesnenin mevcut hareket hızını (hız vektörünün büyüklüğünü) tutar
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 5f);

        if (col.gameObject.CompareTag("Wall"))
        {
            ScoreManager.score += 2;

        }


    }





}
