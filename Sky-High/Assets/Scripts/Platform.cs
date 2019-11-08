using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isAtStart;

    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update§
    void Start()
    {
        transform.position = new Vector2(transform.position.x + Random.Range(-15f, 15f), transform.position.y + Random.Range(0, 150));
        startPosition.x = transform.position.x;
        endPosition.x = transform.position.x + Random.Range(3f, 6f);
        isAtStart = true;
        movementSpeed = Random.Range(1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        if (transform.position.x <= endPosition.x && isAtStart)
        {
            transform.Translate(+movementSpeed * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= endPosition.x)
                isAtStart = false;
        }
        else if (transform.position.x >= startPosition.x && !isAtStart)
        {
            transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= startPosition.x)
                isAtStart = true;
        }
    }

}
