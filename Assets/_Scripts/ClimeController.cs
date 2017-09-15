using System.Collections;
using UnityEngine;

public enum Direction {
    UP, DOWN
}

public class ClimeController : MonoBehaviour{

    [SerializeField] private GameObject rain;

    public void StartWaterMovement(Transform target, float limit, float speed, Direction direction) {
        StopCoroutine(MoveWater(target, limit, speed, direction));
        StartCoroutine(MoveWater(target, limit, speed, direction));
    }

    public void StartSunMovement(Transform target, float limit, bool active, float speed) {
        StartCoroutine(SunMovement(target, limit, active, speed));
    }

    public void StopCoroutines() {
        StopAllCoroutines();
    }

    private IEnumerator MoveWater(Transform target, float limit, float speed, Direction direction) {
        if (direction == Direction.UP) {
            rain.SetActive(true);
            while (target.position.y < limit && target.position.y < 310) {
                target.position = new Vector3(target.position.x, target.position.y + Time.deltaTime * speed, target.position.z);

                yield return null;
            }
            rain.SetActive(false);
        } else if(direction == Direction.DOWN) {
            rain.SetActive(false);
            while (target.position.y > limit && target.position.y > 210) {
                target.position = new Vector3(target.position.x, target.position.y - Time.deltaTime * speed, target.position.z);

                yield return null;
            }
        }
    }

    private IEnumerator SunMovement(Transform target, float limit, bool active, float speed) {
        while (active) {
            target.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
            target.LookAt(Vector3.zero);

            yield return null;
        }
    }
}
