using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Delivery : MonoBehaviour
{

    private bool hasPackage = false;
    private SpriteRenderer spriteRenderer;

    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new(93, 212, 124, 255);
    [SerializeField] Color32 noPackageColor = new(255, 255, 255, 255);

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log("Outch!!");
    // }

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !this.hasPackage)
        {
            Debug.Log("Collected package");
            this.spriteRenderer.color = this.hasPackageColor;
            this.hasPackage = true;
            Destroy(other.gameObject, this.destroyDelay);
        }
        else if (other.CompareTag("Customer") && this.hasPackage)
        {
            Debug.Log("Package delivered");
            this.spriteRenderer.color = this.noPackageColor;
            this.hasPackage = false;
        }
    }
}
