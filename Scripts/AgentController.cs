using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class AgentController : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer; 
    private Rigidbody rb;

    public override void Initialize(){
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin(){
        transform.localPosition = new Vector3(0f, 0f, 0f);

        float randomX = Random.Range(-3f, 3f); // Adjust the range as needed
        float randomZ = Random.Range(-3f, 3f); // Adjust the range as needed
        target.localPosition = new Vector3(randomX, 0f, randomZ);
    }
    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.localPosition);
        // sensor.AddObservation(target.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actionBuffers){
        // float moveX = actionBuffers.ContinuousActions[0];
        // float moveZ = actionBuffers.ContinuousActions[1];
        float moveSpeed = 2f;
        float moveRotate = actionBuffers.ContinuousActions[0];
        float moveForward = actionBuffers.ContinuousActions[1];

        rb.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);
        // transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut){
        ActionSegment<float> continuous = actionsOut.ContinuousActions;
        continuous[0] = Input.GetAxis("Horizontal");
        continuous[1] = Input.GetAxis("Vertical");
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Pellet"){ 
            AddReward(+1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }
        if(other.gameObject.tag == "Wall"){ 
            AddReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
    }
}
