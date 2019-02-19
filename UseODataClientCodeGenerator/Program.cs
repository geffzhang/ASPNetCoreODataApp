using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseODataClientCodeGenerator
{
    class Program
    {
        
        /*
  * https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-client-app
  * 
  * 安装扩展套件
  * OData Client Code Generator
  * 
  * 安装后关闭所有 Visual Studio 后会跳出详细安装画面
  *      安装完成后开启 Visual Studio 套件就安装完成
  * 
  * 项目中建立新项目
  *      选择 "OData Client" 项目
  * 
  * 修改 *.tt 文件中的
  * public const string MetadataDocumentUri = "";
  * 
  * 为 OData 服务的 URL 路径 (http://url:port/odata/$metadata)
  * public const string MetadataDocumentUri = "http://localhost:53314/odata/$metadata";
  * 
  * 重新执行 *.tt 文件

  */

        static void Main(string[] args)
        {
            string _requestUri = "http://localhost:53314/odata";

            var _container = new Default.Container(new Uri(_requestUri));
            var _totalCount = _container.Person.Count();

            var _persons = _container.Person.Where(x => x.FirstName == "Crystal" && x.LastName == "Huang");


            Console.WriteLine("total count: {0}", _totalCount);
            Console.WriteLine();
            Console.WriteLine("filter: FirstName=\"Crystal\"");

            foreach (var _person in _persons)
                Console.WriteLine(JsonConvert.SerializeObject(_person, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}
