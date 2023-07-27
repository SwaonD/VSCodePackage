using UnityEditor;

[InitializeOnLoad]
public class CustomAssetPostProcessor : AssetPostprocessor
{
    // Cette méthode est appelée chaque fois qu'un asset est supprimé dans Unity.
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets,
                                       string[] movedAssets, string[] movedFromAssetPaths)
    {
        // Parcourez tous les fichiers supprimés et vérifiez s'ils ont une extension ".cs".
        for (int i = 0; i < deletedAssets.Length; i++)
        {
            string assetPath = deletedAssets[i];
            if (assetPath.EndsWith(".cs"))
            {
                // Construisez le chemin du fichier ".meta" associé.
                string metaPath = assetPath + ".meta";

                // Vérifiez si le fichier ".meta" existe et supprimez-le.
                if (System.IO.File.Exists(metaPath))
                {
                    AssetDatabase.DeleteAsset(metaPath);
                }
            }
        }
    }
}
