using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasai.Storage
{
    public class StorageParams
    {
        public string? bucketName { get; set; }
        public string? nameFile { get; set; }   
        public string? fileType { get; set; }
        public FileStream? fileManage { get; set; }
    }
}
