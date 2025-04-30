using System;
using System.IO;
using Rino.Utils;

namespace Rino.NewProject
{
    /// <summary>
    /// 创建一个新的小说项目。
    /// </summary>
    public class RinoProject
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public required string ProjectName { private get; set; }

        /// <summary>
        /// 设定创建小说项目的文件夹
        /// </summary>
        public required string ProjectFolder { private get; set; }

        public void CreateProject()
        {
            // 创建项目文件夹
            try
            {
                if (Folder.CreateFolder(ProjectFolder, ProjectName) == true)
                {
                    // TODO
                }
                else
                {
                    throw new IOException("The folder creation failed. It might be that there are already duplicate folders.");
                }
            }
            catch (IOException cfioe)
            {
                throw new IOException(cfioe.Message);
            }
            catch (Exception cfe)
            {
                throw new Exception(cfe.Message);
            }
        }
    }
}
