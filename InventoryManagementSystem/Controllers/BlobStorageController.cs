using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public BlobStorageController(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("SaveCustomerDetails")]
        public async Task<IActionResult> SaveCustomerDetails(IFormFile formFile)
        {
            var blobConnectionstring = _configuration["ConnectionString:AzureBlob"];
            if(CloudStorageAccount.TryParse(blobConnectionstring,out CloudStorageAccount cloudStorage))
            {
                CloudBlobClient blobClient = cloudStorage.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference("customerdetails");
                await blobContainer.CreateIfNotExistsAsync();
                var cusBlob = blobContainer.GetBlockBlobReference(formFile.FileName);
                await cusBlob.UploadFromStreamAsync(formFile.OpenReadStream());
                return Ok(cusBlob.Uri);
            }
            return StatusCode(500);
        }
    }
}
