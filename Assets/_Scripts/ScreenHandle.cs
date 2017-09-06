using UnityEngine;

public class ScreenHandle : MonoBehaviour {

    [SerializeField] private Transform river;
    [SerializeField] private ClimeController climeController;

    public void StartRain() {
        float limit = river.position.y + 20f;
        climeController.StartWaterMovement(river, limit, 5f, Direction.UP);
    }

    public void StartDry() {
        float limit = river.position.y - 20f;
        climeController.StartWaterMovement(river, limit, 5f, Direction.DOWN);
    }
}
