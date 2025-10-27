using UnityEngine;

public class IceFloor : MonoBehaviour
{
    public float slideSpeed = 8f;
    public float slideDuration = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        IceSlider slider = other.GetComponent<IceSlider>();
        if (slider != null)
        {
            slider.StartSliding(slideSpeed, slideDuration);
        }
    }
}