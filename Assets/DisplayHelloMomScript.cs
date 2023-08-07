using UnityEngine;

public class DisplayHelloMom : MonoBehaviour
{
    public Transform birdTransform;
    public Vector3 textOffset = new Vector3(0, 1.5f, 0); // Adjust the Y value as needed

    private TextMesh helloMomTextMesh;

    void Start()
    {
        helloMomTextMesh = GetComponent<TextMesh>();
        helloMomTextMesh.text = ""; // Hide the text initially
    }

    void Update()
    {
        // Get the position of the bird (main character)
        Vector3 birdPosition = birdTransform.position;

        // Calculate the final position for the "Hello, Mom" text
        Vector3 textPosition = birdPosition + textOffset;

        // Set the position of the text in 3D space
        transform.position = textPosition;
    }

    public void ShowHelloMomText()
    {
        helloMomTextMesh.text = "Hello, Mom";
    }

    public void HideHelloMomText()
    {
        helloMomTextMesh.text = "";
    }
}
