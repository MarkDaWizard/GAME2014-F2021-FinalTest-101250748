// Name: Phu Pham
// ID: 101250748
// File name: ShrinkingPlatformController.cs
// Date last modified: 15-Dec-2021
// Program description: Handle the behaviour of the shrinking platform
// Revision History: 
//  15-Dec-2021: Added functionality to shrinking platform

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive = false;
    public float rate = 0.002f;
    public float currentSize, originalSize;

    public AudioSource expandSound, shrinkSound;
    public float platformTimer;
    public float currentY = 0, originalY;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale.x;
        platformTimer = 0.1f;
        originalY = transform.parent.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentSize = transform.localScale.x;
        platformTimer += Time.deltaTime;
        Float();
        if(isActive)
        {
            Shrink();
            
        }
        else if(!isActive)
        {
            Expand();
            
        }
    }

    

    private void Shrink()
    {
        if (currentSize >= 0)
        {
            transform.localScale -= transform.localScale * rate;
            if (!expandSound.isPlaying && !shrinkSound.isPlaying)
                shrinkSound.Play();
            else if (expandSound.isPlaying)
            {
                expandSound.Stop();
                shrinkSound.Play();
            }
        }
        else
            shrinkSound.Stop();
    }

    private void Expand()
    {
        if (currentSize < originalSize)
        { 
            transform.localScale += transform.localScale * rate;
            if (!expandSound.isPlaying && !shrinkSound.isPlaying)
                expandSound.Play();
            else if(shrinkSound.isPlaying)
            {
                shrinkSound.Stop();
                expandSound.Play();
            }
            
        }
        else
            expandSound.Stop();
    }

    private void Float()
    {
        currentY = Mathf.PingPong(platformTimer, 1f);
        transform.parent.position = new Vector3(transform.position.x, currentY + originalY, 0.0f);
    }
        
}
