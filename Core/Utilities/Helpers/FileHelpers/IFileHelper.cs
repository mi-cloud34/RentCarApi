using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        public String? Upload(IFormFile file, String root);
        public void Delete(String filePath);
        public String? Update(IFormFile file, String filePath, String root);
    }
}
