using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		while (i < Input.touchCount) {
      
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

                if (hit.collider != null)
                {

                    if (hit.collider.tag == "Sound")
                    {
                        Debug.Log("Play Sound");
                        AudioSource.PlayClipAtPoint(hit.collider.gameObject.GetComponent<Sound>().sound, transform.position);
                    }

                }

            }
			++i;
		}

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

            if (hit.collider != null)
            {

                if (hit.collider.tag == "Sound")
                {
                    Debug.Log("Play Sound");
                    AudioSource.PlayClipAtPoint( hit.collider.gameObject.GetComponent<Sound>().sound, transform.position);
                }

            }

        }



    }
}
