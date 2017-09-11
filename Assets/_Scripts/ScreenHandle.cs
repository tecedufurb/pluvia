using UnityEngine;

public class ScreenHandle : MonoBehaviour {

    [SerializeField] private Transform river;
    [SerializeField] private Transform sun;
    [SerializeField] private ClimeController climeController;

    public void StartRain() {
        float limit = river.position.y + 20f;
        climeController.StartWaterMovement(river, limit, 3f, Direction.UP);
    }

    public void StartDry() {
        float limit = river.position.y - 20f;
        climeController.StartWaterMovement(river, limit, 3f, Direction.DOWN);
    }

    public void StartDayNightCycle() {
        float limit = sun.rotation.x + 1;
        climeController.StartSunMovement(sun, limit, 25f);
    }
}
