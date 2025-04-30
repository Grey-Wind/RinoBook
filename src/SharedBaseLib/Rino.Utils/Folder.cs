using System;
using System.IO;

namespace Rino.Utils
{
    public class Folder
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">创建文件夹的路径（不包含名称）</param>
        /// <param name="folderName">创建的文件夹的名称</param>
        public static void CreateFolder(string path, string folderName)
        {
            try
            {
                string fullPath = Path.Combine(path, folderName);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"创建文件夹失败: {ex.Message}");
            }
        }
    }
}
