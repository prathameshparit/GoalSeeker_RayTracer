## GoalSeeker_RayTracer

### Overview
GoalSeeker_RayTracer is a Unity ML-Agents project that demonstrates a reinforcement learning agent trained to navigate towards a target while using ray tracing to detect obstacles. The agent learns to optimize its movement in a 3D environment by rotating towards the target and moving forward while avoiding walls. The project showcases fundamental reinforcement learning principles using Unity's ML-Agents Toolkit, combined with ray-based perception for enhanced navigation.

### Features
- **Reinforcement Learning Agent:** Uses the Proximal Policy Optimization (PPO) algorithm for training.
- **Ray Tracing for Obstacle Detection:** The agent uses ray tracing to sense the environment, detect obstacles, and navigate towards the target.
- **Dynamic Multi-Environment Setup:** Multiple training environments allow parallel learning with randomized target positions at the start of each episode, providing diverse training scenarios.
- **Rewards and Penalties:** The agent is rewarded for reaching the goal and penalized for hitting walls or failing to progress.
- **Training Visualizations:** Includes a demo video, images of the training process, command line output, TensorBoard metrics, and screenshots of the Unity environment.

### Demo
- A video showcasing the trained agent's behavior.
  <video src="https://github.com/user-attachments/assets/f12294c1-a774-4373-9e3c-ae0942c9f1cf" controls="controls" style="max-width: 100%;">
    Your browser does not support the video tag.
  </video>
  
- **Images:**
  - Screenshot of the Unity environment during a demo run.
    ![Screenshot 2024-10-24 000049](https://github.com/user-attachments/assets/b2edd353-8951-4c0e-859f-3b21e6ce3acb)
  - Command line output showing the training process.
    ![Screenshot 2024-10-24 001251](https://github.com/user-attachments/assets/04e383bb-d2f3-4f8a-bcf6-0680a573ed96)
  - TensorBoard metrics visualizing the training progress.
    ![Screenshot 2024-10-24 000527](https://github.com/user-attachments/assets/efe236e4-3f89-44da-a0c3-e0f77f2a7300)

### Installation and Setup
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/GoalSeeker_RayTracer.git
   ```
2. **Setup Unity ML-Agents:**
   - Follow the instructions to install Unity ML-Agents Toolkit [here](https://github.com/Unity-Technologies/ml-agents).
   - Ensure you have Python installed along with the required dependencies.

3. **Open the Project in Unity:**
   - Open the `GoalSeeker_RayTracer` Unity project.
   - Make sure the ML-Agents package is properly installed in Unity.

4. **Training the Agent:**
   - Run the following command in the command line to start training:
     ```bash
     mlagents-learn config/goal_seeker_raytracer_config.yaml --run-id=GoalSeekerRayTracerRun1
     ```
   - Press the Play button in the Unity Editor to begin training.

5. **Monitoring Training Progress:**
   - Use TensorBoard to visualize the training metrics:
     ```bash
     tensorboard --logdir=results/GoalSeekerRayTracerRun1
     ```
   - Open a web browser and navigate to `http://localhost:6006` to view TensorBoard.

### How It Works
- **Ray Perception:** The agent is equipped with a Ray Perception Sensor that uses ray tracing to detect objects tagged as "Wall" or "Pellet."
- **Rotation and Movement:** The agent can rotate towards the target and move forward based on detected rays, adjusting its actions to avoid obstacles.
- **Rewards and Penalties:** Rewards are given for reaching the target, while penalties are applied for hitting walls or making poor progress.
- **Multi-Environment Training:** Multiple training environments run in parallel, each with a randomized target position to accelerate learning.

### Configuration
The training configuration file (`goal_seeker_raytracer_config.yaml`) contains hyperparameters for the PPO algorithm, including:
- `batch_size`: Number of training samples used in each training update.
- `buffer_size`: Number of samples collected before updating the model.
- `learning_rate`: Step size for gradient descent updates.
- `ray_perception`: Settings for the Ray Perception Sensor, including the number of rays, length, and detectable tags.
