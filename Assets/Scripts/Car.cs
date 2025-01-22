using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private float fuel = 100.0f;

    public TextMeshProUGUI text; 
    public Canvas MenuCanvas;
    public Canvas GameCanvas;
    
    void Start()
    {
    }
    
    void Update()
    {
        fuel -= 5.0f * Time.deltaTime;
        CarMovement();
        RemainGas();
        GameOver();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fuel"))
        {
            fuel += 30.0f;
            Destroy(other.gameObject);
            Debug.Log("연료획득! +30");
        }
    }

    private void CarMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed *Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right* moveSpeed * Time.deltaTime);
        }
        
    }
    private void RemainGas()
    {
        text.text = $"Gas:{Mathf.Max(0, Mathf.FloorToInt(fuel))}";
    }

    private void GameOver()
    {
        if (fuel <= 0.0f)
        {
            /*GameCanvas.gameObject.SetActive(false);
            MenuCanvas.gameObject.SetActive(true);*/
            SceneManager.LoadScene("Game");
            
        }
    }
}
