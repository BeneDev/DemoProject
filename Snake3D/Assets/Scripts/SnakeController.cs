using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour {

    public LinkedList<GameObject> Entities
    {
        get
        {
            return entities;
        }
    }

    [SerializeField] GameObject snakeEntity;
    [SerializeField] int framesBetweenMoves;
    int frameCounter;
    GameObject newHead;
    Camera cam;
    float cam1;
    float cam2;
    float cam3;
    float cam4;
    float offsetX;
    float offsetZ;
    float offsetHeight;


    LinkedList<GameObject> entities = new LinkedList<GameObject>();

    public enum Direction
    {
        left,
        right,
        up,
        down
    };

    Direction playerDirection = Direction.right;

    private void Awake()
    {
        if (transform.childCount <= 0)
        {
            GameObject newPart = Instantiate(snakeEntity, transform.position, transform.rotation);
            newPart.transform.parent = gameObject.transform;
            entities.AddFirst(newPart);
        }
        else
        {
            entities.AddFirst(transform.GetChild(0).gameObject);
        }
        //cam = GetComponent<Camera>();
        cam = Camera.main;
        ResolutionAdjustment();
    }


    void CheckIfEatingSelf()
    {
        foreach(GameObject obj in entities)
        {
            if(entities.First.Value.gameObject != obj && obj.GetComponent<MeshRenderer>().enabled == true)
            {
                if (entities.First.Value.gameObject.transform.position == obj.transform.position)
                {
                    Die();
                }
            }
        }
    }

    void Die()
    {
        print("Die");
        SceneManager.LoadScene(2);
    }
    
    private void Update()
    {
        CheckIfEatingSelf();
        ReadInput();
        if (frameCounter <= 0)
        {
            // Add a new entity as a head
            newHead = Instantiate(snakeEntity, entities.First.Value.gameObject.transform.position, transform.rotation);
            newHead.transform.parent = gameObject.transform;
            entities.AddFirst(newHead);

            // Remove the last tail entity
            Destroy(entities.Last.Value.gameObject);
            entities.RemoveLast();

            Vector3 oldPos = entities.Last.Value.gameObject.transform.position;
            //newHead.transform.position += newHead.transform.forward;
            switch (playerDirection)
            {
                case Direction.up:
                    newHead.transform.position += Vector3.forward;
                    break;

                case Direction.down:
                    newHead.transform.position += Vector3.back;
                    break;

                case Direction.left:
                    newHead.transform.position += Vector3.left;
                    break;

                case Direction.right:
                    newHead.transform.position += Vector3.right;
                    break;
            }
            frameCounter = framesBetweenMoves;
        }
        else
        {
            frameCounter--;
        }
        BorderManagement();
              
       
        // TODO: 
        
        print(cam1);
        print(cam2);
        print(cam3);
        print(cam4);
        
        
        print(offsetHeight);
        print(offsetX);
        print(offsetZ);
    }
    
    void ResolutionAdjustment()
    {
       // TODO: ADJUST TO RESOLUTION

        //if (cam1 == 23.2) // 16:9
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        //if (cam1 == 19.58218) // 3:2
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        //if (cam1 == 19.575) // 16:10
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        //if (cam1 == 17.4) // 4:3
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        //if (cam1 == 16.30891) // 5:4
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        //if (cam1 == 27.56436) //Free Aspect
        //{
        //    offsetX = 1.5f;
        //    offsetZ = 1f;
        //    offsetHeight = 2f;
        //}
        // THESE ARE 16:9 :
        offsetX = 1.5f;
        offsetZ = 1f;
        offsetHeight = 2f;
    }
    private void BorderManagement()
    {
        cam1 = cam.transform.position.y * ((float)cam.pixelWidth / cam.pixelHeight) / 2;
        cam2 = -cam.transform.position.y * ((float)cam.pixelWidth / cam.pixelHeight) / 2;
        cam3 = cam.transform.position.y * ((float)cam.pixelHeight / cam.pixelWidth);
        cam4 = -cam.transform.position.y * ((float)cam.pixelHeight / cam.pixelWidth);

        if (newHead.transform.position.x >= cam1 + offsetX + offsetHeight)  // RIGHT
        {

            newHead.transform.position = new Vector3(cam2- offsetHeight , newHead.transform.position.y, newHead.transform.position.z); 
        }

        if (newHead.transform.position.x <= cam2  - offsetX - offsetHeight) // LEFT
        {

            newHead.transform.position = new Vector3(cam1+ offsetZ, newHead.transform.position.y, newHead.transform.position.z); 
        }
        if (newHead.transform.position.z > cam3+ offsetHeight + offsetZ)   //TOP
        {

            newHead.transform.position = new Vector3(newHead.transform.position.x, newHead.transform.position.y, cam4+ offsetHeight); 
        }
        if (newHead.transform.position.z < cam4 + offsetZ) //BOT
        {

            newHead.transform.position = new Vector3(newHead.transform.position.x, newHead.transform.position.y, cam3+offsetX);  
        }
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //entities.First.Value.gameObject.transform.Rotate(new Vector3(0, 90));
            switch (playerDirection)
            {
                case Direction.right:
                    playerDirection = Direction.down;
                    break;

                case Direction.down:
                    playerDirection = Direction.left;
                    break;

                case Direction.left:
                    playerDirection = Direction.up;
                    break;

                case Direction.up:
                    playerDirection = Direction.right;
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //entities.First.Value.gameObject.transform.Rotate(new Vector3(0, -90));
            switch (playerDirection)
            {
                case Direction.right:
                    playerDirection = Direction.up;
                    break;

                case Direction.down:
                    playerDirection = Direction.right;
                    break;

                case Direction.left:
                    playerDirection = Direction.down;
                    break;

                case Direction.up:
                    playerDirection = Direction.left;
                    break;
            }
        }
    }

    public void Expand()
    {
        GameObject newTail = Instantiate(snakeEntity, entities.First.Value.gameObject.transform.position, transform.rotation);
        newTail.transform.parent = gameObject.transform;
        newTail.GetComponent<MeshRenderer>().enabled = false;
        entities.AddLast(newTail);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag != "Player")
    //    {
    //        print("hit shit");
    //        GameObject newTail = Instantiate(snakeEntity, transform.position, transform.rotation);
    //        newTail.transform.parent = gameObject.transform;
    //        entities.AddLast(newTail);
    //        Destroy(other.gameObject);
    //    }
    //    else
    //    {
    //        print("Die");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        print("triggered");
    }

}
