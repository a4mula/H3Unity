Sure thing—here’s the complete `README.md` in plaintext, ready for copy/paste:

---

H3Unity  
Unity-native wrapper for Uber's H3 hexagonal spatial indexing system. Includes runtime interop, editor tooling, MonoBehaviour components, and a formal test suite. Fully self-contained with native backend (h3.dll) included.

---

🚀 Features  
- Hex index conversion (FromLatLng, ToLatLng, ToParent, ToChildren)  
- Bitmask decoding (GetResolution, GetBaseCellNumber)  
- Formal test suite via Unity Test Framework  
- MonoBehaviours for scene visualization (H3Cell, H3Grid)  
- Custom editor inspectors for live editing  
- Includes precompiled native backend (h3.dll) for Windows

---

📦 Installation  
Add this to your Unity project's `Packages/manifest.json`:


"com.a4mula.h3unity": "https://github.com/a4mula/H3Unity.git"

Unity will automatically pull the package, including all scripts, DLLs, and test assets.

---

🧪 Testing  
Open **Window > General > Test Runner** and run all EditMode tests under `H3Unity.Tests`.  
Tests cover conversion accuracy, hierarchy logic, resolution decoding, and error handling.

---

🧱 Native Backend  
This package includes a precompiled `h3.dll` in `Plugins/`, built from Uber's H3 C library.  
No additional setup required—Unity will load it automatically.

If you need to rebuild or replace the DLL:
- Visit Uber’s H3 GitHub repo: https://github.com/uber/h3  
- Follow platform-specific build instructions  
- Replace `Plugins/h3.dll` with your custom build

---

📜 Licensing  
This SDK is licensed under the MIT License.  
It includes Uber’s H3 native backend (h3.dll) under the Apache 2.0 License.  
See `LICENSE` and `LICENSE.thirdparty` for full terms.

---

👤 Author  
Robb  
GitHub: https://github.com/a4mula

---

🧠 Notes  
- Designed for modular reuse across Unity projects  
- IL2CPP-safe and editor-friendly  
- No external dependencies beyond Unity Test Framework

---

