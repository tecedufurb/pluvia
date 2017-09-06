using System.Collections;
using UnityEngine;

public enum Direction {
    UP, DOWN
}

public class ClimeController : MonoBehaviour{

    public void StartWaterMovement(Transform target, float limit, float speed, Direction direction) {
        StopCoroutine(MoveWater(target, limit, speed, direction));
        StartCoroutine(MoveWater(target, limit, speed, direction));
    }

    private IEnumerator MoveWater(Transform target, float limit, float speed, Direction direction) {

        if (direction == Direction.UP) {
            while (target.position.y < limit) {
                target.position = new Vector3(target.position.x, target.position.y + Time.deltaTime * speed, target.position.z);

                yield return null;
            }
        } else if(direction == Direction.DOWN){
            while (target.position.y > limit) {
                target.position = new Vector3(target.position.x, target.position.y - Time.deltaTime * speed, target.position.z);

                yield return null;
            }
        }
    }

}
