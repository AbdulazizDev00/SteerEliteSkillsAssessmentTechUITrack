# Steer Elite Internship Program Skills Assessment Tech UI Track – Main Menu UI

This Unity project implements the Main Menu UI for the Steer Elite Internship Program – Tech UI Track (2025 Cohort), using Unity UI Framework only (Canvas, Image, Button, TextMeshPro).

---

## 🎨 UI Overview

* Background: Pixel-art sky and sea
* Intro Ribbon: Diagonal INTRO TO banner
* Main Title: UNITY UI banner
* Buttons Panel: Container with three interactive buttons

  * Play ▶️
  * Settings ⚙️
  * Quit ❌
* Hover Effects:

  * Background color change
  * Scale up (105%)
  * Outline border toggle
  * Hand pointer icon appears at offset (630 px right, 35 px up)
* Responsive: Supports Portrait & Landscape via Canvas Scaler and Anchors

---

## 🛠 How to Run

1. Install Unity 2022.3.55f1 (LTS) via Unity Hub
2. Clone or download this repository
3. Open the project in Unity Hub
4. In Assets/Scenes, open MainMenu.unity
5. Ensure EventSystem is present in the Hierarchy
6. Press Play in the Editor to test the Main Menu

---

## ✅ Features

* Idle Animation: Implemented using `IdleFloat.cs` on the UNITY UI title banner. This script moves the element smoothly up and down to simulate an idle animation. Parameters used: `amplitude = 10f`, `frequency = 1.5f`.

```csharp
using UnityEngine;

public class IdleFloat : MonoBehaviour
{
    public float amplitude = 10f;
    public float frequency = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = startPos + new Vector3(0f, y, 0f);
    }
}
```

* Idle Animation: Implemented using `IdleFloat.cs` on the UNITY UI title banner. This script moves the element smoothly up and down to simulate an idle animation. Parameters used: `amplitude = 10f`, `frequency = 1.5f`.

- Safe Area Handling: Implemented using `SafeArea.cs`, which automatically creates a `SafeAreaPanel` under the Canvas and moves UI elements (TitleBanner, IntroBG, ButtonContainer) into it at runtime. This ensures correct layout on mobile devices with notches and rounded corners.

- Three buttons: Play, Settings, Quit with full hover feedback

- Hover logic implemented in UIButtonHover.cs:

  * Change backgroundImage.color to hoverColor
  * Scale button by 105%
  * Enable and disable outlineImage
  * Show and hide handIcon at specified offset (configured via public Vector2 handOffset = (630,35))

- Intro ribbon and title banner as UI Images with TextMeshPro text

- Responsive layout: Canvas Scaler set to Scale With Screen Size, anchors configured

- Safe Area handling via SafeArea.cs on the Canvas, using a public `elementsToWrap` array to automatically relocate specified UI elements into the SafeAreaPanel at runtime:

```csharp
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class SafeArea : MonoBehaviour
{
    Canvas _canvas;
    RectTransform _panel;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();

        GameObject go = new GameObject("SafeAreaPanel", typeof(RectTransform));
        go.transform.SetParent(transform, false);
        _panel = go.GetComponent<RectTransform>();

        _panel.anchorMin = Vector2.zero;
        _panel.anchorMax = Vector2.one;
        _panel.offsetMin = Vector2.zero;
        _panel.offsetMax = Vector2.zero;

        go.AddComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    void Start()
    {
        ApplySafeArea();
    }

    #if UNITY_EDITOR
    void Update()
    {
        ApplySafeArea();
    }
    #endif

    void ApplySafeArea()
    {
        Rect safe = Screen.safeArea;

        Vector2 anchorMin = safe.position;
        Vector2 anchorMax = safe.position + safe.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;
    }
}
```

---

## 🗂 Project Structure

```
Assets
├─ Backgrund
│  └─ back.png
├─ Fonts
│  └─ QuinqueFive.ttf
├─ Scenes
│  └─ MainMenu.unity
├─ Scripts
│  ├─ UIButtonHover.cs
│  ├─ SafeArea.cs
│  └─ IdleFloat.cs
├─ Settings
│  └─ Lit2DSceneTemplate.scenetemplate
├─ Sprite
│  ├─ Circle_outline.png
│  ├─ Circle_outline_2.png
│  ├─ circleSprite0.png
│  ├─ circlesprite128.png
│  └─ Hovering.png
```

---

## 🔧 Setup Details

* Canvas Scaler:

  * UI Scale Mode: Scale With Screen Size
  * Reference Resolution: 1920 × 1080
* Anchors:

  * Intro Banner: Top Left
  * Title Banner: Top Center
  * Buttons Panel: Center
* Optionally convert buttons to prefabs for reuse

---

## ⚙️ Pending Tasks

* Further tweak handOffset per screen resolution

---

## 👤 Author

Created by Abdulaziz Mohammed Almutairi for Steer Elite Internship Program – Tech UI Track (2025)

GitHub: [https://github.com/AbdulazizDev00/SteerEliteSkillsAssessmentTechUITrack]
