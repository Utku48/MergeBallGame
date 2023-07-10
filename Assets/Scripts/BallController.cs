using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    public int BallColorIndex;

    SpriteRenderer spriteRender;

    public ButtonController buttonController;

    [SerializeField] Vector3 direction;






    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Color ballColor = spriteRender.color;
        buttonController = FindAnyObjectByType<ButtonController>();

    }


    private void Update()
    {

        OnTouch();
        lastVelocity = rb.velocity;



    }
    private void FixedUpdate()
    {

        if (rb.velocity.magnitude <= 1.4f || rb.velocity == Vector2.zero)
        {
            Debug.Log("girdi");
            Vector2 ForceVector = transform.right * 10f;
            rb.AddForce(new Vector2(0, 1) * 5f, ForceMode2D.Force);

        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        //magnitude, bir vektörün uzunluğunu temsil eder ve o vektörün başlangıç noktasından son noktasına kadar olan mesafeyi verir.
        var speed = lastVelocity.magnitude / 25; //speed burada nesnenin mevcut hareket hızını (hız vektörünün büyüklüğünü) tutar


        direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal) * 1.01f;

        if (direction.magnitude < 0.2f)
        {
            Vector2 tempVelocity = transform.position - collision.gameObject.transform.position;
            direction = tempVelocity;

        }


        rb.velocity = direction * Mathf.Max(1f, 2f);



        if (!collision.transform.CompareTag("Wall"))
        {
            Color collisionColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }




        #region Temas

        int prefabCoun = buttonController.BallPrefab.Length;

        //for (int i = 0; i < prefabCoun; i++)
        //{
        //    if (collisionColor == gameObject.GetComponent<SpriteRenderer>().color)
        //    {
        //        Debug.Log("renkler aynı");

        //        int mergeCountRequirement = (i + 1) * 2;

        //        if (ScoreManager.mergeCounts[i] >= mergeCountRequirement && BallColorIndex == i)
        //        {
        //            Sayac.InstSayac++;
        //            if (Sayac.InstSayac == 2)
        //            {
        //                Destroy(collision.gameObject);
        //                Destroy(gameObject);

        //                GameObject ballInstant = buttonController.BallPrefab[i + 1];
        //                GameObject newObject = Instantiate(ballInstant, transform.position, Quaternion.identity);
        //                newObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 1.2f, ForceMode2D.Impulse);

        //                newObject.GetComponent<BallController>().BallColorIndex = i + 1;
        //                Sayac.InstSayac = 0;
        //            }

        //        }
        //    }
        //}

        #region GreenBallsCollision
        //    if (collisionColor == gameObject.GetComponent<SpriteRenderer>().color)
        //    {
        //        Debug.Log("renkler aynı");
        //        if (ScoreManager.mergeCounts[0] >= 25 && BallColorIndex == 0)
        //        {
        //            Destroy(collision.gameObject);
        //            Destroy(gameObject);

        //            GameObject ballInstant = buttonController.BallPrefab[1];
        //            GameObject newObject = Instantiate(ballInstant, transform.position, Quaternion.identity);
        //            newObject.GetComponent<BallController>().BallColorIndex++;

        //        }
        //        #endregion

        //        #region RedBallsCollision
        //        if (ScoreManager.mergeCounts[1] >= 50 && BallColorIndex == 1)
        //        {
        //            Destroy(collision.gameObject);
        //            Destroy(gameObject);

        //            GameObject ballInstant = buttonController.BallPrefab[2];
        //            GameObject newObject = Instantiate(ballInstant, transform.position, Quaternion.identity);
        //            newObject.GetComponent<BallController>().BallColorIndex = 2;

        //        }
        //    }
        //    #endregion
        //    #region YellowBallsCollision
        //    if (ScoreManager.mergeCounts[2] >= 75 && BallColorIndex == 2)
        //    {
        //        Destroy(collision.gameObject);
        //        Destroy(gameObject);

        //        GameObject ballInstant = buttonController.BallPrefab[2];
        //        GameObject newObject = Instantiate(ballInstant, transform.position, Quaternion.identity);
        //        newObject.GetComponent<BallController>().BallColorIndex = 3;
        //    }
        //}
        //#endregion


        #endregion

        #endregion
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
