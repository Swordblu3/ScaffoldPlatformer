using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Momentum.EditorGlobal {

	public class BryanAssetPreprocessor : AssetPostprocessor {

		private void OnPreprocessTexture()
		{
			if (assetPath.Contains("Import Pixel")) {
				TextureImporter importer = (TextureImporter)assetImporter;
				importer.spritePixelsPerUnit = 32; // CHANGE THIS TO MATCH YOUR GAME SIZE
				importer.textureCompression = TextureImporterCompression.Uncompressed;
				importer.filterMode = FilterMode.Point;
				importer.wrapMode = TextureWrapMode.Repeat;

				TextureImporterSettings settings = new TextureImporterSettings();
				importer.ReadTextureSettings(settings);
				settings.spriteAlignment = (int)SpriteAlignment.BottomCenter;
				settings.spriteMeshType = SpriteMeshType.FullRect;
				settings.spriteExtrude = 0;
				importer.SetTextureSettings(settings);
			}
		}

	}

}
