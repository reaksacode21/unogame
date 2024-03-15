using System.Collections;
using UnityEngine;

public class BubbleRotation : MonoBehaviour
{
    public Transform bubble;
    public float speed;
    public bool isOn;

    // private void Update() => BubbleRotate();
    private void FixedUpdate()
   {
        if (isOn)
        {
            BubbleRotate();
        }
   }
    public void BubbleRotate() => bubble.Rotate(0f, 0f, speed * Time.deltaTime);

}
