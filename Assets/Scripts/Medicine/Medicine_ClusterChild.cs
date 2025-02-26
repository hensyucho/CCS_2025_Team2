using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine_ClusterChild : Bullet
{
    protected override void Start()
    {
        // startingPoint = playerObj.transform.position; これを爆裂した地点にするためにCluster側で生成時に値を入れる
        addVector = new Vector3(direction.x, direction.y, 0);
        addVector.Normalize();
        //Debug.Log(addVector);

        SoundManager.Instance.PlaySound("Shoot", transform.position);
    }
}
