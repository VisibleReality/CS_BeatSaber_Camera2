﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera2.HarmonyPatches {
	[HarmonyPatch(typeof(StandardLevelScenesTransitionSetupDataSO), "Init")]
	class LeveldataHook {
		public static IDifficultyBeatmap difficultyBeatmap;
		static void Prefix(IDifficultyBeatmap difficultyBeatmap) {
			LeveldataHook.difficultyBeatmap = difficultyBeatmap;
		}

		[HarmonyPatch(typeof(MissionLevelScenesTransitionSetupDataSO), "Init")]
		private class LeveldatahookM {
			static void Prefix(IDifficultyBeatmap difficultyBeatmap) {
				LeveldataHook.difficultyBeatmap = difficultyBeatmap;
			}
		}

		[HarmonyPatch(typeof(MultiplayerLevelScenesTransitionSetupDataSO), "Init")]
		private class LeveldatahookMp {
			static void Prefix(IDifficultyBeatmap difficultyBeatmap) {
				LeveldataHook.difficultyBeatmap = difficultyBeatmap;
			}
		}
	}
}
