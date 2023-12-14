using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GubStates
{
    Attack,
    IdleDefend,
    Damaged,
    Total
}
public class Gube : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public List<Sprite> AnimationFrames;
    public GubStates CurrentState = GubStates.IdleDefend;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.sprite = AnimationFrames[(int)CurrentState];
    }
}
