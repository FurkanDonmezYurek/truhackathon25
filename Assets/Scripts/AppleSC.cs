using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AppleSC : MonoBehaviour
{
    private XRGrabInteractable grab;
    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
    }


    // Update is called once per frame
    void Update()
    {
        if (grab.isSelected)
        {
            grab.forceGravityOnDetach = true;
        }
    }
}
