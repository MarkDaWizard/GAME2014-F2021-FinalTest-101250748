using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive = false;
    public float rate = 0.002f;
    public float currentSize, originalSize;

    public AudioSource expandSound, shrinkSound;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        currentSize = transform.localScale.x;
        if(isActive)
        {
            Shrink();
            
        }
        else if(!isActive)
        {
            Expand();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

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

    }
        
}
