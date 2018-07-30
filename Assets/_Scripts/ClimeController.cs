using System.Collections;
using UnityEngine;

public enum Direction {
    UP, DOWN
}

public class ClimeController : MonoBehaviour{
    
    [SerializeField] private GameObject rain;
    [SerializeField] private Transform river;
    [SerializeField] private Transform waterFall;
    private Vector3 waterFallInitialPosition;
    private Vector3 waterFallFinalPosition;
    private float minPosition = .7f;
    private float maxPosition = 12.2f;
    private float speed = 2f;

    private void Start() {
        waterFallInitialPosition = waterFall.position;
        waterFallFinalPosition = new Vector3(waterFall.position.x, -20f, waterFall.position.z);
    }

    public void StartRain() {
        StartCoroutine(MoveWater(Direction.UP));
    }
    
    public void StartDry() {
        StartCoroutine(MoveWater(Direction.DOWN));
    }

    private IEnumerator MoveWater(Direction direction) {
        switch (direction) {
            case Direction.UP:
                rain.SetActive(true);
                if (!waterFall.position.Equals(waterFallInitialPosition)) {
//                    print("ativou waterfall");
                    waterFall.position = waterFallInitialPosition;   
                }
                yield return new WaitForSeconds(2f);
                while (river.position.y < maxPosition) {
                    river.position = new Vector3(river.position.x, 
                        river.position.y + Time.deltaTime * speed, river.position.z);
                    yield return null;
                }
                rain.SetActive(false);
                break;
            case Direction.DOWN:
                rain.SetActive(false);
                yield return new WaitForSeconds(2f);
                while (river.position.y > minPosition) {
                    river.position = new Vector3(river.position.x, 
                        river.position.y - Time.deltaTime * speed, river.position.z);
                    yield return null;
                }
                waterFall.position = waterFallFinalPosition;
                break;
        }
    }
    
//    public void StartSunMovement(Transform target, float limit, bool active, float speed) {
//        StartCoroutine(SunMovement(target, limit, active, speed));
//    }
    
//    private IEnumerator SunMovement(Transform target, float limit, bool active, float speed) {
//        while (active) {
//            target.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
//            target.LookAt(Vector3.zero);
//
//            yield return null;
//        }
//    }
}
