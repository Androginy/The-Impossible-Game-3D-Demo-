using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Cube;
    [SerializeField] Vector3 offset;
    [SerializeField] bool chaising = true;

    public void Stop()
    {
        chaising = false;
    }

    void Update()
    {
        if(!chaising)
            return;
        transform.position = Cube.position + offset; 
    }
}
