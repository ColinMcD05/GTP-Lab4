using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{
    public void DestroyMeteor()
    {
        Destroy(this);
    }

    public void OnBecameInvisible()
    {
        DestroyMeteor();
    }
}
