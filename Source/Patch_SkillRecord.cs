﻿using HarmonyLib;
using RimWorld;
using System;
using System.Linq;
using Verse;

namespace PassionTweak
{
	[HarmonyPatch(typeof(SkillRecord), nameof(SkillRecord.LearnRateFactor))]
	public static class Patch_SkillRecord
	{
		private static bool MessageSent = false;
		public static void Postfix(ref float __result, SkillRecord __instance, bool direct = false)
		{
			//Log.Message($"Passion: {__instance.passion}, Factor: {__result}");
			if (!PassionTweak.Settings.Enabled) return;

			switch (__instance.passion)
			{
				case Passion.None:
					__result = PassionTweak.Settings.NoPassionValue;
					break;
				case Passion.Minor:
					__result = PassionTweak.Settings.MinorPassionValue;
					break;
				case Passion.Major:
					__result = PassionTweak.Settings.MajorPassionValue;
					break;
				default:
					if (!MessageSent) { 
						Log.Message("[PassionTweak][INFO] Passion level " + __instance.passion + " not supported by PassionTweak.");
						MessageSent = true;
					}
					break;
			}

			if (!direct && !PassionTweak.Settings.MadSkillsCompatibilityPatch)
				if (__instance.LearningSaturatedToday)
					__result *= 0.2f;
		}
	}
}
