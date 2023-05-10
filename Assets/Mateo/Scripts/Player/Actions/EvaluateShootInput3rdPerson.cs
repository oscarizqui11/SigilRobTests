using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateShootInput3rdPerson", fileName = "AcEvaluateShootInput3rdPerson")]
public class EvaluateShootInput3rdPerson : EvaluateShootInput
{
    public override void Shoot(Transform transform)
    {
        GameObject newBullet = PoolingManager.Instance.GetPooledObject(bulletName);

        newBullet.transform.position = Camera.main.transform.position + Camera.main.transform.rotation * gunPosition;
        newBullet.transform.rotation = Camera.main.transform.rotation;

        newBullet.SetActive(true);
    }
}
