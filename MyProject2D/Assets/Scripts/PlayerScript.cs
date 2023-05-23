using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float velocity = 5;
    private int coinsCollect = 0;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject)
        {
            ++coinsCollect;
            Destroy(collision.collider.gameObject);
            print("Eu fui coletada");
            print(coinsCollect + " Moedas foram coletas!");
        }
    }

    private void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * velocity * Time.deltaTime;

        playerTransform.transform.Translate(new Vector3(moveX, moveY));
    }
}
