# App-Update-System-AUS-
AUS is a Unity asset for effortless in-app updates. Simple UI, automatic checks, and customization options make it easy to keep users informed and engaged. Enhance user experience with AUS
# App Update System (AUS) Documentation

## Introduction

The App Update System (AUS) is a Unity asset designed to provide a simple and customizable solution for handling updates in your Unity applications. This documentation will guide you through the setup, customization, and usage of the AUS asset.

## Getting Started

### 1. Installation

- Import the AUS asset into your Unity project.
- Organize the asset structure as follows:
    - AppUpdateSystem (Root Folder)
        - Prefab
        - Scripts
        - Texture
        - Themes

### 2. Setting up the UI

- Attach the `AUSManager` script to a GameObject in your scene.
- Assign the required UI elements and themes to the script through the Unity Editor.

## Customization

### 1. Themes

- AUS allows you to customize the visual theme of the update UI.
- Open the `AUSThemes` scriptable object in the Themes folder to customize colors.
- Modify the color properties as per your preference.
  
Copy the link to the uploaded JSON file and paste it in the Serverurl field of the AUSManager script.
Usage
1. Automatic Update Check
The AUSManager script automatically checks for updates when the game starts.
If an update is available, the UI will prompt the user with the option to update.
2. User Interaction
If an update is detected, the user will see a popup with details.
They can choose to update immediately by clicking the "Update Now" button.
Alternatively, they can postpone the update by clicking the "Cancel" button.
3. Update Process
Upon clicking "Update Now," the user will be directed to the provided game URL.
The update size and other details are displayed to the user.
Integration
To integrate AUS with your game, include the AUSManager script in your main menu or a dedicated update-check scene.
Important Notes
Ensure that the provided themes match the visual style of your game.
Test the update process thoroughly to guarantee a seamless user experience.
Congratulations! You have successfully integrated the App Update System into your Unity project. If you have any issues or questions, refer to this documentation or contact the asset developer for support.
### 2. Server Configuration

- Prepare a JSON file with the following structure and upload it to your server:

```json
{
  "downloadSize": "YOUR GAME UPDATE SIZE",
  "version": "YOUR NEW VERSION OF GAME",
  "appUrl": "YOUR GAME URL"
}
