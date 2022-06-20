using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public struct Slide
{
    [SerializeField] public Texture[] Img;
}

public class CameraMovement : MonoBehaviour
{
    [SerializeField] MeshRenderer[] planes;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Slide[] slide;

    int index = 0;
    int speed = 10;
    int[] counterSlides;
    // Start is called before the first frame update
    void Start()
    {
        counterSlides = new int[planes.Length];

    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, waypoints[index % waypoints.Length].position) < 0.1) {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && index != 0)
        {
            index--;

        }

        var step = speed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[index % waypoints.Length].rotation, step * 3);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index % waypoints.Length].position, step);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (slide[index].Img.Length != 0 && counterSlides[index] < slide[index].Img.Length-1)
            {
                counterSlides[index]++;
                planes[index].material.mainTexture = slide[index].Img[counterSlides[index]];
                
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (slide[index].Img.Length != 0 && counterSlides[index] > 0)
            {
                counterSlides[index]--;
                planes[index].material.mainTexture = slide[index].Img[counterSlides[index]];
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
