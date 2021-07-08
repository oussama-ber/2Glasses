using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Movement : MonoBehaviour
{
    Rigidbody rb; 
    [SerializeField] float moveSpeed = 10f; 
    public GameOver gameOver;
    public string zAxis = "Vertical";
    public string xAxis = "Horizontal";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         translateMover();
       
        
    }
    void translateMover()
    {
        float xValue = Input.GetAxis(xAxis) * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis(zAxis) * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
    void CheckMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
            gameOver.enabled= true;
        }
    }
}
