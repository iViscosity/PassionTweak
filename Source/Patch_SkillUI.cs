using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PassionTweak
{
	[HarmonyPatch(typeof(SkillUI), "GetSkillDescription")]
	public static class Patch_SkillUI
	{
		public static void Postfix(ref string __result, SkillRecord sk)
		{
			if (!PassionTweak.Settings.Enabled) return;

			StringBuilder stringRebuilder = new StringBuilder(__result);
			StringBuilder oldStringBuilder = new StringBuilder();
			StringBuilder newStringBuilder = new StringBuilder();

			Passion passion = sk.passion;
			if (passion != Passion.None)
			{
				if (passion != Passion.Minor)
				{
					if (passion == Passion.Major)
					{
						oldStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionMajor", 1.5f.ToStringPercent("F0")));
						newStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionMajor", PassionTweak.Settings.MajorPassionValue.ToStringPercent("F0")));
					}
				}
				else
				{
					oldStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionMinor", 1f.ToStringPercent("F0")));
					newStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionMinor", PassionTweak.Settings.MinorPassionValue.ToStringPercent("F0")));
				}
			}
			else
			{
				oldStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionNone", 0.35f.ToStringPercent("F0")));
				newStringBuilder.Append(TranslatorFormattedStringExtensions.Translate("PassionNone", PassionTweak.Settings.NoPassionValue.ToStringPercent("F0")));
			}

			stringRebuilder.Replace(oldStringBuilder.ToString(), newStringBuilder.ToString());
			__result = stringRebuilder.ToString();
		}
	}
}