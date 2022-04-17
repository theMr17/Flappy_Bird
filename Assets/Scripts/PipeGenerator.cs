using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipe;
    public GameObject backgroundGroup;
    public GameObject[] background;
    public Vector3[] position;

    private GameObject tmp;

    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //initializing the first instantiation
        tmp = Instantiate(pipe, position[6], Quaternion.identity);
        tmp.SetActive(true);
        tmp.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird.gameStarted)
        {
            if (tmp.transform.position.x <= 12 - 5)
            {
                Instantiate();
            }

            Move();
            MoveBackground();
        }
    }

    void Instantiate()
    {
        //instantiating pipes at random heights and setting its parent
        tmp = Instantiate(pipe, position[UnityEngine.Random.Range(1, 11 + 1)], Quaternion.identity);
        tmp.transform.SetParent(gameObject.transform);
    }

    void Move()
    {
        //moving the pipes
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void MoveBackground()
    {
        //moving the background at a slow speed
        backgroundGroup.transform.Translate(Vector3.left * (speed - 1f) * Time.deltaTime);

       if(background[1].transform.position.x <= -4.5f)
        {
            //transforming the position of the first background
            background[0].transform.position = new Vector3(background[2].transform.position.x + 19f, 0f, 0f);

            //rearranging the background array
            GameObject tmp1 = background[2];
            background[2] = background[0];
            background[0] = background[1];
            background[1]  = tmp1;
        }
    }
}
