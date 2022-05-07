using HarmonyLib;
using UnityEngine;
using Verse;

namespace PassionTweak
{
	public class PassionTweak : Mod
	{
		public static Settings Settings;
		public PassionTweak(ModContentPack content) : base(content)
		{
			Settings = GetSettings<Settings>();
#if DEBUG
			Harmony.DEBUG = true;
#endif

			if (Harmony.HasAnyPatches("io.github.ratysz.madskills"))
				Settings.MadSkillsCompatibilityPatch = true;

			new Harmony("vis.rimworld.PassionTweak.main").PatchAll();
		}

		public override string SettingsCategory() => "Passion Tweak";
		public override void DoSettingsWindowContents(Rect canvas)
		{
			base.DoSettingsWindowContents(canvas);
			Settings.DoWindowContents(canvas);
		}
	}
}
