using UnityEngine;

public class LaserActionBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask mirrorLayer;

    public LineRenderer lr_ { private get; set; }

    public void DisplayLaser()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 25))
        {
            lr_.positionCount = 2;
            lr_.SetPosition(0, transform.position);
            lr_.SetPosition(1, hit.point);

            ReflectLaser(hit, transform.forward, 1);
        }
    }

    private void ReflectLaser(RaycastHit hit, Vector3 dir, int index)
    {
        if (((1 << hit.transform.gameObject.layer) & mirrorLayer.value) != 0)
        {
            var direction = Vector3.Reflect(dir, hit.normal);
            Ray ray_ = new Ray(hit.point, direction);
            RaycastHit hit_;

            if (Physics.Raycast(ray_, out hit_, 25))
            {
                index++;
                lr_.positionCount++;
                lr_.SetPosition(index, hit_.point);

                ReflectLaser(hit_, direction, index);
            }
        }
    }
}
