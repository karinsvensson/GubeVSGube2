using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnSelectDoThing : MonoBehaviour
{
    public List<Transform> Keyframes = new List<Transform>();
    public TextMeshProUGUI myText = null;
    public float spring = 0.4f;
    public float drag = 0.7f;

    Vector3 Velocity = Vector3.zero;
    Vector3 VelocityRotation = Vector3.zero;
    Vector3 VelocityScale = Vector3.zero;
    int CurrentKeyframe = 0;
    bool animate = false;
    // Start is called before the first frame update
    void Start()
    {
        //Velocity += (targetPos - currentPos) * spring;
        //Velocity -= drag * velocity;
        //CurrentPos += Velocity
    }

    public void OnSelect(string aTextMessage)
    {
        myText.text = aTextMessage;
        animate = true;
        Velocity = Vector3.zero;
        CurrentKeyframe = 0;
        transform.position = Keyframes[CurrentKeyframe].position;
        transform.rotation = Keyframes[CurrentKeyframe].rotation;
        transform.localScale = Keyframes[CurrentKeyframe].localScale;
        CurrentKeyframe = 1;
    }
    void Update()
    {
       if(animate)
       {
            Velocity += (Keyframes[CurrentKeyframe].position - transform.position) * spring;
            Velocity -= drag * Velocity;
            transform.position += Velocity;

            VelocityRotation += (Keyframes[CurrentKeyframe].rotation.eulerAngles - transform.rotation.eulerAngles) * spring;
            VelocityRotation -= drag * VelocityRotation;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + VelocityRotation);

            VelocityScale += (Keyframes[CurrentKeyframe].localScale - transform.localScale) * spring;
            VelocityScale -= drag * VelocityScale;
            transform.localScale += VelocityScale;
        }
    }


}
