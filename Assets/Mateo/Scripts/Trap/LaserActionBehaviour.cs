using UnityEngine;

public class LaserActionBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask mirrorLayer;
    
    public void Action(LaserData laserData)
    {
        Transform transform = laserData.transform;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 25))
        {
            laserData.lr_.positionCount = 2;
            laserData.lr_.SetPosition(0, transform.position);
            laserData.lr_.SetPosition(1, hit.point);

            ReflectLaser(hit, transform.forward, 1, laserData);
        }
    }

    private void ReflectLaser(RaycastHit hit, Vector3 dir, int index, LaserData laserData)
    {
        if (hit.transform.gameObject.layer == mirrorLayer)
        {
            var direction = Vector3.Reflect(dir, hit.normal);
            Ray ray_ = new Ray(hit.point, direction);
            RaycastHit hit_;

            if (Physics.Raycast(ray_, out hit_, 25))
            {
                index++;
                laserData.lr_.positionCount++;
                laserData.lr_.SetPosition(index, hit_.point);

                ReflectLaser(hit_, direction, index, laserData);
            }
        }
    }
}
