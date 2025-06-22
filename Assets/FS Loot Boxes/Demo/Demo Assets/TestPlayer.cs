

using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    float speed = 3;

    private void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -Input.GetAxis("Vertical") * speed);
        transform.Translate(Vector3.right * Time.deltaTime * -Input.GetAxis("Horizontal") * speed);
    }

    void GetChestItems (GameObject[] prizes)
    {
        foreach (GameObject prize in prizes)
        {
            
            Debug.Log("You got " + prize.name);
        }
    }
}
