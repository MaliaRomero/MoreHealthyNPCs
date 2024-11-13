
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 90f;
    //[SerializeField] private int startingHp = 100;
    //[SerializeField] private UnityEngine.UI.Slider hpBarSlider = null;
    //[SerializeField] private ParticleSystem deathParticlePrefab = null;
    //[SerializeField] private int currentHp;

    internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    //Added from Example
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        //hpBarSlider.transform.LookAt(Camera.main.transform);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instead of a percentage of starting health
            TakeDamage(10);
        }
    }
}