from pathlib import Path
import re

scene_path = Path(__file__).resolve().parents[1] / "Assets" / "Scenes" / "Laberinto1.unity"
text = scene_path.read_text(encoding="utf-8")
pattern = re.compile(r"<<<<<<< HEAD\n(.*?)\n=======\n.*?\n>>>>>>> .*?\n", re.DOTALL)
new = pattern.sub(lambda m: m.group(1) + "\n", text)
scene_path.write_text(new, encoding="utf-8")
print(f"Resolved conflicts in {scene_path}")
