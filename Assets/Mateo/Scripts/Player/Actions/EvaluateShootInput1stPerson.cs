using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Action/EvaluateShootInput1stPerson", fileName = "AcEvaluateShootInput1stPerson")]
public class EvaluateShootInput1stPerson : EvaluateShootInput
{
    public override void Shoot(Transform transform)
    {
        GameObject newBullet = PoolingManager.Instance.GetPooledObject(bulletName);

        newBullet.transform.position = transform.position + transform.rotation * gunPosition;
        newBullet.transform.rotation = transform.rotation;

        newBullet.SetActive(true);
    }
}
