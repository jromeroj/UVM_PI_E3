using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasai.Storage
{
    public class StorageManage
    {
        
        public async Task<string> UploadFile(StorageParams fileParams)
        {
            FirebaseConnection fCnn = new FirebaseConnection();
            var clte = fCnn.FireStorageClte();
            try
            {                
                var response = await clte.UploadObjectAsync(fileParams.bucketName, fileParams.nameFile, fileParams.fileType, fileParams.fileManage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            



            return "";
            //using (var fileStream = new FileStream("Program.cs", FileMode.Open,
            //    FileAccess.Read, FileShare.Read))
            //{
            //    storageClient.UploadObject(bucketName, "Program.cs", "text/plain", fileStream);
            //}

            //// List objects
            //foreach (var obj in storageClient.ListObjects(bucketName, ""))
            //{
            //    Console.WriteLine(obj.Name);
            //}

            //// Download file
            //using (var fileStream = File.Create("Program-copy.cs"))
            //{
            //    storageClient.DownloadObject(bucketName, "Program.cs", fileStream);
            //}

            //foreach (var obj in Directory.GetFiles("."))
            //{
            //    Console.WriteLine(obj);
            //}


        }

    }
}
